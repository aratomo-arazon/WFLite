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
            if (Value == null)
            {
                Value = new AnyVariable(true);
            }
        }

        public FalseCondition(IVariable value)
        {
            Value = value;
            
            if (Value == null)
            {
                Value = new AnyVariable(true);
            }
        }

        protected sealed override bool check()
        {
            return !Convert.ToBoolean(Value.GetValue());
        }
    }
}
