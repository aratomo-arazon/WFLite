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
using WFLite.Extensions;
using WFLite.Interfaces;

namespace WFLite.Activities
{
    public class LockActivity : Activity
    {
        public IActivity _current;

        private SemaphoreSlim _lockObject;

        public IOutVariable<SemaphoreSlim> LockObject
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

        public LockActivity(IOutVariable<SemaphoreSlim> lockObject, IActivity activity)
        {
            LockObject = lockObject;
            Activity = activity;
        }

        protected sealed override void initialize()
        {
        }

        protected sealed override async Task start()
        {
            if (_current == null)
            {
                _lockObject = LockObject.GetValue();

                await _lockObject.WaitAsync().ConfigureAwait(false);

                _current = Activity;
            }

            try
            {
                var task = _current.Start();

                Status = _current.Status;

                await task;

                Status = _current.Status;

                if (_current.Status.IsSuspended())
                {
                    return;
                }
            }
            catch
            {
                if (_lockObject != null)
                {
                    _lockObject.Release();
                    _lockObject = null;
                }

                throw;
            }

            if (_lockObject != null)
            {
                _lockObject.Release();
                _lockObject = null;
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

            if (Status.IsFinished() && _lockObject != null)
            {
                _lockObject.Release();
                _lockObject = null;
            }
        }

        protected sealed override void reset()
        {
            if (_current != null)
            {
                _current.Reset();
                _current = null;
            }

            if (_lockObject != null)
            {
                _lockObject.Release();
                _lockObject = null;
            }

            Status = ActivityStatus.Created;
        }
    }
}
