using System;
using WFLite.Activities;
using WFLite.Enums;
using WFLite.Interfaces;

namespace WFLite.Stopwatch.Activities
{
    public class WriteLineActivity : SyncActivity
    {
        public IVariable Value
        {
            private get;
            set;
        }

        public WriteLineActivity()
        {
            Func = () =>
            {
                Console.WriteLine(Value.GetValue());

                return true;
            };
        }
    }
}
