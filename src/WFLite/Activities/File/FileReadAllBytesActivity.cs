/*
 * FileReadAllBytesActivity.cs
 *
 * Copyright (c) 2019 aratomo-arazon
 *
 * This software is released under the MIT License.
 * http://opensource.org/licenses/mit-license.php
 */

using WFLite.Interfaces;

namespace WFLite.Activities.File
{
    public class FileReadAllBytesActivity : SyncActivity
    {
        public IVariable Path
        {
            private get;
            set;
        }

        public IVariable Bytes
        {
            private get;
            set;
        }

        protected sealed override bool run()
        {
            var path = Path.GetValue<string>();

            Bytes.SetValue(System.IO.File.ReadAllBytes(path));

            return true;
        }
    }
}
