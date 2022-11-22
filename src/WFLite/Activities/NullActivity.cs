/*
 * NullActivity.cs
 *
 * Copyright (c) 2019 aratomo-arazon
 *
 * This software is released under the MIT License.
 * http://opensource.org/licenses/mit-license.php
 */

using WFLite.Bases;

namespace WFLite.Activities
{
    public class NullActivity : SyncActivity
    {
        protected sealed override void initialize()
        {
        }

        protected sealed override bool run()
        {
            return true;
        }
    }
}
