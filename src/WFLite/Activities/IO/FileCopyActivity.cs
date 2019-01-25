/*
 * FileCopyActivity.cs
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

        public FileCopyActivity()
        {
        }

        public FileCopyActivity(IVariable sourceFileName, IVariable destFileName, ICondition overwrite = null)
        {
            SourceFileName = sourceFileName;
            DestFileName = destFileName;
            Overwrite = overwrite;
        }

        protected sealed override bool run()
        {
            var sourceFileName = SourceFileName.GetValue<string>();
            var destFileName = DestFileName.GetValue<string>();

            if (Overwrite == null)
            {
                File.Copy(sourceFileName, destFileName);
            }
            else
            {
                File.Copy(sourceFileName, destFileName, Overwrite.Check());
            }

            return true;
        }
    }
}
