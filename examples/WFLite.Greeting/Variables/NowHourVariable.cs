using System;
using WFLite.Bases;

namespace WFLite.Stopwatch.Variables
{
    public class NowHourVariable : Variable
    {
        protected override object getValue()
        {
            return DateTime.Now.Hour;
        }

        protected override void setValue(object value)
        {
            throw new NotSupportedException();
        }
    }
}
