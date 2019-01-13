/*
 * FileWriteAllBytesAsyncActivity.cs
 *
 * Copyright (c) 2019 aratomo-arazon
 *
 * This software is released under the MIT License.
 * http://opensource.org/licenses/mit-license.php
 */

using System.Threading;
using System.Threading.Tasks;
using WFLite.Interfaces;

namespace WFLite.Activities.File
{
    public class FileWriteAllBytesAsyncActivity : AsyncActivity
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

        protected sealed override async Task<bool> run(CancellationToken cancellationToken)
        {
            var path = Path.GetValue<string>();
            var bytes = Bytes.GetValue<byte[]>();

            await System.IO.File.WriteAllBytesAsync(path, bytes, cancellationToken);

            return true;
        }
    }
}
