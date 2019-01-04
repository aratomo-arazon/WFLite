using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WFLite.Activities;
using WFLite.Enums;

namespace WFLite.Stopwatch
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var activity = new SyncActivity()
            {
                Func = () =>
                {
                    Console.WriteLine("Hello World!");

                    return true;
                }
            };

            await activity.Start();

            Console.ReadKey();
        }
    }
}
