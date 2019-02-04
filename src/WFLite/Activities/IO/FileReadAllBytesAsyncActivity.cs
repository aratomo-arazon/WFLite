/*
 * FileReadAllBytesAsyncActivity.cs
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
    public class FileReadAllBytesAsyncActivity : AsyncActivity
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

        public FileReadAllBytesAsyncActivity()
        {
        }

        public FileReadAllBytesAsyncActivity(IOutVariable<string> path, IInVariable<byte[]> bytes)
        {
            Path = path;
            Bytes = bytes;
        }

        protected sealed override async Task<bool> run(CancellationToken cancellationToken)
        {
            var path = Path.GetValue();

            Bytes.SetValue(await File.ReadAllBytesAsync(path, cancellationToken));

            return true;
        }
    }
}
