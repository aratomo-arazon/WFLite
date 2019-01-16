/*
 * DirectoryMoveActivity.cs
 *
 * Copyright (c) 2019 aratomo-arazon
 *
 * This software is released under the MIT License.
 * http://opensource.org/licenses/mit-license.php
 */

using WFLite.Interfaces;

namespace WFLite.Activities.Directory
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

            System.IO.Directory.Move(sourceDirName, destDirName);

            return true;
        }
    }
}
