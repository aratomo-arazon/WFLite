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

        protected sealed override bool check()
        {
            return Value1.GetValue().Equals(Value2.GetValue());
        }
    }
}
