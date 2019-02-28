/*
 * SyncActivity.cs
 *
 * Copyright (c) 2019 aratomo-arazon
 *
 * This software is released under the MIT License.
 * http://opensource.org/licenses/mit-license.php
 */

using System.Threading.Tasks;
using WFLite.Bases;
using WFLite.Enums;

namespace WFLite.Bases
{
    public abstract class SyncActivity : Activity
    {
        protected override void initialize()
        {
        }

        protected sealed override async Task start()
        {
            await Task.CompletedTask;

            var result = run();

            if (result)
            {
                Status = ActivityStatus.Completed;
            }
            else
            {
                Status = ActivityStatus.Stopped;
            }
        }

        protected sealed override void stop()
        {
            Status = ActivityStatus.Stopped;
        }

        protected sealed override void reset()
        {
            Status = ActivityStatus.Created;
        }

        protected abstract bool run();
    }
}
