/*
 * FileWriteAllLinesActivity.cs
 *
 * Copyright (c) 2019 aratomo-arazon
 *
 * This software is released under the MIT License.
 * http://opensource.org/licenses/mit-license.php
 */

using System.IO;
using WFLite.Bases;
using WFLite.Interfaces;

namespace WFLite.Activities.IO
{
    public class FileWriteAllLinesActivity : SyncActivity
    {
        public IOutVariable<string> Path
        {
            private get;
            set;
        }

        public IOutVariable<string[]> Contents
        {
            private get;
            set;
        }

        public FileWriteAllLinesActivity()
        {
        }

        public FileWriteAllLinesActivity(IOutVariable<string> path, IOutVariable<string[]> contents)
        {
            Path = path;
            Contents = contents;
        }

        protected sealed override bool run()
        {
            var path = Path.GetValue();
            var contents = Contents.GetValue();

            File.WriteAllLines(path, contents);

            return true;
        }
    }
}
