/*
 * DelayActivity.cs
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
using WFLite.Interfaces;

namespace WFLite.Activities
{
    public class DelayActivity : Activity
    {
        private CancellationTokenSource _cancellationTokenSource;

        public IVariable Duration
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

            var duration = Convert.ToInt32(Duration.GetValue());

            using (_cancellationTokenSource = new CancellationTokenSource())
            {
                try
                {
                    await Task.Delay(duration, _cancellationTokenSource.Token);

                    if (Status.IsStopping())
                    {
                        Status = ActivityStatus.Stopped;
                    }
                    else
                    {
                        Status = ActivityStatus.Completed;
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

        protected override void reset()
        {
            _cancellationTokenSource = null;

            Status = ActivityStatus.Created;
        }
    }
}
