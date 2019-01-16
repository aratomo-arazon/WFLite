/*
 * FileReadAllLinesAsyncActivity.cs
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
    public class FileReadAllLinesAsyncActivity : AsyncActivity
    {
        public IVariable Path
        {
            private get;
            set;
        }

        public IVariable Contents
        {
            private get;
            set;
        }

        public FileReadAllLinesAsyncActivity()
        {
        }

        public FileReadAllLinesAsyncActivity(IVariable path, IVariable contents)
        {
            Path = path;
            Contents = contents;
        }

        protected sealed override async Task<bool> run(CancellationToken cancellationToken)
        {
            var path = Path.GetValue<string>();

            Contents.SetValue(await System.IO.File.ReadAllLinesAsync(path, cancellationToken));

            return true;
        }
    }
}
