/*
 * SyncActivity.cs
 *
 * Copyright (c) 2019 Tomoharu Araki
 *
 * This software is released under the MIT License.
 * http://opensource.org/licenses/mit-license.php
 */

using System;
using System.Threading.Tasks;
using WFLite.Bases;
using WFLite.Enums;

namespace WFLite.Activities
{
    public class SyncActivity : Activity
    {
        public Func<bool> Func
        {
            private get;
            set;
        }

        protected override void initialize()
        {
        }

        protected override async Task start()
        {
            await Task.CompletedTask;

            var result = Func();

            if (result)
            {
                Status = ActivityStatus.Completed;
            }
            else
            {
                Status = ActivityStatus.Stopped;
            }
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
