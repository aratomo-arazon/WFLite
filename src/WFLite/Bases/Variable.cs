/*
 * Variable.cs
 *
 * Copyright (c) 2019 aratomo-arazon
 *
 * This software is released under the MIT License.
 * http://opensource.org/licenses/mit-license.php
 */

using WFLite.Converters;
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

        public Variable()
        {
        }

        public Variable(IConverter converter = null)
        {
            Converter = converter;
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

        public TValue GetValue<TValue>()
        {
            var castConverter = new CastConverter<TValue>();

            return (TValue)castConverter.Convert(GetValue());
        }

        public void SetValue(object value)
        {
            setValue(value);
        }

        protected abstract object getValue();

        protected abstract void setValue(object value);
    }
}
