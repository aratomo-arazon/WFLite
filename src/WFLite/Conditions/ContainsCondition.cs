/*
 * ContainsCondition.cs
 *
 * Copyright (c) 2019 aratomo-arazon
 *
 * This software is released under the MIT License.
 * http://opensource.org/licenses/mit-license.php
 */

using System.Collections;
using System.Collections.Generic;
using WFLite.Bases;
using WFLite.Interfaces;

namespace WFLite.Conditions
{
    public class ContainsCondition : Condition
    {
        public IOutVariable<IEnumerable> Enumerable
        {
            private get;
            set;
        }

        public IOutVariable Value
        {
            private get;
            set;
        }

        public ContainsCondition()
        {
        }

        public ContainsCondition(IOutVariable<IEnumerable> enumerable, IOutVariable value)
        {
            Enumerable = enumerable;
            Value = value;
        }

        protected sealed override bool check()
        {
            var value = Value.GetValueAsObject();

            foreach (var item in Enumerable.GetValue())
            {
                if (value.Equals(item))
                {
                    return true;
                }
            }

            return false;
        }
    }

    public class ContainsCondition<TValue> : Condition
    {
        public IOutVariable<IEnumerable<TValue>> Enumerable
        {
            private get;
            set;
        }

        public IOutVariable<TValue> Value
        {
            private get;
            set;
        }

        public ContainsCondition()
        {
        }

        public ContainsCondition(IOutVariable<IEnumerable<TValue>> enumerable, IOutVariable<TValue> value)
        {
            Enumerable = enumerable;
            Value = value;
        }

        protected sealed override bool check()
        {
            var value = Value.GetValueAsObject();

            foreach (var item in Enumerable.GetValue())
            {
                if (value.Equals(item))
                {
                    return true;
                }
            }

            return false;
        }
    }

}
