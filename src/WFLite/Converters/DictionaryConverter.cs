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

        public DictionaryConverter(IDictionary<object, object> dictionary, object default_ = null)
        {
            Dictionary = dictionary;
            Default = default_;
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

    public class DictionaryConverter<TValue> : Converter<TValue>
    {
        public IDictionary<object, TValue> Dictionary
        {
            private get;
            set;
        }

        public TValue Default
        {
            private get;
            set;
        }

        public DictionaryConverter()
        {
        }

        public DictionaryConverter(IDictionary<object, TValue> dictionary, TValue default_ = default)
        {
            Dictionary = dictionary;
            Default = default_;
        }

        protected sealed override TValue convert(object value)
        {
            if (Dictionary.ContainsKey(value))
            {
                return Dictionary[value];
            }

            return Default;
        }
    }

    public class DictionaryConverter<TInValue, TOutValue> : Converter<TInValue, TOutValue>
    {
        public IDictionary<TInValue, TOutValue> Dictionary
        {
            private get;
            set;
        }

        public TOutValue Default
        {
            private get;
            set;
        }

        public DictionaryConverter()
        {
        }

        public DictionaryConverter(IDictionary<TInValue, TOutValue> dictionary, TOutValue default_ = default)
        {
            Dictionary = dictionary;
            Default = default_;
        }

        protected sealed override TOutValue convert(TInValue value)
        {
            if (Dictionary.ContainsKey(value))
            {
                return Dictionary[value];
            }

            return Default;
        }
    }
}
