/*
 * TrueCondition.cs
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
    public class TrueCondition : Condition
    {
        public IOutVariable<bool>? Value
        {
            private get;
            set;
        }

        public TrueCondition()
        {
        }

        public TrueCondition(IOutVariable<bool>? value)
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
                return true;
            }

            return Value.GetValue();
        }
    }
}
