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
        private IActivity _current;

        public ICondition Condition
        {
            private get;
            set;
        }

        public IActivity Activity
        {
            private get;
            set;
        }

        protected sealed override void initialize()
        {
        }

        protected sealed override async Task start()
        {
            if (Condition.Check())
            {
                _current = Activity;

                do
                {
                    _current.Reset();

                    var task = _current.Start();

                    Status = _current.Status;

                    await task;

                    if (_current.Status.IsStopped())
                    {
                        break;
                    }
                }
                while (Condition.Check());

                Status = _current.Status;
            }
            else
            {
                Status = ActivityStatus.Completed;
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
