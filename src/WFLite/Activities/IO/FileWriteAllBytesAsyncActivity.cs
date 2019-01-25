﻿/*
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

        public FileWriteAllBytesAsyncActivity()
        {
        }

        public FileWriteAllBytesAsyncActivity(IVariable path, IVariable bytes)
        {
            Path = path;
            Bytes = bytes;
        }

        protected sealed override async Task<bool> run(CancellationToken cancellationToken)
        {
            var path = Path.GetValue<string>();
            var bytes = Bytes.GetValue<byte[]>();

            await File.WriteAllBytesAsync(path, bytes, cancellationToken);

            return true;
        }
    }
}