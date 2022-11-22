/*
 * DirectoryMoveActivity.cs
 *
 * Copyright (c) 2019 aratomo-arazon
 *
 * This software is released under the MIT License.
 * http://opensource.org/licenses/mit-license.php
 */

using System.IO;
using WFLite.Bases;
using WFLite.Extensions;
using WFLite.Interfaces;

namespace WFLite.Activities.IO
{
    public class DirectoryMoveActivity : SyncActivity
    {
        public IOutVariable<string>? SourceDirName
        {
            private get;
            set;
        }

        public IOutVariable<string>? DestDirName
        {
            private get;
            set;
        }

        public DirectoryMoveActivity()
        {
        }

        public DirectoryMoveActivity(IOutVariable<string> sourceDirName, IOutVariable<string> destDirName)
        {
            SourceDirName = sourceDirName;
            DestDirName = destDirName;
        }

        protected sealed override void initialize()
        {
            this.Require(SourceDirName, nameof(SourceDirName));
            this.Require(DestDirName, nameof(DestDirName));
        }

        protected sealed override bool run()
        {
            var sourceDirName = SourceDirName!.GetValue();
            var destDirName = DestDirName!.GetValue();
            if (string.IsNullOrEmpty(sourceDirName) || string.IsNullOrEmpty(destDirName))
            {
                return false;
            }

            Directory.Move(sourceDirName, destDirName);

            return true;
        }
    }
}
