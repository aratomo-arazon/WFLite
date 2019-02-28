/*
 * UsingActivity.cs
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
using WFLite.Extensions;
using WFLite.Interfaces;

namespace WFLite.Activities
{
    public class UsingActivity : Activity
    {
        public IActivity _current;

        private IDisposable _disposable;

        public IOutVariable<IDisposable> Disposable
        {
            private get;
            set;
        }

        public IActivity Activity
        {
            private get;
            set;
        }

        public UsingActivity()
        {
        }

        public UsingActivity(IOutVariable<IDisposable> disposable, IActivity activity)
        {
            Disposable = disposable;
            Activity = activity;
        }

        protected sealed override void initialize()
        {
        }

        protected sealed override async Task start()
        {
            if (_current == null)
            {
                _disposable = Disposable.GetValue();

                _current = Activity;
            }

            try
            {
                var task = _current.Start();

                Status = _current.Status;

                await task;

                Status = _current.Status;

                if (_current.Status == ActivityStatus.Suspended)
                {
                    return;
                }
            }
            catch
            {
                if (_disposable != null)
                {
                    _disposable.Dispose();
                    _disposable = null;
                }

                throw;
            }

            if (_disposable != null)
            {
                _disposable.Dispose();
                _disposable = null;
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

            if (Status.IsFinished() && _disposable != null)
            {
                _disposable.Dispose();
                _disposable = null;
            }
        }

        protected sealed override void reset()
        {
            if (_current != null)
            {
                _current.Reset();
                _current = null;
            }

            if (_disposable != null)
            {
                _disposable.Dispose();
                _disposable = null;
            }

            Status = ActivityStatus.Created;
        }
    }
}
