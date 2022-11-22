/*
 * FuncSyncActivity.cs
 *
 * Copyright (c) 2019 aratomo-arazon
 *
 * This software is released under the MIT License.
 * http://opensource.org/licenses/mit-license.php
 */

using System;
using WFLite.Bases;
using WFLite.Extensions;

namespace WFLite.Activities
{
    public class FuncSyncActivity : SyncActivity
    {
        public Func<bool>? Func
        {
            private get;
            set;
        }

        public FuncSyncActivity()
        {
        }

        public FuncSyncActivity(Func<bool> func)
        {
            Func = func;
        }

        protected sealed override void initialize()
        {
            this.Require(Func, nameof(Func));
        }

        protected sealed override bool run()
        {
            return Func!();
        }
    }
}
