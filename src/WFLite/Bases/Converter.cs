/*
 * Converter.cs
 *
 * Copyright (c) 2019 aratomo-arazon
 *
 * This software is released under the MIT License.
 * http://opensource.org/licenses/mit-license.php
 */

using System.ComponentModel.Design;
using WFLite.Interfaces;

namespace WFLite.Bases
{
    public abstract class Converter : IConverter
    {
        public object? ConvertToObject(object? value)
        {
            initialize();
            return convert(value);
        }

        protected virtual void initialize()
        {
        }

        protected abstract object? convert(object? value);
    }

    public abstract class Converter<TValue> : IConverter<TValue>
    {
        public object? ConvertToObject(object? value)
        {
            initialize();
            return convert(value);
        }

        public TValue? Convert(object? value)
        {
            initialize();
            return convert(value);
        }

        protected virtual void initialize()
        {
        }

        protected abstract TValue? convert(object? value);
    }

    public abstract class Converter<TInValue, TOutValue> : IConverter<TInValue, TOutValue>
    {
        public object? ConvertToObject(object? value)
        {
            initialize();
            return convert((TInValue?)value);
        }

        public TOutValue? Convert(object? value)
        {
            initialize();
            return convert((TInValue?)value);
        }

        public TOutValue? Convert(TInValue? value)
        {
            initialize();
            return convert(value);
        }

        protected virtual void initialize()
        {
        }

        protected abstract TOutValue? convert(TInValue? value);
    }
}
