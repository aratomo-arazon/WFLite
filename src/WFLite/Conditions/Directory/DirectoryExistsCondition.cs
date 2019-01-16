/*
 * DirectoryExistsCondition.cs
 *
 * Copyright (c) 2019 aratomo-arazon
 *
 * This software is released under the MIT License.
 * http://opensource.org/licenses/mit-license.php
 */

using WFLite.Bases;
using WFLite.Interfaces;

namespace WFLite.Conditions.Directory
{
    public class DirectoryExistsCondition : Condition
    {
        public IVariable Path
        {
            private get;
            set;
        }

        public DirectoryExistsCondition()
        {
        }

        public DirectoryExistsCondition(IVariable path)
        {
            Path = path;
        }

        protected sealed override bool check()
        {
            var path = Path.GetValue<string>();

            return System.IO.Directory.Exists(path);
        }
    }
}
