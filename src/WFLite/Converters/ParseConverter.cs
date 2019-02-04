/*
 * ParseConverter.cs
 *
 * Copyright (c) 2019 aratomo-arazon
 *
 * This software is released under the MIT License.
 * http://opensource.org/licenses/mit-license.php
 */

using System;
using System.Collections.Generic;

namespace WFLite.Converters
{
    public class ParseConverter<TOutValue> : Bases.Converter<string, TOutValue>
    {
        private static readonly IDictionary<Type, Func<string, object>> _funcs = new Dictionary<Type, Func<string, object>>()
        {
            { typeof(bool), (value) => bool.Parse(value) },
            { typeof(char), (value) => char.Parse(value) },
            { typeof(byte), (value) => byte.Parse(value) },
            { typeof(short), (value) => short.Parse(value) },
            { typeof(ushort), (value) => ushort.Parse(value) },
            { typeof(int), (value) => int.Parse(value) },
            { typeof(uint), (value) => uint.Parse(value) },
            { typeof(long), (value) => long.Parse(value) },
            { typeof(ulong), (value) => ulong.Parse(value) },
            { typeof(float), (value) => float.Parse(value) },
            { typeof(double), (value) => double.Parse(value) },
            { typeof(decimal), (value) => decimal.Parse(value) },
            { typeof(Guid), (value) => Guid.Parse(value) },
            { typeof(DateTime), (value) => DateTime.Parse(value) },
        };

        protected sealed override TOutValue convert(string value)
        {
            var type = typeof(TOutValue);

            if (_funcs.ContainsKey(type))
            {
                return (TOutValue)_funcs[type](value);
            }

            return default;
        }
    }
}
