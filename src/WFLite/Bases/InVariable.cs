/*
 * InVariable.cs
 *
 * Copyright (c) 2019 aratomo-arazon
 *
 * This software is released under the MIT License.
 * http://opensource.org/licenses/mit-license.php
 */

using WFLite.Interfaces;

namespace WFLite.Bases
{
    public abstract class InVariable : IInVariable
    {
        public void SetValue(object value)
        {
            setValue(value);
        }

        public void SetValue<TValue>(TValue value)
        {
            setValue(value);
        }

        protected abstract void setValue(object value);
    }

    public abstract class InVariable<TInValue> : IInVariable<TInValue>
    {
        public void SetValue(object value)
        {
            setValue(value);
        }

        public void SetValue<TValue>(TValue value)
        {
            setValue(value);
        }

        public void SetValue(TInValue value)
        {
            setValue(value);
        }

        protected abstract void setValue(object value);
    }
}
