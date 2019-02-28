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
    public class ForEachActivity : ForEachActivity<IEnumerable, IEnumerator, IInVariable>
    {
        public ForEachActivity()
        {
        }

        public ForEachActivity(IOutVariable<IEnumerable> enumerable, IInVariable value, IActivity activity)
        {
            Enumerable = enumerable;
            Value = value;
            Activity = activity;
        }

        protected sealed override IEnumerator getEnumerator(IEnumerable enumerable)
        {
            return enumerable.GetEnumerator();
        }

        protected sealed override void setValue(IInVariable variable, IEnumerator enumerator)
        {
            variable.SetValue(enumerator.Current);
        }
    }

    public class ForEachActivity<TValue> : ForEachActivity<IEnumerable<TValue>, IEnumerator<TValue>, IInVariable<TValue>>
    {
        public ForEachActivity()
        {
        }

        public ForEachActivity(IOutVariable<IEnumerable<TValue>> enumerable, IInVariable<TValue> value, IActivity activity)
        {
            Enumerable = enumerable;
            Value = value;
            Activity = activity;
        }

        protected sealed override IEnumerator<TValue> getEnumerator(IEnumerable<TValue> enumerable)
        {
            return enumerable.GetEnumerator();
        }

        protected sealed override void setValue(IInVariable<TValue> variable, IEnumerator<TValue> enumerator)
        {
            variable.SetValue<TValue>(enumerator.Current);
        }
    }

    public abstract class ForEachActivity<TEnumerable, TEnumerator, TInVariable> : Activity
        where TEnumerable : IEnumerable
        where TEnumerator : class, IEnumerator
        where TInVariable : IInVariable
    {
        private IActivity _current;

        private TEnumerator _enumerator;

        public IOutVariable<TEnumerable> Enumerable
        {
            private get;
            set;
        }

        public TInVariable Value
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

        public ForEachActivity(IOutVariable<TEnumerable> enumerable, TInVariable value, IActivity activity)
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
            if (_current == null)
            {
                _enumerator = getEnumerator(Enumerable.GetValue());

                if (!_enumerator.MoveNext())
                {
                    Status = ActivityStatus.Completed;

                    return;
                }

                setValue(Value, _enumerator);

                _current = Activity;

                var task = _current.Start();

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

            while (_enumerator.MoveNext())
            {
                Value.SetValue(_enumerator.Current);

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

        protected abstract TEnumerator getEnumerator(TEnumerable enumerable);

        protected abstract void setValue(TInVariable variable, TEnumerator enumerator);
    }
}
