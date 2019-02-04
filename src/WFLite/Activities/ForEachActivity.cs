/*
 * ForEachActivity.cs
 *
 * Copyright (c) 2019 aratomo-arazon
 *
 * This software is released under the MIT License.
 * http://opensource.org/licenses/mit-license.php
 */

using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using WFLite.Bases;
using WFLite.Enums;
using WFLite.Extensions;
using WFLite.Interfaces;

namespace WFLite.Activities
{
    public class ForEachActivity : Activity
    {
        private IActivity _current;

        public IOutVariable<IEnumerable> Enumerable
        {
            private get;
            set;
        }

        public IInVariable Value
        {
            private get;
            set;
        }

        public IActivity Activity
        {
            private get;
            set;
        }

        public ForEachActivity()
        {
        }

        public ForEachActivity(IOutVariable<IEnumerable> enumerable, IInVariable value, IActivity activity)
        {
            Enumerable = enumerable;
            Value = value;
            Activity = activity;
        }

        protected sealed override void initialize()
        {
        }

        protected sealed override async Task start()
        {
            foreach (var value in Enumerable.GetValue())
            {
                _current = Activity;

                Value.SetValue(value);

                _current.Reset();

                var task = Activity.Start();

                Status = _current.Status;

                await task;

                if (_current.Status.IsStopped())
                {
                    break;
                }
            }

            if (_current == null)
            {
                Status = ActivityStatus.Completed;
            }
            else
            {
                Status = _current.Status;
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

    public class ForEachActivity<TValue> : Activity
    {
        private IActivity _current;

        public IOutVariable<IEnumerable<TValue>> Enumerable
        {
            private get;
            set;
        }

        public IInVariable<TValue> Value
        {
            private get;
            set;
        }

        public IActivity Activity
        {
            private get;
            set;
        }

        public ForEachActivity()
        {
        }

        public ForEachActivity(IOutVariable<IEnumerable<TValue>> enumerable, IInVariable<TValue> value, IActivity activity)
        {
            Enumerable = enumerable;
            Value = value;
            Activity = activity;
        }

        protected sealed override void initialize()
        {
        }

        protected sealed override async Task start()
        {
            foreach (var value in Enumerable.GetValue())
            {
                _current = Activity;

                Value.SetValue(value);

                _current.Reset();

                var task = Activity.Start();

                Status = _current.Status;

                await task;

                if (_current.Status.IsStopped())
                {
                    break;
                }
            }

            if (_current == null)
            {
                Status = ActivityStatus.Completed;
            }
            else
            {
                Status = _current.Status;
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
