/*
 * AnyVariable.cs
 *
 * Copyright (c) 2019 aratomo-arazon
 *
 * This software is released under the MIT License.
 * http://opensource.org/licenses/mit-license.php
 */

using WFLite.Bases;
using WFLite.Interfaces;

namespace WFLite.Variables
{
    public class AnyVariable : InOutVariable
    {
        public object? Value
        {
            private get;
            set;
        }

        public AnyVariable()
        {
        }

        public AnyVariable(object value, IConverter? converter = null)
            : base(converter)
        {
            Value = value;
        }

        protected sealed override object? getValue()
        {
             return Value;
        }

        protected sealed override void setValue(object? value)
        {
            Value = value;
        }
    }

    public class AnyVariable<TValue> : InOutVariable<TValue>
    {
        private object? _value;

        public TValue Value
        {
            set
            {
                _value = value;
            }
        }

        public AnyVariable()
        {
        }

        public AnyVariable(TValue value, IConverter<TValue>? converter = null)
            : base(converter)
        {
            Value = value;
        }

        public AnyVariable(object value, IConverter<TValue> converter)
            : base(converter)
        {
            _value = value;
        }

        protected sealed override object? getValue()
        {
            return _value;
        }

        protected sealed override void setValue(object? value)
        {
            _value = value;
        }
    }

    public class AnyVariable<TInValue, TOutValue> : InOutVariable<TInValue, TOutValue>
    {
        private object? _value;

        public TInValue Value
        {
            set
            {
                _value = value;
            }
        }

        public AnyVariable()
        {
        }

        public AnyVariable(TInValue value, IConverter<TInValue, TOutValue> converter)
            : base(converter)
        {
            Value = value;
        }

        protected sealed override object? getValue()
        {
            return _value;
        }

        protected sealed override void setValue(object? value)
        {
            _value = value;
        }
    }
}
