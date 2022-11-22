/*
 * GreaterThanCondition.cs
 *
 * Copyright (c) 2019 aratomo-arazon
 *
 * This software is released under the MIT License.
 * http://opensource.org/licenses/mit-license.php
 */

using System;
using WFLite.Bases;
using WFLite.Extensions;
using WFLite.Interfaces;

namespace WFLite.Conditions
{
    public class GreaterThanCondition : Condition
    {
        public IOutVariable? Value1
        {
            private get;
            set;
        }

        public IOutVariable? Value2
        {
            private get;
            set;
        }

        public GreaterThanCondition()
        {
        }

        public GreaterThanCondition(IOutVariable value1, IOutVariable value2)
        {
            Value1 = value1;
            Value2 = value2;
        }

        protected sealed override void initialize()
        {
            this.Require(Value1, nameof(Value1));
            this.Require(Value2, nameof(Value2));
        }

        protected sealed override bool check()
        {
            var value1 = Value1!.GetValueAsObject() as IComparable;
            var value2 = Value2!.GetValueAsObject() as IComparable;

            if (value1 == null || value2 == null)
            {
                return false;
            }

            return value1.CompareTo(value2) > 0;
        }
    }

    public class GreaterThanCondition<TValue> : Condition
        where TValue : IComparable
    {
        public IOutVariable<TValue>? Value1
        {
            private get;
            set;
        }

        public IOutVariable<TValue>? Value2
        {
            private get;
            set;
        }

        public GreaterThanCondition()
        {
        }

        public GreaterThanCondition(IOutVariable<TValue> value1, IOutVariable<TValue> value2)
        {
            Value1 = value1;
            Value2 = value2;
        }

        protected sealed override void initialize()
        {
            this.Require(Value1, nameof(Value1));
            this.Require(Value2, nameof(Value2));
        }

        protected sealed override bool check()
        {
            var value1 = Value1!.GetValueAsObject() as IComparable;
            var value2 = Value2!.GetValueAsObject() as IComparable;

            if (value1 == null || value2 == null)
            {
                return false;
            }

            return value1.CompareTo(value2) > 0;
        }
    }
}
