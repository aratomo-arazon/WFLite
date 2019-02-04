/*
 * FileWriteAllBytesActivity.cs
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
    public class FileWriteAllBytesActivity : SyncActivity
    {
        public IOutVariable<string> Path
        {
            private get;
            set;
        }

        public IOutVariable<byte[]> Bytes
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

        protected sealed override bool run()
        {
            var path = Path.GetValue();
            var bytes = Bytes.GetValue();

            File.WriteAllBytes(path, bytes);

            return true;
        }
    }
}
