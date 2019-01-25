/*
 * FileReadAllTextAsyncActivity.cs
 *
 * Copyright (c) 2019 aratomo-arazon
 *
 * This software is released under the MIT License.
 * http://opensource.org/licenses/mit-license.php
 */

using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WFLite.Interfaces;

namespace WFLite.Activities.IO
{
    public class FileReadAllTextAsyncActivity : AsyncActivity
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

        public IVariable Encoding
        {
            private get;
            set;
        }

        public FileReadAllTextAsyncActivity()
        {
        }

        public FileReadAllTextAsyncActivity(IVariable path, IVariable contents, IVariable encoding = null)
        {
            Path = path;
            Contents = contents;
            Encoding = encoding;
        }

        protected sealed override async Task<bool> run(CancellationToken cancellationToken)
        {
            var path = Path.GetValue<string>();

            if (Encoding == null)
            {
                Contents.SetValue(await File.ReadAllTextAsync(path, cancellationToken));
            }
            else
            {
                var encoding = Encoding.GetValue<Encoding>();

                Contents.SetValue(await File.ReadAllTextAsync(path, encoding, cancellationToken));
            }

            return true;
        }
    }
}
