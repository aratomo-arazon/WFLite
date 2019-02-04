using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WFLite.Activities;
using WFLite.Stopwatch.Variables;
using WFLite.Interfaces;
using WFLite.Greeting.Converters;
using WFLite.Activities.Console;
using WFLite.Variables;

namespace WFLite.Stopwatch
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var greeting = new AnyVariable<string>();

            var activity = new SequenceActivity()
            {
                Activities = new List<IActivity>()
                {
                    new AssignActivity<string, int>()
                    {
                        To = greeting,
                        Value = new NowHourVariable(),
                        Converter = new HourToGreetingConverter()
                    },
                    new ConsoleWriteLineActivity()
                    {
                        Value = greeting
                    }
                }
            };

            await activity.Start();

            Console.ReadKey();
        }
    }
}
