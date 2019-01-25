/*
 * FalseCondition.cs
 *
 * Copyright (c) 2019 aratomo-arazon
 *
 * This software is released under the MIT License.
 * http://opensource.org/licenses/mit-license.php
 */

using System;
using WFLite.Bases;
using WFLite.Interfaces;
using WFLite.Variables;

namespace WFLite.Conditions
{
    public class FalseCondition : Condition
    {
        public IVariable Value
        {
            private get;
            set;
        }

        public FalseCondition()
        {
        }

        public FalseCondition(IVariable value)
        {
            Value = value;
        }

        protected sealed override bool check()
        {
            if (Value == null)
            {
                return false;
            }

            return !Convert.ToBoolean(Value.GetValue());
        }
    }
}
