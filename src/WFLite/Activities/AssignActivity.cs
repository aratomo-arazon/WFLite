/*
 * AssignActivity.cs
 *
 * Copyright (c) 2019 Tomoharu Araki
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
    public class AssignActivity : Activity
    {
        public IVariable To
        {
            private get;
            set;
        }

        public IVariable Value
        {
            private get;
            set;
        }

        protected override void initialize()
        {
        }

        protected override async Task start()
        {
            To.SetValue(Value.GetValue());

            await Task.CompletedTask;

            Status = ActivityStatus.Completed;
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
