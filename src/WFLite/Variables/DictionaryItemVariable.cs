/*
 * DictionaryItemVariable.cs
 *
 * Copyright (c) 2019 Tomoharu Araki
 *
 * This software is released under the MIT License.
 * http://opensource.org/licenses/mit-license.php
 */

using System;
using System.Collections.Generic;
using WFLite.Bases;
using WFLite.Interfaces;

namespace WFLite.Variables
{
    public class DictionaryItemVariable : Variable
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

        protected override object getValue()
        {
            var dictionary = Dictionary.GetValue() as IDictionary<string, object>;
            var key = Convert.ToString(Key.GetValue());
            return dictionary[key];
        }

        protected override void setValue(object value)
        {
            var dictionary = Dictionary.GetValue() as IDictionary<string, object>;
            var key = Convert.ToString(Key.GetValue());
            dictionary[key] = value;
        }
    }
}
