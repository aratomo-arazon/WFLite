/*
 * StopwatchActivity.cs
 *
 * Copyright (c) 2019 aratomo-arazon
 *
 * This software is released under the MIT License.
 * http://opensource.org/licenses/mit-license.php
 */

using System;
using System.Threading.Tasks;
using WFLite.Bases;
using WFLite.Enums;
using WFLite.Interfaces;

namespace WFLite.Activities.Diagnostics
{
    public class StopwatchActivity : Activity
    {
        private IActivity _current;

        public IActivity Activity
        {
            private get;
            set;
        }

        public IVariable Elapsed
        {
            private get;
            set;
        }

        public StopwatchActivity()
        {
        }

        public StopwatchActivity(IActivity activity, IVariable elapsed)
        {
            Activity = activity;
            Elapsed = elapsed;
        }

        protected sealed override void initialize()
        {
        }

        protected sealed override async Task start()
        {
            Elapsed.SetValue(0);

            _current = Activity;

            var stopwatch = new System.Diagnostics.Stopwatch();

            stopwatch.Start();

            try
            {

                var task = _current.Start();

                Status = _current.Status;

                await task;

                Status = _current.Status;
            }
            finally
            {
                stopwatch.Stop();
            }

            Elapsed.SetValue(stopwatch.ElapsedMilliseconds);
        }

        protected sealed override void stop()
        {
            if (_current != null)
            {
                _current.Stop();

                try
                {
                    Status = _current.Status;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
            {
                Status = ActivityStatus.Stopped;
            }
        }

        protected sealed override void reset()
        {
            if (_current != null)
            {
                _current.Reset();
                _current = null;
            }

            Status = Activity.Status;
        }
    }
}
