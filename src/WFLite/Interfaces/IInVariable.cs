/*
 * IInVariable.cs
 *
 * Copyright (c) 2019 aratomo-arazon
 *
 * This software is released under the MIT License.
 * http://opensource.org/licenses/mit-license.php
 */

namespace WFLite.Interfaces
{
    public interface IInVariable : IObject
    {
        void SetValue(object? value);

        void SetValue<TValue>(TValue? value);
    }

    public interface IInVariable<in TValue> : IInVariable
    {
        void SetValue(TValue? value);
    }
}

