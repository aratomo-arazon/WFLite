using System;
using System.Threading.Tasks;
using WFLite.Extensions;

namespace WFLite.Extension
{
    class Program
    {
        static async Task Main(string[] args)
        {
            await new Func<bool>(() =>
            {
                Console.WriteLine("Hello World!");
                return true;
            }).ToActivity().Start();

            Console.ReadKey();
        }
    }
}
