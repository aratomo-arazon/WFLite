/*
 * WhileActivity.cs
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
    public class WhileActivity : Activity
    {
        private IActivity? _current;

        public ICondition? Condition
        {
            private get;
            set;
        }

        public IActivity? Activity
        {
            private get;
            set;
        }

        public WhileActivity()
        {
        }

        public WhileActivity(ICondition condition, IActivity activity)
        {
            Condition = condition;
            Activity = activity;
        }

        protected sealed override void initialize()
        {
            this.Require(Condition, nameof(Condition));
            this.Require(Activity, nameof(Activity));
        }

        protected sealed override async Task start()
        {
            if (_current == null)
            {
                if (!Condition!.Check())
                {
                    Status = ActivityStatus.Completed;

                    return;
                }

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

            while (Condition!.Check())
            {
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

            Status = Activity!.Status;
        }
    }
}
