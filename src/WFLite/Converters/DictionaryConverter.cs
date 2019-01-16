/*
 * DictionaryConverter.cs
 *
 * Copyright (c) 2019 aratomo-arazon
 *
 * This software is released under the MIT License.
 * http://opensource.org/licenses/mit-license.php
 */

using System.Collections.Generic;
using WFLite.Bases;

namespace WFLite.Converters
{
    public class DictionaryConverter : Converter
    {
        public IDictionary<object, object> Dictionary
        {
            private get;
            set;
        }

        public object Default
        {
            private get;
            set;
        }

        public DictionaryConverter()
        {
        }

        public DictionaryConverter(IDictionary<object, object> dictionary, object def)
        {
            Dictionary = dictionary;
            Default = def;
        }

        protected sealed override object convert(object value)
        {
            if (Dictionary.ContainsKey(value))
            {
                return Dictionary[value];
            }

            return Default;
        }
    }
}
