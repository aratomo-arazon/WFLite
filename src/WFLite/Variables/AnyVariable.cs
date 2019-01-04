/*
 * AnyVariable.cs
 *
 * Copyright (c) 2019 Tomoharu Araki
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
            protected get;
            set;
        }

        protected override object getValue()
        {
            return Value;
        }

        protected override void setValue(object value)
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
                return (TValue)base.Value;
            }
            set
            {
                base.Value = value;
            }
        }

        protected override object getValue()
        {
            return base.Value;
        }

        protected override void setValue(object value)
        {
            base.Value = value;
        }
    }
}
