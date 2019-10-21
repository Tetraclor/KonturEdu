using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;

namespace ArraysKontest
{
    public class Fraction
    {
        public static string ToDecimalFraction(int numerator, int denominator)
        {
            var ceilPart = numerator / denominator;
            numerator %= denominator;
            var residues = new List<int>();
            var decimalFraction = new List<int>();
            while (!residues.Contains(numerator) && numerator != 0)
            {
                residues.Add(numerator);
                if (numerator < denominator) numerator *= 10;
                while (numerator < denominator)
                {
                    numerator *= 10;
                    decimalFraction.Add(0);
                    residues.Add(0);
                }
                decimalFraction.Add(numerator/denominator);
                numerator %= denominator;
            }

            var count = residues.IndexOf(numerator);
            if (count != -1)
                return $"{ceilPart}." +
                       $"{string.Concat(decimalFraction.GetRange(0, count))}" +
                       $"({string.Concat(decimalFraction.GetRange(count, decimalFraction.Count - count))})";
            else
                return $"{ceilPart}.{string.Concat(decimalFraction)}";
        }
        
    }
}