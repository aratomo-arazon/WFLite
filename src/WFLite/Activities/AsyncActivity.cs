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
    public abstract class AsyncActivity : Activity
    {
        private CancellationTokenSource _cancellationTokenSource;

        protected override void initialize()
        {
        }

        protected sealed override async Task start()
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

        protected sealed override void stop()
        {
            if (Status.IsCreated())
            {
                Status = ActivityStatus.Stopped;

                return;
            }

            Status = ActivityStatus.Stopping;

            if (_cancellationTokenSource != null)
            {
                if (_cancellationTokenSource.Token.CanBeCanceled)
                {
                    try
                    {
                        _cancellationTokenSource.Cancel();
                    }
                    catch (Exception ex)
                    {

                        throw ex;
                    }
                }
            }
        }

        protected sealed override void reset()
        {
            _cancellationTokenSource = null;

            Status = ActivityStatus.Created;
        }

        protected abstract Task<bool> run(CancellationToken cancellationToken);
    }
}
