using System.Linq;

namespace ArraysKontest
{
    public class CycleShift
    {
        public static int[] ByReverse(int[] m, int shift)
        {
            shift = shift % m.Length ;
            BlockReverse(m, 0, m.Length - shift - 1);
            BlockReverse(m, m.Length - shift, m.Length - 1);
            BlockReverse(m, 0, m.Length-1);
            return m;
        }

        private static void BlockReverse(int[] m, int start, int end)
        {
            var endFor = (end - start + 1)/2 + start;
            for (int i = start, j = end; i < endFor; i++, j--)
            {
                var v = m[i];
                m[i] = m[j];
                m[j] = v;
            }
        }
    }
}