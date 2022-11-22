/*
 * OutVariable.cs
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
    public abstract class OutVariable : IOutVariable
    {
        public IConverter? Converter
        {
            private get;
            set;
        }

        public OutVariable()
        {
        }

        public OutVariable(IConverter? converter = null)
        {
            Converter = converter;
        }

        public object? GetValueAsObject()
        {
            initialize();
            if (Converter == null)
            {
                return getValue();
            }
            else
            {
                return Converter.ConvertToObject(getValue());
            }
        }

        public TValue? GetValue<TValue>()
        {
            initialize();
            var castConverter = new CastConverter<TValue>();

            if (Converter == null)
            {
                return castConverter.Convert(getValue());
            }
            else
            {
                return castConverter.Convert(Converter.ConvertToObject(getValue()));
            }
        }

        protected virtual void initialize()
        {
        }

        protected abstract object? getValue();
    }

    public abstract class OutVariable<TOutValue> : IOutVariable<TOutValue>
    {
        public IConverter<TOutValue>? Converter
        {
            private get;
            set;
        }

        public OutVariable()
        {
        }

        public OutVariable(IConverter<TOutValue>? converter = null)
        {
            Converter = converter;
        }

        public object? GetValueAsObject()
        {
            initialize();

            if (Converter == null)
            {
                return getValue();
            }
            else
            {
                return Converter.ConvertToObject(getValue());
            }
        }

        public TValue? GetValue<TValue>()
        {
            initialize();

            var castConverter = new CastConverter<TValue>();

            if (Converter == null)
            {
                return castConverter.Convert(getValue());
            }
            else
            {
                return castConverter.Convert(Converter.ConvertToObject(getValue()));
            }
        }

        public TOutValue? GetValue()
        {
            initialize();

            var castConverter = new CastConverter<TOutValue>();

            if (Converter == null)
            {
                return castConverter.Convert(getValue());
            }
            else
            {
                return castConverter.Convert(Converter.ConvertToObject(getValue()));
            }
        }

        protected virtual void initialize()
        {
        }

        protected abstract object? getValue();
    }
}
