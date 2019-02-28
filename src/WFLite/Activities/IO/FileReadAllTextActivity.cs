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
using WFLite.Bases;
using WFLite.Interfaces;

namespace WFLite.Activities.IO
{
    public class FileReadAllTextActivity : SyncActivity
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

        public FileReadAllTextActivity()
        {
        }

        public FileReadAllTextActivity(IOutVariable<string> path, IInVariable<string> contents, IOutVariable<Encoding> encoding = null)
        {
            Path = path;
            Contents = contents;
            Encoding = encoding;
        }

        protected sealed override bool run()
        {
            var path = Path.GetValue();

            if (Encoding == null)
            {
                Contents.SetValue(File.ReadAllText(path));
            }
            else
            {
                var encoding = Encoding.GetValue();

                Contents.SetValue(File.ReadAllText(path, encoding));
            }

            return true;
        }
    }
}
