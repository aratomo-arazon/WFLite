/*
 * ContainsCondition.cs
 *
 * Copyright (c) 2019 Tomoharu Araki
 *
 * This software is released under the MIT License.
 * http://opensource.org/licenses/mit-license.php
 */

using System.Collections.Generic;
using WFLite.Bases;
using WFLite.Interfaces;

namespace WFLite.Conditions
{
    public class ContainsCondition : Condition
    {
        public IVariable List
        {
            private get;
            set;
        }

        public IVariable Value
        {
            private get;
            set;
        }

        protected override bool check()
        {
            var list = List.GetValue() as IList<object>;

            return list.Contains(Value.GetValue());
        }
    }
}
