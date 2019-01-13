/*
 * FileReadAllTextActivity.cs
 *
 * Copyright (c) 2019 aratomo-arazon
 *
 * This software is released under the MIT License.
 * http://opensource.org/licenses/mit-license.php
 */

using System.Text;
using WFLite.Interfaces;

namespace WFLite.Activities.File
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

        protected sealed override bool run()
        {
            var path = Path.GetValue<string>();

            if (Encoding == null)
            {
                Contents.SetValue(System.IO.File.ReadAllText(path));
            }
            else
            {
                var encoding = Encoding.GetValue<Encoding>();

                Contents.SetValue(System.IO.File.ReadAllText(path, encoding));
            }

            return true;
        }
    }
}
