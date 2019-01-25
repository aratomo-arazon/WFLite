/*
 * FileWriteAllTextAsyncActivity.cs
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
    public class FileWriteAllTextAsyncActivity : AsyncActivity
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

        public FileWriteAllTextAsyncActivity()
        {
        }

        public FileWriteAllTextAsyncActivity(IVariable path, IVariable contents, IVariable encoding = null)
        {
            Path = path;
            Contents = contents;
            Encoding = encoding;
        }

        protected sealed override async Task<bool> run(CancellationToken cancellationToken)
        {
            var path = Path.GetValue<string>();
            var contents = Contents.GetValue<string>();

            if (Encoding == null)
            {
                await File.WriteAllTextAsync(path, contents, cancellationToken);
            }
            else
            {
                var encoding = Encoding.GetValue<Encoding>();

                await File.WriteAllTextAsync(path, contents, encoding, cancellationToken);
            }

            return true;
        }
    }
}
