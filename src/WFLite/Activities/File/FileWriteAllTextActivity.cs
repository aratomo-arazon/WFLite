/*
 * FileWriteAllTextActivity.cs
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
    public class FileWriteAllTextActivity : SyncActivity
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
            var contents = Contents.GetValue<string>();

            if (Encoding == null)
            {
                System.IO.File.WriteAllText(path, contents);
            }
            else
            {
                var encoding = Encoding.GetValue<Encoding>();

                System.IO.File.WriteAllText(path, contents, encoding);
            }

            return true;
        }
    }
}
