using System;
using System.Collections.Generic;

namespace tests
{
    class FindingPrimes
    {
        public void Run()
        {
            var primes = new SortedSet<int>();
            for (var i = 0; i <= 200; i++)
            {
                var i1 = i;
             //   var continueWith = new Task<int>(() => IsPrime(i1)).ContinueWith(x => { if (x != -1) primes.Add(x); });
            }
            Console.ReadLine();
        }

        private int IsPrime(int i)
        {

            var curModule = 2;
            var usedLower = new SortedSet<int>();
            var usedHigher = new SortedSet<int>();

            while (true)
            {
                var remainder = 0;
                var fullnumber = 0;

                Modulo(i, curModule, out remainder, out fullnumber);
                if (remainder == 0) return -1;

                usedLower.Add(curModule);
                usedHigher.Add(fullnumber);

                curModule += 1;

                if (curModule != i && usedLower.Max <= usedHigher.Min) continue;

                Console.WriteLine("{0} is prime", i);
                return i;
            }

        }

        private static void Modulo(int num, int divisor, out int remainder, out int fullnumber)
        {
            var dividend = num / (double)divisor;
            fullnumber = (int)Math.Floor(dividend);
            remainder = num % divisor;
        }
    }
}
