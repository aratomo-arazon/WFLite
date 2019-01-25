/*
 * FileWriteAllLinesActivity.cs
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

        public FileWriteAllLinesActivity()
        {
        }

        public FileWriteAllLinesActivity(IVariable path, IVariable contents)
        {
            Path = path;
            Contents = contents;
        }

        protected sealed override bool run()
        {
            var path = Path.GetValue<string>();
            var contents = Contents.GetValue<string[]>();

            File.WriteAllLines(path, contents);

            return true;
        }
    }
}
