/*
 * InOutVariable.cs
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
    public abstract class InOutVariable : IInVariable, IOutVariable
    {
        public IConverter Converter
        {
            private get;
            set;
        }

        public InOutVariable()
        {
        }

        public InOutVariable(IConverter converter = null)
        {
            Converter = converter;
        }

        public object GetValueAsObject()
        {
            if (Converter == null)
            {
                return getValue();
            }
            else
            {
                return Converter.ConvertToObject(getValue());
            }
        }

        public object GetValue()
        {
            if (Converter == null)
            {
                return getValue();
            }
            else
            {
                return Converter.ConvertToObject(getValue());
            }
        }

        public TOutValue GetValue<TOutValue>()
        {
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

        public void SetValue(object value)
        {
            setValue(value);
        }

        public void SetValue<TInValue>(TInValue value)
        {
            setValue(value);
        }

        protected abstract object getValue();

        protected abstract void setValue(object value);
    }

    public abstract class InOutVariable<TValue> : IInVariable<TValue>, IOutVariable<TValue>
    {
        public IConverter<TValue> Converter
        {
            private get;
            set;
        }

        public InOutVariable()
        {
        }

        public InOutVariable(IConverter<TValue> converter = null)
        {
            Converter = converter;
        }

        public object GetValueAsObject()
        {
            if (Converter == null)
            {
                return getValue();
            }
            else
            {
                return Converter.ConvertToObject(getValue());
            }
        }

        public TOutValue GetValue<TOutValue>()
        {
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

        public TValue GetValue()
        {
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

        public void SetValue(object value)
        {
            setValue(value);
        }

        public void SetValue<TInValue>(TInValue value)
        {
            setValue(value);
        }

        public void SetValue(TValue value)
        {
            setValue(value);
        }

        protected abstract object getValue();

        protected abstract void setValue(object value);
    }

    public abstract class InOutVariable<TInValue, TOutValue> : IInVariable<TInValue>, IOutVariable<TOutValue>
    {
        public IConverter<TOutValue> Converter
        {
            private get;
            set;
        }

        public InOutVariable()
        {
        }

        public InOutVariable(IConverter<TOutValue> converter = null)
        {
            Converter = converter;
        }

        public object GetValueAsObject()
        {
            if (Converter == null)
            {
                return getValue();
            }
            else
            {
                return Converter.ConvertToObject(getValue());
            }
        }

        public TValue GetValue<TValue>()
        {
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

        public TOutValue GetValue()
        {
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

        protected abstract object getValue();

        protected abstract void setValue(object value);
    }
}
