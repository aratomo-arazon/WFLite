﻿/*
 * FileReadAllLinesActivity.cs
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
    public class FileReadAllLinesActivity : SyncActivity
    {
        public IOutVariable<string>? Path
        {
            private get;
            set;
        }

        public IInVariable<string[]>? Contents
        {
            private get;
            set;
        }

        public FileReadAllLinesActivity()
        {
        }

        public FileReadAllLinesActivity(IOutVariable<string> path, IInVariable<string[]> contents)
        {
            Path = path;
            Contents = contents;
        }

        protected sealed override void initialize()
        {
            this.Require(Path, nameof(Path));
            this.Require(Contents, nameof(Contents));
        }

        protected sealed override bool run()
        {
            var path = Path!.GetValue();
            if (path == null)
            {
                return false;
            }

            Contents!.SetValue(File.ReadAllLines(path));

            return true;
        }
    }
}
