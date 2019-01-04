/*
 * SwitchActivity.cs
 *
 * Copyright (c) 2019 Tomoharu Araki
 *
 * This software is released under the MIT License.
 * http://opensource.org/licenses/mit-license.php
 */

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

        public IVariable Value
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

        protected override void initialize()
        {
            if (Default == null)
            {
                Default = new NullActivity();
            }
        }

        protected override async Task start()
        {
            var value = Value.GetValue();

            var activity = Cases.FirstOrDefault(c => c.Key.Equals(value)).Value;

            if (activity == null)
            {
                _current = Default;
            }
            else
            {
                _current = activity;
            }

            var task = _current.Start();

            Status = _current.Status;

            await task;

            Status = _current.Status;
        }

        protected override void stop()
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

        protected override void reset()
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
