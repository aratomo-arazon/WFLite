/*
 * FileReadAllLinesActivity.cs
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
    public class FileReadAllLinesActivity : SyncActivity
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

        public FileReadAllLinesActivity()
        {
        }

        public FileReadAllLinesActivity(IVariable path, IVariable contents)
        {
            Path = path;
            Contents = contents;
        }

        protected sealed override bool run()
        {
            var path = Path.GetValue<string>();

            Contents.SetValue(File.ReadAllLines(path));

            return true;
        }
    }
}
