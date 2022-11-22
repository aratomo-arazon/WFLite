/*
 * FileExistsCondition.cs
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

namespace WFLite.Conditions.IO
{
    public class FileExistsCondition : Condition
    {
        public IOutVariable<string>? Path
        {
            private get;
            set;
        }

        public FileExistsCondition()
        {
        }

        public FileExistsCondition(IOutVariable<string> path)
        {
            Path = path;
        }

        protected sealed override void initialize()
        {
            this.Require(Path, nameof(Path));
        }

        protected sealed override bool check()
        {
            var path = Path!.GetValue();

            return File.Exists(path);
        }
    }
}
