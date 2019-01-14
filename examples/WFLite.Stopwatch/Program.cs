﻿using System;
using System.Threading.Tasks;
using WFLite.Activities;
using WFLite.Activities.Console;
using WFLite.Variables;

namespace WFLite.Stopwatch
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var elapsed = new AnyVariable();

            var activity = new TryCatchActivity()
            {
                Try = new StopwatchActivity()
                {
                    Activity = new DelayActivity()
                    {
                        Duration = new AnyVariable() { Value = 10000 }
                    },
                    Elapsed = elapsed
                },
                Finally = new ConsoleWriteLineActivity()
                {
                    Value = elapsed
                }
            };

            // start
            Console.ReadKey();

            var task = activity.Start();

            // stop
            Console.ReadKey();

            activity.Stop();

            await task;

            Console.ReadKey();
        }
    }
}