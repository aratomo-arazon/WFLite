using System;
using System.Threading.Tasks;
using WFLite.Activities;
using WFLite.Activities.Console;
using WFLite.Activities.Diagnostics;
using WFLite.Variables;

namespace WFLite.Stopwatch
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var elapsed = new AnyVariable<long>();

            var activity = new TryCatchActivity()
            {
                Try = new StopwatchActivity()
                {
                    Activity = new DelayActivity(new AnyVariable<int>(10000)),
                    Elapsed = elapsed
                },
                Finally = new ConsoleWriteLineActivity()
                {
                    Value = elapsed
                }
            };

            // start
            Console.WriteLine("Press any key to start.");
            Console.ReadKey();

            var task = activity.Start();

            // stop
            Console.WriteLine("Press any key to stop.");
            Console.ReadKey();

            activity.Stop();

            await task;

            Console.ReadKey();
        }
    }
}
