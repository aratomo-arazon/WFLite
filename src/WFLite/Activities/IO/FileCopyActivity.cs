/*
 * FileCopyActivity.cs
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
    public class FileCopyActivity : SyncActivity
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

        public ICondition Overwrite
        {
            private get;
            set;
        }

        public FileCopyActivity()
        {
        }

        public FileCopyActivity(IOutVariable<string> sourceFileName, IOutVariable<string> destFileName, ICondition overwrite = null)
        {
            SourceFileName = sourceFileName;
            DestFileName = destFileName;
            Overwrite = overwrite;
        }

        protected sealed override bool run()
        {
            var sourceFileName = SourceFileName.GetValue();
            var destFileName = DestFileName.GetValue();

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
