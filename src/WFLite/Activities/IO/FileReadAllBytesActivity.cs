/*
 * FileReadAllBytesActivity.cs
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
    public class FileReadAllBytesActivity : SyncActivity
    {
        public IOutVariable<string>? Path
        {
            private get;
            set;
        }

        public IInVariable<byte[]>? Bytes
        {
            private get;
            set;
        }

        public FileReadAllBytesActivity()
        {
        }

        public FileReadAllBytesActivity(IOutVariable<string> path, IInVariable<byte[]> bytes)
        {
            Path = path;
            Bytes = bytes;
        }

        protected sealed override void initialize()
        {
            this.Require(Path, nameof(Path));
            this.Require(Bytes, nameof(Bytes));
        }

        protected sealed override bool run()
        {
            var path = Path!.GetValue();
            if (string.IsNullOrEmpty(path))
            {
                return false;
            }

            Bytes!.SetValue(File.ReadAllBytes(path));

            return true;
        }
    }
}
