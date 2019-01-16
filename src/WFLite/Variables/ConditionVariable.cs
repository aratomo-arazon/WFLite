/*
 * ConditionVariable.cs
 *
 * Copyright (c) 2019 aratomo-arazon
 *
 * This software is released under the MIT License.
 * http://opensource.org/licenses/mit-license.php
 */

using System;
using WFLite.Bases;
using WFLite.Interfaces;

namespace WFLite.Variables
{
    public class ConditionVariable : Variable
    {
        public ICondition Condition
        {
            private get;
            set;
        }

        public ConditionVariable()
        {
        }

        public ConditionVariable(ICondition condition)
        {
            Condition = condition;
        }

        protected sealed override object getValue()
        {
            return Condition.Check();
        }

        protected sealed override void setValue(object value)
        {
            throw new NotSupportedException();
        }
    }
}
