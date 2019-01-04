/*
 * Variable.cs
 *
 * Copyright (c) 2019 aratomo-arazon
 *
 * This software is released under the MIT License.
 * http://opensource.org/licenses/mit-license.php
 */

using WFLite.Interfaces;

namespace WFLite.Bases
{
    public abstract class Variable : IVariable
    {
        public IConverter Converter
        {
            private get;
            set;
        }

        public object GetValue()
        {
            if (Converter == null)
            {
                return getValue();
            }
            else
            {
                return Converter.Convert(getValue());
            }
        }

        public void SetValue(object value)
        {
            setValue(value);
        }

        protected abstract object getValue();

        protected abstract void setValue(object value);
    }
}
