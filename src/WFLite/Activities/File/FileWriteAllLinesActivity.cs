/*
 * FileWriteAllLinesActivity.cs
 *
 * Copyright (c) 2019 aratomo-arazon
 *
 * This software is released under the MIT License.
 * http://opensource.org/licenses/mit-license.php
 */

using WFLite.Interfaces;

namespace WFLite.Activities.File
{
    public class FileWriteAllLinesActivity : SyncActivity
    {
        public IVariable Path
        {
            private get;
            set;
        }

        public IVariable Contents
        {
            private get;
            set;
        }

        protected sealed override bool run()
        {
            var path = Path.GetValue<string>();
            var contents = Contents.GetValue<string[]>();

            System.IO.File.WriteAllLines(path, contents);

            return true;
        }
    }
}
