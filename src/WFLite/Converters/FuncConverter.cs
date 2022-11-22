/*
 * FuncConverter.cs
 *
 * Copyright (c) 2019 aratomo-arazon
 *
 * This software is released under the MIT License.
 * http://opensource.org/licenses/mit-license.php
 */

using System;
using WFLite.Extensions;

namespace WFLite.Converters
{
    public class FuncConverter : Bases.Converter
    {
        public Func<object?, object?>? Func
        {
            private get;
            set;
        }

        public FuncConverter()
        {
        }

        public FuncConverter(Func<object?, object?> func)
        {
            Func = func;
        }

        protected sealed override void initialize()
        {
            this.Require(Func, nameof(Func));
        }

        protected sealed override object? convert(object? value)
        {
            return Func!.Invoke(value);
        }
    }

    public class FuncConverter<TValue> : Bases.Converter<TValue>
    {
        public Func<object?, TValue>? Func
        {
            private get;
            set;
        }

        public FuncConverter()
        {
        }

        public FuncConverter(Func<object?, TValue> func)
        {
            Func = func;
        }

        protected sealed override void initialize()
        {
            this.Require(Func, nameof(Func));
        }

        protected sealed override TValue? convert(object? value)
        {
            return Func!(value);
        }
    }

    public class FuncConverter<TInValue, TOutValue> : Bases.Converter<TInValue, TOutValue>
    {
        public Func<TInValue, TOutValue>? Func
        {
            private get;
            set;
        }

        public FuncConverter()
        {
        }

        public FuncConverter(Func<TInValue, TOutValue> func)
        {
            Func = func;
        }

        protected sealed override void initialize()
        {
            this.Require(Func, nameof(Func));
        }

        protected sealed override TOutValue convert(TInValue? value)
        {
            return Func!(value!);
        }
    }
}
