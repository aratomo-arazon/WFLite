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
using WFLite.Interfaces;

namespace WFLite.Conditions.IO
{
    public class FileExistsCondition : Condition
    {
        public IVariable Path
        {
            private get;
            set;
        }

        public FileExistsCondition()
        {
        }

        public FileExistsCondition(IVariable path)
        {
            Path = path;
        }

        protected sealed override bool check()
        {
            var path = Path.GetValue<string>();

            return File.Exists(path);
        }
    }
}
