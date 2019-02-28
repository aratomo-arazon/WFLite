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
using WFLite.Interfaces;

namespace WFLite.Activities.IO
{
    public class FileReadAllBytesActivity : SyncActivity
    {
        public IOutVariable<string> Path
        {
            private get;
            set;
        }

        public IInVariable<byte[]> Bytes
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

        protected sealed override bool run()
        {
            var path = Path.GetValue();

            Bytes.SetValue(File.ReadAllBytes(path));

            return true;
        }
    }
}
