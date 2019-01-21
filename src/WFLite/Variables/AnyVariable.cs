/*
 * AnyVariable.cs
 *
 * Copyright (c) 2019 aratomo-arazon
 *
 * This software is released under the MIT License.
 * http://opensource.org/licenses/mit-license.php
 */

using WFLite.Bases;

namespace WFLite.Variables
{
    public class AnyVariable : Variable
    {
        public object Value
        {
            private get;
            set;
        }

        public AnyVariable()
        {
        }

        public AnyVariable(object value)
        {
            Value = value;
        }

        protected sealed override object getValue()
        {
            return Value;
        }

        protected sealed override void setValue(object value)
        {
            Value = value;
        }
    }

    public class AnyVariable<TValue> : AnyVariable
    {
        public new TValue Value
        {
            private get
            {
                return (TValue)getValue();
            }
            set
            {
                base.setValue(value);
            }
        }

        public AnyVariable()
        {
        }

        public AnyVariable(TValue value)
        {
            Value = value;
        }
    }
}
