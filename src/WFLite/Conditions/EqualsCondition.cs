/*
 * EqualsCondition.cs
 *
 * Copyright (c) 2019 aratomo-arazon
 *
 * This software is released under the MIT License.
 * http://opensource.org/licenses/mit-license.php
 */

using WFLite.Bases;
using WFLite.Interfaces;

namespace WFLite.Conditions
{
    public class EqualsCondition : Condition
    {
        public IVariable Value1
        {
            private get;
            set;
        }

        public IVariable Value2
        {
            private get;
            set;
        }

        public EqualsCondition()
        {
        }

        public EqualsCondition(IVariable value1, IVariable value2)
        {
            Value1 = value1;
            Value2 = value2;
        }

        protected sealed override bool check()
        {
            return Value1.GetValue().Equals(Value2.GetValue());
        }
    }
}
