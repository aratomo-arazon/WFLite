/*
 * WaitActivity.cs
 *
 * Copyright (c) 2019 aratomo-arazon
 *
 * This software is released under the MIT License.
 * http://opensource.org/licenses/mit-license.php
 */

using System.Threading.Tasks;
using WFLite.Bases;
using WFLite.Enums;
using WFLite.Interfaces;

namespace WFLite.Activities
{
    public class SuspendActivity : Activity
    {
        public ICondition Until
        {
            private get;
            set;
        }

        public SuspendActivity()
        {
        }

        public SuspendActivity(ICondition until)
        {
            Until = until;
        }

        protected sealed override void initialize()
        {
        }

        protected sealed override async Task start()
        {
            if (Until.Check())
            {
                Status = ActivityStatus.Completed;
            }
            else
            {
                Status = ActivityStatus.Suspended;
            }

            await Task.CompletedTask;
        }

        protected sealed override void stop()
        {
            Status = ActivityStatus.Stopped;
        }

        protected sealed override void reset()
        {
            Status = ActivityStatus.Created;
        }
    }
}
