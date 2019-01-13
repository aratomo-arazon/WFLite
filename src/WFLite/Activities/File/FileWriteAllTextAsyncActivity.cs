/*
 * FileWriteAllTextAsyncActivity.cs
 *
 * Copyright (c) 2019 aratomo-arazon
 *
 * This software is released under the MIT License.
 * http://opensource.org/licenses/mit-license.php
 */

using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WFLite.Interfaces;

namespace WFLite.Activities.File
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


        protected sealed override async Task<bool> run(CancellationToken cancellationToken)
        {
            var path = Path.GetValue<string>();
            var contents = Contents.GetValue<string>();

            if (Encoding == null)
            {
                await System.IO.File.WriteAllTextAsync(path, contents, cancellationToken);
            }
            else
            {
                var encoding = Encoding.GetValue<Encoding>();

                await System.IO.File.WriteAllTextAsync(path, contents, encoding, cancellationToken);
            }

            return true;
        }
    }
}
