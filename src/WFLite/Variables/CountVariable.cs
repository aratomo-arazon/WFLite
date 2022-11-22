/*
 * CountVariable.cs
 *
 * Copyright (c) 2019 aratomo-arazon
 *
 * This software is released under the MIT License.
 * http://opensource.org/licenses/mit-license.php
 */

using System.Collections;
using System.Collections.Generic;
using System.Linq;
using WFLite.Bases;
using WFLite.Extensions;
using WFLite.Interfaces;

namespace WFLite.Variables
{
    public class CountVariable : OutVariable<int>
    { 
        public IOutVariable<IEnumerable>? Enumerable
        {
            private get;
            set;
        }

        public CountVariable()
        {
        }

        public CountVariable(IOutVariable<IEnumerable> collection)
        {
            Enumerable = collection;
        }

        protected sealed override void initialize()
        {
            this.Require(Enumerable, nameof(Enumerable));
        }

        protected sealed override object getValue()
        {
            var value = Enumerable!.GetValue();

            var count = 0;
            var enumerator = value!.GetEnumerator();
            checked
            {
                while (enumerator.MoveNext())
                {
                    count++;
                }
            }
            return count;
        }
    }

    public class CountVariable<TValue> : OutVariable<int>
    {
        public IOutVariable<IEnumerable<TValue>>? Enumerable
        {
            private get;
            set;
        }

        public CountVariable()
        {
        }

        public CountVariable(IOutVariable<IEnumerable<TValue>> enumerable)
        {
            Enumerable = enumerable;
        }

        protected sealed override void initialize()
        {
            this.Require(Enumerable, nameof(Enumerable));
        }

        protected sealed override object? getValue()
        {
            var value = Enumerable!.GetValue();
            if (value == null)
            {
                return null;
            }

            return value.Count();
        }
    }
}
