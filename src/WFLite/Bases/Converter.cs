/*
 * Converter.cs
 *
 * Copyright (c) 2019 aratomo-arazon
 *
 * This software is released under the MIT License.
 * http://opensource.org/licenses/mit-license.php
 */

using WFLite.Interfaces;

namespace WFLite.Bases
{
    public abstract class Converter : IConverter
    {
        public object ConvertToObject(object value)
        {
            return convert(value);
        }

        protected abstract object convert(object value);
    }

    public abstract class Converter<TValue> : IConverter<TValue>
    {
        public object ConvertToObject(object value)
        {
            return convert(value);
        }

        public TValue Convert(object value)
        {
            return convert(value);
        }

        protected abstract TValue convert(object value);
    }

    public abstract class Converter<TInValue, TOutValue> : IConverter<TInValue, TOutValue>
    {
        public object ConvertToObject(object value)
        {
            return convert((TInValue)value);
        }

        public TOutValue Convert(object value)
        {
            return convert((TInValue)value);
        }

        public TOutValue Convert(TInValue value)
        {
            return convert(value);
        }

        protected abstract TOutValue convert(TInValue value);
    }
}
