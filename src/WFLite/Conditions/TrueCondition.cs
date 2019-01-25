/*
 * TrueCondition.cs
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
    public class TrueCondition : Condition
    {
        public IVariable Value
        {
            private get;
            set;
        }

        public TrueCondition()
        {
        }

        public TrueCondition(IVariable value)
        {
            Value = value;
        }

        protected sealed override bool check()
        {
            if (Value == null)
            {
                return true;
            }

            return Convert.ToBoolean(Value.GetValue());
        }
    }
}
