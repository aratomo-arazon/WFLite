using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WFLite.Activities;
using WFLite.Activities.Console;
using WFLite.Conditions;
using WFLite.Enums;
using WFLite.Interfaces;
using WFLite.Variables;

namespace WFLite.Stopwatch
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var activity = new ConsoleWriteLineActivity()
            {
                Value = new AnyVariable<string>() { Value = "Hello World!" }
            };

            await activity.Start();

            Console.ReadKey();
        }
    }
}
