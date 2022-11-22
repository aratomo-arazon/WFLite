/*
 * FileWriteAllTextActivity.cs
 *
 * Copyright (c) 2019 aratomo-arazon
 *
 * This software is released under the MIT License.
 * http://opensource.org/licenses/mit-license.php
 */

using System.IO;
using System.Text;
using WFLite.Bases;
using WFLite.Extensions;
using WFLite.Interfaces;

namespace WFLite.Activities.IO
{
    public class FileWriteAllTextActivity : SyncActivity
    {
        public IOutVariable<string>? Path
        {
            private get;
            set;
        }

        public IOutVariable<string>? Contents
        {
            private get;
            set;
        }
        
        public IOutVariable<Encoding>? Encoding
        {
            private get;
            set;
        }

        public FileWriteAllTextActivity()
        {
        }

        public FileWriteAllTextActivity(IOutVariable<string> path, IOutVariable<string> contents, IOutVariable<Encoding>? encoding = null)
        {
            Path = path;
            Contents = contents;
            Encoding = encoding;
        }

        protected sealed override void initialize()
        {
            this.Require(Path, nameof(Path));
            this.Require(Contents, nameof(Contents));
        }

        protected sealed override bool run()
        {
            var path = Path!.GetValue();
            var contents = Contents!.GetValue();
            if (string.IsNullOrEmpty(path) || contents == null)
            {
                return false;
            }

            if (Encoding == null)
            {
                File.WriteAllText(path, contents);
            }
            else
            {
                var encoding = Encoding.GetValue();
                if (encoding == null)
                {
                    File.WriteAllText(path, contents);
                }
                else
                {
                    File.WriteAllText(path, contents, encoding);
                }
            }

            return true;
        }
    }
}
