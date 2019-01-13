/*
 * DirectoryDeleteActivity.cs
 *
 * Copyright (c) 2019 aratomo-arazon
 *
 * This software is released under the MIT License.
 * http://opensource.org/licenses/mit-license.php
 */

using WFLite.Interfaces;

namespace WFLite.Activities.Directory
{
    public class DirectoryDeleteActivity : SyncActivity
    {
        public IVariable Path
        {
            private get;
            set;
        }

        public ICondition Recursive
        {
            private get;
            set;
        }

        protected sealed override bool run()
        {
            var path = Path.GetValue<string>();

            if (Recursive == null)
            {
                System.IO.Directory.Delete(path);
            }
            else
            {
                System.IO.Directory.Delete(path, Recursive.Check());
            }

            return true;
        }
    }
}
