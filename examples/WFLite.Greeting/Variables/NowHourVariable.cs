using System;
using WFLite.Bases;

namespace WFLite.Stopwatch.Variables
{
    public class NowHourVariable : OutVariable<int>
    {
        protected override object getValue()
        {
            return DateTime.Now.Hour;
        }
    }
}
