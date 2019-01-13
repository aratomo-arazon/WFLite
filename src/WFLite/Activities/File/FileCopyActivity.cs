/*
 * FileCopyActivity.cs
 *
 * Copyright (c) 2019 aratomo-arazon
 *
 * This software is released under the MIT License.
 * http://opensource.org/licenses/mit-license.php
 */

using WFLite.Interfaces;

namespace WFLite.Activities.File
{
    public class FileCopyActivity : SyncActivity
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

        public ICondition Overwrite
        {
            private get;
            set;
        }

        protected sealed override bool run()
        {
            var sourceFileName = SourceFileName.GetValue<string>();
            var destFileName = DestFileName.GetValue<string>();

            if (Overwrite == null)
            {
                System.IO.File.Copy(sourceFileName, destFileName);
            }
            else
            {
                System.IO.File.Copy(sourceFileName, destFileName, Overwrite.Check());
            }

            return true;
        }
    }
}
