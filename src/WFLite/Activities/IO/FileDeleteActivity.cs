/*
 * FileDeleteActivity.cs
 *
 * Copyright (c) 2019 aratomo-arazon
 *
 * This software is released under the MIT License.
 * http://opensource.org/licenses/mit-license.php
 */

using System.IO;
using WFLite.Bases;
using WFLite.Extensions;
using WFLite.Interfaces;

namespace WFLite.Activities.IO
{
    public class FileDeleteActivity : SyncActivity
    {
        public IOutVariable<string>? Path
        {
            private get;
            set;
        }

        public FileDeleteActivity()
        {
        }

        public FileDeleteActivity(IOutVariable<string>? path)
        {
            Path = path;
        }

        protected sealed override void initialize()
        {
            this.Require(Path, nameof(Path));
        }

        protected sealed override bool run()
        {
            var path = Path!.GetValue();
            if (string.IsNullOrEmpty(path))
            {
                return false;
            }

            File.Delete(path);

            return true;
        }
    }
}
