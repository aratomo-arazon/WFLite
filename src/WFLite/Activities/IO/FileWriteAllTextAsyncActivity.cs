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
        public IOutVariable<string> Path
        {
            private get;
            set;
        }

        public IOutVariable<string> Contents
        {
            private get;
            set;
        }
        
        public IOutVariable<Encoding> Encoding
        {
            private get;
            set;
        }

        public FileWriteAllTextAsyncActivity()
        {
        }

        public FileWriteAllTextAsyncActivity(IOutVariable<string> path, IOutVariable<string> contents, IOutVariable<Encoding> encoding = null)
        {
            Path = path;
            Contents = contents;
            Encoding = encoding;
        }

        protected sealed override async Task<bool> run(CancellationToken cancellationToken)
        {
            var path = Path.GetValue();
            var contents = Contents.GetValue();

            if (Encoding == null)
            {
                await File.WriteAllTextAsync(path, contents, cancellationToken);
            }
            else
            {
                var encoding = Encoding.GetValue();

                await File.WriteAllTextAsync(path, contents, encoding, cancellationToken);
            }

            return true;
        }
    }
}
