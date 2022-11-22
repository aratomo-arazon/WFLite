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
        private IActivity? _current;

        private IEnumerator? _enumerator;

        public IOutVariable<IEnumerable>? Enumerable
        {
            private get;
            set;
        }

        public IInVariable? Value
        {
            private get;
            set;
        }

        public IActivity? Activity
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
            this.Require(Enumerable, nameof(Enumerable));
            this.Require(Value, nameof(Value));
            this.Require(Activity, nameof(Activity));
        }

        protected sealed override async Task start()
        {
            if (_current == null)
            {
                _enumerator = Enumerable!.GetValue()!.GetEnumerator();

                if (!_enumerator.MoveNext())
                {
                    Status = ActivityStatus.Completed;

                    return;
                }

                Value!.SetValue(_enumerator.Current);

                _current = Activity;

                var task = _current!.Start();

                Status = _current.Status;

                await task;

                Status = _current.Status;

                if (_current.Status.IsStopped() || _current.Status.IsSuspended())
                {
                    return;
                }
            }
            else
            {
                var task = _current.Start();

                Status = _current.Status;

                await task;

                Status = _current.Status;

                if (_current.Status.IsStopped() || _current.Status.IsSuspended())
                {
                    return;
                }
            }

            while (_enumerator!.MoveNext())
            {
                Value!.SetValue(_enumerator.Current);

                _current.Reset();

                var task = _current.Start();

                Status = _current.Status;

                await task;

                Status = _current.Status;

                if (_current.Status.IsStopped() || _current.Status.IsSuspended())
                {
                    break;
                }
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

            _enumerator = null;

            Status = ActivityStatus.Created;
        }
    }

    public class ForEachActivity<TValue> : Activity
    {
        private IActivity? _current;

        private IEnumerator<TValue>? _enumerator;

        public IOutVariable<IEnumerable<TValue>>? Enumerable
        {
            private get;
            set;
        }

        public IInVariable<TValue>? Value
        {
            private get;
            set;
        }

        public IActivity? Activity
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
            this.Require(Enumerable, nameof(Enumerable));
            this.Require(Value, nameof(Value));
            this.Require(Activity, nameof(Activity));
        }

        protected sealed override async Task start()
        {
            if (_current == null)
            {
                _enumerator = Enumerable!.GetValue()!.GetEnumerator();

                if (!_enumerator.MoveNext())
                {
                    Status = ActivityStatus.Completed;

                    return;
                }

                Value!.SetValue<TValue>(_enumerator.Current);

                _current = Activity;

                var task = _current!.Start();

                Status = _current.Status;

                await task;

                Status = _current.Status;

                if (_current.Status.IsStopped() || _current.Status.IsSuspended())
                {
                    return;
                }
            }
            else
            {
                var task = _current.Start();

                Status = _current.Status;

                await task;

                Status = _current.Status;

                if (_current.Status.IsStopped() || _current.Status.IsSuspended())
                {
                    return;
                }
            }

            while (_enumerator!.MoveNext())
            {
                Value!.SetValue(_enumerator.Current);

                _current.Reset();

                var task = _current.Start();

                Status = _current.Status;

                await task;

                Status = _current.Status;

                if (_current.Status.IsStopped() || _current.Status.IsSuspended())
                {
                    break;
                }
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

            _enumerator = null;

            Status = ActivityStatus.Created;
        }
    }
}
