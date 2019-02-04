/*
 * ObjectExtension.cs
 *
 * Copyright (c) 2019 aratomo-arazon
 *
 * This software is released under the MIT License.
 * http://opensource.org/licenses/mit-license.php
 */

using WFLite.Interfaces;
using WFLite.Variables;

namespace WFLite.Extensions
{
    public static class ObjectExtension
    {
        public static IOutVariable ToVariable(this object value, IConverter converter = null)
        {
            return new AnyVariable(value, converter);
        }

        public static IOutVariable<TValue> ToVariable<TValue>(this TValue value, IConverter<TValue> converter = null)
        {
            return new AnyVariable<TValue>(value, converter);
        }
    }
}
