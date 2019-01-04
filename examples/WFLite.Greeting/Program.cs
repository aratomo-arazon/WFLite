using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WFLite.Activities;
using WFLite.Stopwatch.Activities;
using WFLite.Stopwatch.Variables;
using WFLite.Interfaces;
using WFLite.Greeting.Converters;

namespace WFLite.Stopwatch
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var activity = new WriteLineActivity()
            {
                Value = new NowHourVariable() { Converter = new HourToGreetingConverter() }
            };

            await activity.Start();

            Console.ReadKey();
        }
    }
}
