/*
 * FileWriteAllBytesActivity.cs
 *
 * Copyright (c) 2019 aratomo-arazon
 *
 * This software is released under the MIT License.
 * http://opensource.org/licenses/mit-license.php
 */

using WFLite.Interfaces;

namespace WFLite.Activities.File
{
    public class FileWriteAllBytesActivity : SyncActivity
    {
        public IVariable Path
        {
            private get;
            set;
        }

        public IVariable Bytes
        {
            private get;
            set;
        }

        public FileWriteAllBytesActivity()
        {
        }

        public FileWriteAllBytesActivity(IVariable path, IVariable bytes)
        {
            Path = path;
            Bytes = bytes;
        }

        protected sealed override bool run()
        {
            var path = Path.GetValue<string>();
            var bytes = Bytes.GetValue<byte[]>();

            System.IO.File.WriteAllBytes(path, bytes);

            return true;
        }
    }
}
