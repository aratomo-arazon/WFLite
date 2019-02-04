/*
 * FileWriteAllBytesAsyncActivity.cs
 *
 * Copyright (c) 2019 aratomo-arazon
 *
 * This software is released under the MIT License.
 * http://opensource.org/licenses/mit-license.php
 */

using System.IO;
using System.Threading;
using System.Threading.Tasks;
using WFLite.Interfaces;

namespace WFLite.Activities.IO
{
    public class FileWriteAllBytesAsyncActivity : AsyncActivity
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

        public FileWriteAllBytesAsyncActivity()
        {
        }

        public FileWriteAllBytesAsyncActivity(IOutVariable<string> path, IOutVariable<byte[]> bytes)
        {
            Path = path;
            Bytes = bytes;
        }

        protected sealed override async Task<bool> run(CancellationToken cancellationToken)
        {
            var path = Path.GetValue();
            var bytes = Bytes.GetValue();

            await File.WriteAllBytesAsync(path, bytes, cancellationToken);

            return true;
        }
    }
}
