using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectEulerSolve
{
    class Program
    {
        static void Main(string[] args)
        {
            //int n = 4000000;
            //Console.WriteLine("Calculate Total:{0}", NumSolve.GetSumEvenFibonacci(n));


            //long m = 600851475143;
            //Console.WriteLine(NumSolve.GetLargestFactor(m));

            //Console.WriteLine(NumSolve.Palindrome3Dig());

            // Console.WriteLine(NumSolve.SmallestMultiple(20));
            //Console.WriteLine(NumSolve.LongestCollatzSeq());

            //Stopwatch MyStopWatch = new Stopwatch();
            //MyStopWatch.Start();
            //Console.WriteLine(NumSolve.NamesScores());
            //MyStopWatch.Stop();
            //decimal t = MyStopWatch.ElapsedTicks;
            //Console.WriteLine("it costs {0} ms!", t / 10000);
            //Console.ReadLine();
        }

        async Task DoSomethingAsync()
        {
            int val = 13;
            // 异步方式等待1 秒
            await Task.Delay(TimeSpan.FromSeconds(1)).ConfigureAwait(false);
            val *= 2;
            // 异步方式等待1 秒
            await Task.Delay(TimeSpan.FromSeconds(1)).ConfigureAwait(false);
            Trace.WriteLine(val.ToString());
        }
    }
}
