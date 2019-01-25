/*
 * FileDeleteActivity.cs
 *
 * Copyright (c) 2019 aratomo-arazon
 *
 * This software is released under the MIT License.
 * http://opensource.org/licenses/mit-license.php
 */

using System.IO;
using WFLite.Interfaces;

namespace WFLite.Activities.IO
{
    public class FileDeleteActivity : SyncActivity
    {
        public IVariable Path
        {
            private get;
            set;
        }

        public FileDeleteActivity()
        {
        }

        public FileDeleteActivity(IVariable path)
        {
            Path = path;
        }

        protected sealed override bool run()
        {
            var path = Path.GetValue<string>();

            File.Delete(path);

            return true;
        }
    }
}
