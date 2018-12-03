using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncExceptionConsoleDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // TIP: 11 - Async exceptions
            NullReferenceTest();

            while (true)
            {
                Console.Write(".");
                Thread.Sleep(100);
            }
        }

        private static async void NullReferenceTest()
        {
            await NullReferenceTaskTest(null);
        }

        private static async Task NullReferenceTaskTest(string p)
        {
            await Task.Delay(10);
            Console.WriteLine(p.Length);
        }

        private static void ExceptionTest()
        {

        }
    }
}