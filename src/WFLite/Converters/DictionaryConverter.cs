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
using WFLite.Extensions;

namespace WFLite.Converters
{
    public class DictionaryConverter : Converter
    {
        public IDictionary<object, object?>? Dictionary
        {
            private get;
            set;
        }

        public object? Default
        {
            private get;
            set;
        }

        public DictionaryConverter()
        {
        }

        public DictionaryConverter(IDictionary<object, object?> dictionary, object? default_)
        {
            Dictionary = dictionary;
            Default = default_;
        }

        protected sealed override void initialize()
        {
            this.Require(Dictionary, nameof(Dictionary));
            this.Require(Default, nameof(Default));
        }

        protected sealed override object? convert(object? value)
        {
            if (value == null)
            {
                return Default;
            }

            if (Dictionary!.ContainsKey(value))
            {
                return Dictionary[value];
            }

            return Default;
        }
    }

    public class DictionaryConverter<TValue> : Converter<TValue>
    {
        public IDictionary<object, TValue>? Dictionary
        {
            private get;
            set;
        }

        public TValue? Default
        {
            private get;
            set;
        }

        public DictionaryConverter()
        {
        }

        public DictionaryConverter(IDictionary<object, TValue> dictionary, TValue? default_)
        {
            Dictionary = dictionary;
            Default = default_;
        }

        protected sealed override void initialize()
        {
            this.Require(Dictionary, nameof(Dictionary));
            this.Require(Default, nameof(Default));
        }

        protected sealed override TValue? convert(object? value)
        {
            if (value == null)
            {
                return Default;
            }

            if (Dictionary!.ContainsKey(value))
            {
                return Dictionary[value];
            }

            return Default;
        }
    }

    public class DictionaryConverter<TInValue, TOutValue> : Converter<TInValue, TOutValue>
    {
        public IDictionary<TInValue, TOutValue>? Dictionary
        {
            private get;
            set;
        }

        public TOutValue? Default
        {
            private get;
            set;
        }

        public DictionaryConverter()
        {
        }

        public DictionaryConverter(IDictionary<TInValue, TOutValue> dictionary, TOutValue default_)
        {
            Dictionary = dictionary;
            Default = default_;
        }

        protected sealed override void initialize()
        {
            this.Require(Dictionary, nameof(Dictionary));
            this.Require(Default, nameof(Default));
        }

        protected sealed override TOutValue? convert(TInValue? value)
        {
            if (value == null)
            {
                return Default;
            }

            if (Dictionary!.ContainsKey(value!))
            {
                return Dictionary[value!];
            }

            return Default;
        }
    }
}
