/*
 * AsyncActivity.cs
 *
 * Copyright (c) 2019 aratomo-arazon
 *
 * This software is released under the MIT License.
 * http://opensource.org/licenses/mit-license.php
 */

using System;
using System.Threading;
using System.Threading.Tasks;
using WFLite.Bases;
using WFLite.Enums;
using WFLite.Extensions;

namespace WFLite.Activities
{
    public class AsyncActivity : Activity
    {
        private CancellationTokenSource _cancellationTokenSource;

        public Func<CancellationToken, Task<bool>> Func
        {
            private get;
            set;
        }

        protected override void initialize()
        {
        }

        protected override async Task start()
        {
            Status = ActivityStatus.Executing;

            using (_cancellationTokenSource = new CancellationTokenSource())
            {
                var cancellationToken = _cancellationTokenSource.Token;

                try
                {
                    var result = await run(cancellationToken);

                    if (result && Status.IsExecuting())
                    {
                        Status = ActivityStatus.Completed;
                    }
                    else
                    {
                        Status = ActivityStatus.Stopped;
                    }
                }
                catch (TaskCanceledException)
                {
                    Status = ActivityStatus.Stopped;
                }
            }

            _cancellationTokenSource = null;
        }

        protected override void stop()
        {
            if (Status.IsCreated())
            {
                Status = ActivityStatus.Stopped;
            }
            else
            {
                Status = ActivityStatus.Stopping;

                if (_cancellationTokenSource != null)
                {
                    _cancellationTokenSource.Cancel();
                }
            }
        }

        protected override void reset()
        {
            _cancellationTokenSource = null;

            Status = ActivityStatus.Created;
        }

        protected virtual Task<bool> run(CancellationToken cancellationToken)
        {
            if (Func == null)
            {
                return Task.FromResult(false);
            }

            return Func(cancellationToken);
        }
    }
}
