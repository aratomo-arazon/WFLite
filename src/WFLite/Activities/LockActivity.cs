/*
 * LockActivity.cs
 *
 * Copyright (c) 2019 aratomo-arazon
 *
 * This software is released under the MIT License.
 * http://opensource.org/licenses/mit-license.php
 */

using System.Threading;
using System.Threading.Tasks;
using WFLite.Bases;
using WFLite.Enums;
using WFLite.Interfaces;

namespace WFLite.Activities
{
    public class LockActivity : Activity
    {
        public IActivity _current;

        public IVariable LockObject
        {
            private get;
            set;
        }

        public IActivity Activity
        {
            private get;
            set;
        }

        public LockActivity()
        {
        }

        public LockActivity(IVariable lockObject, IActivity activity)
        {
            Activity = activity;
        }

        protected sealed override void initialize()
        {
        }

        protected sealed override async Task start()
        {
            var lockObject = LockObject.GetValue<SemaphoreSlim>();

            await lockObject.WaitAsync().ConfigureAwait(false);

            try
            {
                _current = Activity;

                var task = _current.Start();

                Status = _current.Status;

                await task;

                Status = _current.Status;
            }
            finally
            {
                lockObject.Release();
            }
        }

        protected sealed override void stop()
        {
            if (_current != null)
            {
                _current.Stop();

                Status = _current.Status;
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
