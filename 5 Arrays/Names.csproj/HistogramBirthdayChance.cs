using System;
using System.Linq;

namespace Names
{
    internal class HistogramBirthdayChance
    {
        private const int MinGroupSize = 2;
        private const int MaxGroupSize = 100;
        private const int CountGroup = MaxGroupSize - MinGroupSize + 1;
        private const int SampleSize = 3000;
        public static HistogramData GetData(NameData[] names)
        {
            var probabilities = new double[CountGroup];
            var countMatches = 0;
            
            for (var curSizeGroup = MinGroupSize; curSizeGroup <= MaxGroupSize; curSizeGroup++)
            {
                countMatches = 0;
                for (var i = 0; i < SampleSize; i++)
                {
                    if (CheckMatchBirthdays(GetDateTimesRandomGroup(curSizeGroup, names))) countMatches++;
                }
                probabilities[curSizeGroup - MinGroupSize] = (countMatches / (double) SampleSize) * 100;
            }
            
            return new HistogramData(
                "Парадокс дней рождения",
                Enumerable.Range(MinGroupSize, CountGroup).Select(e => e.ToString()).ToArray(),
                probabilities
                );
        }
        
        private static Random random = new Random();
        private static DateTime[] GetDateTimesRandomGroup(int groupSize, NameData[] names)
        {
            var dataLength = names.Length;
            var group = new DateTime[groupSize];
            for (var i = 0; i < groupSize; i++)
                group[i] = names[random.Next(dataLength)].BirthDate;

            return group;
        }

        private static bool CheckMatchBirthdays(DateTime[] dates)
        {
            return dates.Select(e => e.Month + "" + e.Day).Distinct().Count() != dates.Length;
        }
    }
}