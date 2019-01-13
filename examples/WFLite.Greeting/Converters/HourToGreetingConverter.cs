using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using WFLite.Converters;

namespace WFLite.Greeting.Converters
{
    public class HourToGreetingConverter : Bases.Converter
    {
        protected override object convert(object value)
        {
            var hour = System.Convert.ToInt32(value);

            if (hour >= 6 && hour < 12)
            {
                return "Good morning!";
            }
            else if (hour >= 12 && hour < 18)
            {
                return "Good afternoon!";
            }
            else if (hour >= 18 && hour < 24)
            {
                return "Good evening!";
            }
            else
            {
                return "zzz...";
            }
        }
    }
}