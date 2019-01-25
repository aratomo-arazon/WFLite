/*
 * FuncConverter.cs
 *
 * Copyright (c) 2019 aratomo-arazon
 *
 * This software is released under the MIT License.
 * http://opensource.org/licenses/mit-license.php
 */

using System;

namespace WFLite.Converters
{
    public class FuncConverter : Bases.Converter
    {
        public Func<object, object> Func
        {
            private get;
            set;
        }

        public FuncConverter(Func<object, object> func = null)
        {
            Func = func;
        }

        protected sealed override object convert(object value)
        {
            return Func?.Invoke(value);
        }
    }
}
