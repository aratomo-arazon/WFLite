/*
 * FileMoveActivity.cs
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
    public class FileMoveActivity : SyncActivity
    {
        public IOutVariable<string> SourceFileName
        {
            private get;
            set;
        }

        public IOutVariable<string> DestFileName
        {
            private get;
            set;
        }

        public FileMoveActivity()
        {
        }

        public FileMoveActivity(IOutVariable<string> sourceFileName, IOutVariable<string> destFileName)
        {
            SourceFileName = sourceFileName;
            DestFileName = destFileName;
        }

        protected sealed override bool run()
        {
            var sourceFileName = SourceFileName.GetValue();
            var destFileName = DestFileName.GetValue();

            File.Move(sourceFileName, destFileName);

            return true;
        }
    }
}
