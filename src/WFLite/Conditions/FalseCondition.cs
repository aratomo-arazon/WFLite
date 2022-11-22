/*
 * FalseCondition.cs
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
    public class FalseCondition : Condition
    {
        public IOutVariable<bool>? Value
        {
            private get;
            set;
        }

        public FalseCondition()
        {
        }

        public FalseCondition(IOutVariable<bool> value)
        {
            Value = value;
        }

        protected sealed override void initialize()
        {
        }

        protected sealed override bool check()
        {
            if (Value == null)
            {
                return false;
            }

            return !Value.GetValue();
        }
    }
}
