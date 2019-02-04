/*
 * LessThanCondition.cs
 *
 * Copyright (c) 2019 aratomo-arazon
 *
 * This software is released under the MIT License.
 * http://opensource.org/licenses/mit-license.php
 */

using System;
using WFLite.Bases;
using WFLite.Interfaces;

namespace WFLite.Conditions
{
    public class LessThanCondition : Condition
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

        public LessThanCondition()
        {
        }

        public LessThanCondition(IOutVariable value1, IOutVariable value2)
        {
            Value1 = value1;
            Value2 = value2;
        }

        protected sealed override bool check()
        {
            var value1 = Value1.GetValueAsObject() as IComparable;
            var value2 = Value2.GetValueAsObject() as IComparable;

            if (value1 == null || value2 == null)
            {
                return false;
            }

            return value1.CompareTo(value2) < 0;
        }
    }

    public class LessThanCondition<TValue> : Condition
        where TValue : IComparable
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

        public LessThanCondition()
        {
        }

        public LessThanCondition(IOutVariable<TValue> value1, IOutVariable<TValue> value2)
        {
            Value1 = value1;
            Value2 = value2;
        }

        protected sealed override bool check()
        {
            var value1 = Value1.GetValueAsObject() as IComparable;
            var value2 = Value2.GetValueAsObject() as IComparable;

            if (value1 == null || value2 == null)
            {
                return false;
            }

            return value1.CompareTo(value2) < 0;
        }
    }
}
