/*
 * NotNullCondition.cs
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
    public class NotNullCondition : Condition
    {
        public IVariable Value
        {
            private get;
            set;
        }

        public NotNullCondition()
        {
        }

        public NotNullCondition(IVariable value)
        {
            Value = value;
        }

        protected sealed override bool check()
        {
            return Value.GetValue() != null;
        }
    }
}
