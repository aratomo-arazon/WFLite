/*
 * FileWriteAllBytesActivity.cs
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
    public class FileWriteAllBytesActivity : SyncActivity
    {
        public IOutVariable<string>? Path
        {
            private get;
            set;
        }

        public IOutVariable<byte[]>? Bytes
        {
            private get;
            set;
        }

        public FileWriteAllBytesActivity()
        {
        }

        public FileWriteAllBytesActivity(IOutVariable<string> path, IOutVariable<byte[]> bytes)
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
            var bytes = Bytes!.GetValue();
            if (string.IsNullOrEmpty(path) || bytes == null)
            {
                return false;
            }

            File.WriteAllBytes(path, bytes);

            return true;
        }
    }
}
