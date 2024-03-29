﻿/*
 * IfActivity.cs
 *
 * Copyright (c) 2019 aratomo-arazon
 *
 * This software is released under the MIT License.
 * http://opensource.org/licenses/mit-license.php
 */

using System.Threading.Tasks;
using WFLite.Bases;
using WFLite.Enums;
using WFLite.Extensions;
using WFLite.Interfaces;

namespace WFLite.Activities
{
    public class IfActivity : Activity
    {
        private IActivity? _current;

        public ICondition? Condition
        {
            private get;
            set;
        }

        public IActivity? Then
        {
            private get;
            set;
        }

        public IActivity? Else
        {
            private get;
            set;
        }

        public IfActivity()
        {
        }

        public IfActivity(ICondition condition, IActivity? then = null, IActivity? else_ = null)
        {
            Condition = condition;
            Then = then;
            Else = else_;
        }

        protected sealed override void initialize()
        {
            this.Require(Condition, nameof(Condition));
            Then = Then == null ? new NullActivity() : Then;
            Else = Else == null ? new NullActivity() : Else;
        }

        protected sealed override async Task start()
        {
            if (_current == null)
            {
                if (Condition!.Check())
                {
                    _current = Then;
                }
                else
                {
                    _current = Else;
                }
            }

            var task = _current!.Start();

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
