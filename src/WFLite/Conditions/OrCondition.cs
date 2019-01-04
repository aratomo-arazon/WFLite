/*
 * OrCondition.cs
 *
 * Copyright (c) 2019 Tomoharu Araki
 *
 * This software is released under the MIT License.
 * http://opensource.org/licenses/mit-license.php
 */

using System.Collections.Generic;
using System.Linq;
using WFLite.Bases;
using WFLite.Interfaces;

namespace WFLite.Conditions
{
    public class OrCondition : Condition
    {
        public IEnumerable<ICondition> Conditions
        {
            private get;
            set;
        }

        protected override bool check()
        {
            return Conditions.Any(c => c.Check());
        }
    }
}
