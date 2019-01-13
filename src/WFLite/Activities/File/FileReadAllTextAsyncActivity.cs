/*
 * FileReadAllTextAsyncActivity.cs
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

        protected sealed override async Task<bool> run(CancellationToken cancellationToken)
        {
            var path = Path.GetValue<string>();

            if (Encoding == null)
            {
                Contents.SetValue(await System.IO.File.ReadAllTextAsync(path, cancellationToken));
            }
            else
            {
                var encoding = Encoding.GetValue<Encoding>();

                Contents.SetValue(await System.IO.File.ReadAllTextAsync(path, encoding, cancellationToken));
            }

            return true;
        }
    }
}
