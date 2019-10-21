using System;
using System.Collections.Generic;
using System.Linq;

namespace ArraysKontest
{
    public class NumberSystem
    {
        public static string Convert(int[] numbers, int inBase, int outBase)
        {
            var temp = 0;              
            var basePower = 1;
            for(var i = numbers.Length - 1; i >= 0; i--)
            {
                temp += numbers[i] * basePower;
                basePower *= inBase;
            }
            var ans = new List<int>();
            while (temp != 0)
            {
                ans.Add(temp % outBase);
                temp /= outBase;
            }
            ans.Reverse();
            return string.Concat(ans);  
        }
    }
}
