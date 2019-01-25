/*
 * DirectoryMoveActivity.cs
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
    public class DirectoryMoveActivity : SyncActivity
    {
        public IVariable SourceDirName
        {
            private get;
            set;
        }

        public IVariable DestDirName
        {
            private get;
            set;
        }

        public DirectoryMoveActivity()
        {
        }

        public DirectoryMoveActivity(IVariable sourceDirName, IVariable destDirName)
        {
            SourceDirName = sourceDirName;
            DestDirName = destDirName;
        }

        protected sealed override bool run()
        {
            var sourceDirName = SourceDirName.GetValue<string>();
            var destDirName = DestDirName.GetValue<string>();

            Directory.Move(sourceDirName, destDirName);

            return true;
        }
    }
}
