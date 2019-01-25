/*
 * FileReadAllTextActivity.cs
 *
 * Copyright (c) 2019 aratomo-arazon
 *
 * This software is released under the MIT License.
 * http://opensource.org/licenses/mit-license.php
 */

using System.IO;
using System.Text;
using WFLite.Interfaces;

namespace WFLite.Activities.IO
{
    public class FileReadAllTextActivity : SyncActivity
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

        public FileReadAllTextActivity()
        {
        }

        public FileReadAllTextActivity(IVariable path, IVariable contents, IVariable encoding = null)
        {
            Path = path;
            Contents = contents;
            Encoding = encoding;
        }

        protected sealed override bool run()
        {
            var path = Path.GetValue<string>();

            if (Encoding == null)
            {
                Contents.SetValue(File.ReadAllText(path));
            }
            else
            {
                var encoding = Encoding.GetValue<Encoding>();

                Contents.SetValue(File.ReadAllText(path, encoding));
            }

            return true;
        }
    }
}
