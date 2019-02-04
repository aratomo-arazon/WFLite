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
        public IOutVariable Value1
        {
            private get;
            set;
        }

        public IOutVariable Value2
        {
            private get;
            set;
        }

        public EqualsCondition()
        {
        }

        public EqualsCondition(IOutVariable value1, IOutVariable value2)
        {
            Value1 = value1;
            Value2 = value2;
        }

        protected sealed override bool check()
        {
            return Value1.GetValueAsObject().Equals(Value2.GetValueAsObject());
        }
    }

    public class EqualsCondition<TValue> : Condition
    {
        public IOutVariable<TValue> Value1
        {
            private get;
            set;
        }

        public IOutVariable<TValue> Value2
        {
            private get;
            set;
        }

        public EqualsCondition()
        {
        }

        public EqualsCondition(IOutVariable<TValue> value1, IOutVariable<TValue> value2)
        {
            Value1 = value1;
            Value2 = value2;
        }

        protected sealed override bool check()
        {
            return Value1.GetValueAsObject().Equals(Value2.GetValueAsObject());
        }
    }
}
