/*
 * ThrowActivity.cs
 *
 * Copyright (c) 2019 aratomo-arazon
 *
 * This software is released under the MIT License.
 * http://opensource.org/licenses/mit-license.php
 */

using System.Threading.Tasks;
using WFLite.Bases;
using WFLite.Enums;

namespace WFLite.Activities
{
    public class ThrowActivity : Activity
    {
        protected override void initialize()
        {
        }

        protected override async Task start()
        {
            await Task.CompletedTask;

            Status = ActivityStatus.Stopped;
        }

        protected override void stop()
        {
            Status = ActivityStatus.Stopped;
        }

        protected override void reset()
        {
            Status = ActivityStatus.Created;
        }
    }
}
