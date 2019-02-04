/*
 * IConverter.cs
 *
 * Copyright (c) 2019 aratomo-arazon
 *
 * This software is released under the MIT License.
 * http://opensource.org/licenses/mit-license.php
 */

namespace WFLite.Interfaces
{
    public interface IConverter
    {
        object ConvertToObject(object value);
    }

    public interface IConverter<TValue> : IConverter
    {
        TValue Convert(object value);
    }

    public interface IConverter<TInValue, TOutValue> : IConverter<TOutValue>
    {
        TOutValue Convert(TInValue value);
    }
}
