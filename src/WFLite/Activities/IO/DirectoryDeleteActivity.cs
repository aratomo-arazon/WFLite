/*
 * DirectoryDeleteActivity.cs
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
    public class DirectoryDeleteActivity : SyncActivity
    {
        public IOutVariable<string>? Path
        {
            private get;
            set;
        }

        public ICondition? Recursive
        {
            private get;
            set;
        }

        public DirectoryDeleteActivity()
        {
        }

        public DirectoryDeleteActivity(IOutVariable<string> path, ICondition? recursive = null)
        {
            Path = path;
            Recursive = recursive;
        }

        protected sealed override void initialize()
        {
            this.Require(Path, nameof(Path));
        }

        protected sealed override bool run()
        {
            var path = Path!.GetValue();
            if (path == null)
            {
                return false;
            }

            if (Recursive == null)
            {
                Directory.Delete(path);
            }
            else
            {
                Directory.Delete(path, Recursive.Check());
            }

            return true;
        }
    }
}
