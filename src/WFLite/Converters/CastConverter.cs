/*
 * CastConverter.cs
 *
 * Copyright (c) 2019 aratomo-arazon
 *
 * This software is released under the MIT License.
 * http://opensource.org/licenses/mit-license.php
 */

using System;
using System.Collections.Generic;
using WFLite.Bases;

namespace WFLite.Converters
{
    public class CastConverter<TValue> : Converter
    {
        private static readonly Dictionary<Type, Func<object, object>> _funcs = new Dictionary<Type, Func<object, object>>()
        {
            { typeof(bool), (value) => System.Convert.ToBoolean(value) },
            { typeof(char), (value) => System.Convert.ToChar(value) },
            { typeof(byte), (value) => System.Convert.ToByte(value) },
            { typeof(short), (value) => System.Convert.ToInt16(value) },
            { typeof(ushort), (value) => System.Convert.ToUInt16(value) },
            { typeof(int), (value) => System.Convert.ToInt32(value) },
            { typeof(uint), (value) => System.Convert.ToUInt32(value) },
            { typeof(long), (value) => System.Convert.ToInt64(value) },
            { typeof(ulong), (value) => System.Convert.ToUInt64(value) },
            { typeof(float), (value) => System.Convert.ToSingle(value) },
            { typeof(double), (value) => System.Convert.ToDouble(value) },
            { typeof(decimal), (value) => System.Convert.ToDecimal(value) },
            { typeof(string), (value) => System.Convert.ToString(value) },
            { typeof(DateTime), (value) => System.Convert.ToDateTime(value) }
        };

        protected override object convert(object value)
        {
            var type = typeof(TValue);

            if (_funcs.ContainsKey(type))
            {
                return _funcs[type](value);
            }

            return (TValue)value; 
        }
    }
}
