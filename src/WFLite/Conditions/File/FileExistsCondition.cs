/*
 * FileExistsCondition.cs
 *
 * Copyright (c) 2019 aratomo-arazon
 *
 * This software is released under the MIT License.
 * http://opensource.org/licenses/mit-license.php
 */

using WFLite.Bases;
using WFLite.Interfaces;

namespace WFLite.Conditions.File
{
    public class FileExistsCondition : Condition
    {
        public IVariable Path
        {
            private get;
            set;
        }

        protected sealed override bool check()
        {
            var path = Path.GetValue<string>();

            return System.IO.File.Exists(path);
        }
    }
}
