/*
 * SwitchActivity.cs
 *
 * Copyright (c) 2019 aratomo-arazon
 *
 * This software is released under the MIT License.
 * http://opensource.org/licenses/mit-license.php
 */

using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WFLite.Bases;
using WFLite.Enums;
using WFLite.Interfaces;

namespace WFLite.Activities
{
    public class SwitchActivity : Activity
    {
        private IActivity _current;

        public IOutVariable Value
        {
            private get;
            set;
        }

        public IDictionary<object, IActivity> Cases
        {
            private get;
            set;
        }

        public IActivity Default
        {
            private get;
            set;
        }

        public SwitchActivity()
        {
        }

        public SwitchActivity(IOutVariable value, IDictionary<object, IActivity> cases, IActivity default_ = null)
        {
            Value = value;
            Cases = cases;
            Default = default_;
        }

        protected sealed override void initialize()
        {
            if (Default == null)
            {
                Default = new NullActivity();
            }
        }

        protected sealed override async Task start()
        {
            if (_current == null)
            {
                var value = Value.GetValueAsObject();
                var activity = Cases.FirstOrDefault(p => p.Key.Equals(value)).Value;

                if (activity == null)
                {
                    _current = Default;
                }
                else
                {
                    _current = activity;
                }
            }

            var task = _current.Start();

            Status = _current.Status;

            await task;

            Status = _current.Status;
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

            Status = ActivityStatus.Created;
        }

    }

    public class SwitchActivity<TValue> : Activity
    {
        private IActivity _current;

        public IOutVariable<TValue> Value
        {
            private get;
            set;
        }

        public IDictionary<TValue, IActivity> Cases
        {
            private get;
            set;
        }

        public IActivity Default
        {
            private get;
            set;
        }

        public SwitchActivity()
        {
        }

        public SwitchActivity(IOutVariable<TValue> value, IDictionary<TValue, IActivity> cases, IActivity default_ = null)
        {
            Value = value;
            Cases = cases;
            Default = default_;
        }

        protected sealed override void initialize()
        {
            if (Default == null)
            {
                Default = new NullActivity();
            }
        }

        protected sealed override async Task start()
        {
            if (_current == null)
            {
                var value = Value.GetValue<TValue>();
                var activity = Cases.FirstOrDefault(p => p.Key.Equals(value)).Value;

                if (activity == null)
                {
                    _current = Default;
                }
                else
                {
                    _current = activity;
                }
            }

            var task = _current.Start();

            Status = _current.Status;

            await task;

            Status = _current.Status;
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

            Status = ActivityStatus.Created;
        }
    }
}
