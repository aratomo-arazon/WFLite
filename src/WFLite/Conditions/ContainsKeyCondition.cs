/*
 * ContainsKeyCondition.cs
 *
 * Copyright (c) 2019 aratomo-arazon
 *
 * This software is released under the MIT License.
 * http://opensource.org/licenses/mit-license.php
 */

using System;
using System.Collections.Generic;
using WFLite.Bases;
using WFLite.Interfaces;

namespace WFLite.Conditions
{
    public class ContainsKeyCondition : Condition
    {
        public IVariable Dictionary
        {
            private get;
            set;
        }

        public IVariable Key
        {
            private get;
            set;
        }

        public ContainsKeyCondition()
        {
        }

        public ContainsKeyCondition(IVariable dictionary, IVariable key)
        {
            Dictionary = dictionary;
            Key = key;
        }

        protected sealed override bool check()
        {
            var dictionary = Dictionary.GetValue() as IDictionary<string, object>;

            return dictionary.ContainsKey(Convert.ToString(Key.GetValue()));
        }
    }
}
