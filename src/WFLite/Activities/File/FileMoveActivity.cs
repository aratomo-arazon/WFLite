/*
 * FileMoveActivity.cs
 *
 * Copyright (c) 2019 aratomo-arazon
 *
 * This software is released under the MIT License.
 * http://opensource.org/licenses/mit-license.php
 */

using WFLite.Interfaces;

namespace WFLite.Activities.File
{
    public class FileMoveActivity : SyncActivity
    {
        public IVariable SourceFileName
        {
            private get;
            set;
        }

        public IVariable DestFileName
        {
            private get;
            set;
        }

        public FileMoveActivity()
        {
        }

        public FileMoveActivity(IVariable sourceFileName, IVariable destFileName)
        {
            SourceFileName = sourceFileName;
            DestFileName = destFileName;
        }

        protected sealed override bool run()
        {
            var sourceFileName = SourceFileName.GetValue<string>();
            var destFileName = DestFileName.GetValue<string>();

            System.IO.File.Move(sourceFileName, destFileName);

            return true;
        }
    }
}
