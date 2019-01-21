using System;
using System.Collections.Generic;
using System.Text;

namespace WFLite.Converters
{
    public class ToStringConverter : Bases.Converter
    {
        protected sealed override object convert(object value)
        {
            return value.ToString();
        }
    }
}
