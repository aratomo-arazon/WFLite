/*
 * ContainsCondition.cs
 *
 * Copyright (c) 2019 aratomo-arazon
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

        public ContainsCondition()
        {
        }

        public ContainsCondition(IVariable list, IVariable value)
        {
            List = list;
            Value = value;
        }

        protected sealed override bool check()
        {
            var list = List.GetValue() as IList<object>;

            return list.Contains(Value.GetValue());
        }
    }
}
