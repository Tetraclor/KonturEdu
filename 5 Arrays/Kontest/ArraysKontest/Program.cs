using System;
using System.Linq;
using System.Runtime.CompilerServices;

namespace ArraysKontest
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            //StartCycleShift();
            //StartConvert();
            StartFraction();
        }

        private static void StartCycleShift()
        {
            var m = Enumerable.Range(1, 10).ToArray();
            CycleShift.ByReverse(m, 1);
            Console.WriteLine(String.Join(" ", m));
        }

        private static void StartConvert()
        {
            Console.WriteLine(NumberSystem.Convert(new[] {1, 1, 1}, 10, 8));
        }

        private static void StartFraction()
        {
            Console.WriteLine(Fraction.ToDecimalFraction(1, 6));
        }
        
    }
}