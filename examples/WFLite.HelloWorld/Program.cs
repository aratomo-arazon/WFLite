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
            var message = new AnyVariable();

            var activity = new IfActivity()
            {
                Condition = new AndCondition()
                {
                    Conditions = new List<ICondition>()
                    {
                        new TrueCondition(),
                        new FalseCondition()
                    }
                },
                Then = new ForEachActivity()
                {
                    Collection = new AnyVariable(new List<object>() { "Hello World!", "Hello Ikeda" }),
                    Value = message,
                    Activity = new ConsoleWriteLineActivity()
                    {
                        Value = message
                    }
                },
                Else = new TryCatchActivity()
                {
                    Try = new SequenceActivity()
                    {
                        Activities = new List<IActivity>()
                        {
                            new ConsoleWriteLineActivity()
                            {
                                Value = new AnyVariable("sssss")
                            },
                            new ThrowActivity(),
                            new ConsoleWriteLineActivity()
                            {
                                Value = new AnyVariable("sssss")
                            }
                        }
                    },
                    Catch = new ConsoleWriteLineActivity()
                    {
                        Value = new AnyVariable("catch")
                    }
                }
            };

            await activity.Start();

            Console.WriteLine(activity.Status);

            Console.ReadKey();
        }
    }
}
