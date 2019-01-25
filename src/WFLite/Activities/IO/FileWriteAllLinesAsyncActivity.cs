/*
 * FileWriteAllLinesAsyncActivity.cs
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
    public class FileWriteAllLinesAsyncActivity : AsyncActivity
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

        public FileWriteAllLinesAsyncActivity()
        {
        }

        public FileWriteAllLinesAsyncActivity(IVariable path, IVariable contents)
        {
            Path = path;
            Contents = contents;
        }

        protected sealed override async Task<bool> run(CancellationToken cancellationToken)
        {
            var path = Path.GetValue<string>();
            var contents = Contents.GetValue<string[]>();

            await File.WriteAllLinesAsync(path, contents, cancellationToken);

            return true;
        }
    }
}
