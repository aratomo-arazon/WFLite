﻿/*
 * FileMoveActivity.cs
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
    public class FileMoveActivity : SyncActivity
    {
        public IOutVariable<string>? SourceFileName
        {
            private get;
            set;
        }

        public IOutVariable<string>? DestFileName
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

        protected sealed override void initialize()
        {
            this.Require(SourceFileName, nameof(SourceFileName));
            this.Require(DestFileName, nameof(DestFileName));
        }

        protected sealed override bool run()
        {
            var sourceFileName = SourceFileName!.GetValue();
            var destFileName = DestFileName!.GetValue();
            if (string.IsNullOrEmpty(sourceFileName) || string.IsNullOrEmpty(destFileName))
            {
                return false;
            }

            File.Move(sourceFileName, destFileName);

            return true;
        }
    }
}
