/*
 * ObjectExtension.cs
 *
 * Copyright (c) 2019 aratomo-arazon
 *
 * This software is released under the MIT License.
 * http://opensource.org/licenses/mit-license.php
 */

using System.ComponentModel;
using System.Data;
using WFLite.Interfaces;
using WFLite.Variables;

namespace WFLite.Extensions
{
    public static class ObjectExtension
    {
        public static void Require<Property>(this IObject obj, Property property, string propertyName)
        {
            if (property == null)
            {
                throw new NoNullAllowedException($"{nameof(Property)} {obj.GetType().Name}.{propertyName}");
            }
        }

        public static IOutVariable ToVariable(this object value, IConverter? converter = null)
        {
            return new AnyVariable(value, converter);
        }

        public static IOutVariable<TValue> ToVariable<TValue>(this TValue value, IConverter<TValue>? converter = null)
        {
            return new AnyVariable<TValue>(value, converter);
        }
    }
}
