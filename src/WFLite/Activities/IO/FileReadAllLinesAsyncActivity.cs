/*
 * FileReadAllLinesAsyncActivity.cs
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
    public class FileReadAllLinesAsyncActivity : AsyncActivity
    {
        public IOutVariable<string> Path
        {
            private get;
            set;
        }

        public IInVariable<string[]> Contents
        {
            private get;
            set;
        }

        public FileReadAllLinesAsyncActivity()
        {
        }

        public FileReadAllLinesAsyncActivity(IOutVariable<string> path, IInVariable<string[]> contents)
        {
            Path = path;
            Contents = contents;
        }

        protected sealed override async Task<bool> run(CancellationToken cancellationToken)
        {
            var path = Path.GetValue();

            Contents.SetValue(await File.ReadAllLinesAsync(path, cancellationToken));

            return true;
        }
    }
}
