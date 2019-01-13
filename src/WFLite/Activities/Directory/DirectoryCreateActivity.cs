/*
 * DirectoryCreateActivity.cs
 *
 * Copyright (c) 2019 aratomo-arazon
 *
 * This software is released under the MIT License.
 * http://opensource.org/licenses/mit-license.php
 */

using WFLite.Interfaces;

namespace WFLite.Activities.Directory
{
    public class DirectoryCreateActivity : SyncActivity
    {
        public IVariable Path
        {
            private get;
            set;
        }

        protected sealed override bool run()
        {
            var path = Path.GetValue<string>();

            System.IO.Directory.CreateDirectory(path);

            return true;
        }
    }
}
