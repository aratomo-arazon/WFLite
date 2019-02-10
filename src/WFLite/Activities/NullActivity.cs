/*
 * NullActivity.cs
 *
 * Copyright (c) 2019 aratomo-arazon
 *
 * This software is released under the MIT License.
 * http://opensource.org/licenses/mit-license.php
 */

namespace WFLite.Activities
{
    public class NullActivity : SyncActivity
    {
        protected sealed override bool run()
        {
            return true;
        }
    }
}
