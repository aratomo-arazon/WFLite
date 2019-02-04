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
        public IOutVariable<string> Path
        {
            private get;
            set;
        }

        public IInVariable<string> Contents
        {
            private get;
            set;
        }

        public IOutVariable<Encoding> Encoding
        {
            private get;
            set;
        }

        public FileReadAllTextAsyncActivity()
        {
        }

        public FileReadAllTextAsyncActivity(IOutVariable<string> path, IInVariable<string> contents, IOutVariable<Encoding> encoding = null)
        {
            Path = path;
            Contents = contents;
            Encoding = encoding;
        }

        protected sealed override async Task<bool> run(CancellationToken cancellationToken)
        {
            var path = Path.GetValue();

            if (Encoding == null)
            {
                Contents.SetValue(await File.ReadAllTextAsync(path, cancellationToken));
            }
            else
            {
                var encoding = Encoding.GetValue();

                Contents.SetValue(await File.ReadAllTextAsync(path, encoding, cancellationToken));
            }

            return true;
        }
    }
}
