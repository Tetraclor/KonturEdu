using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Names
{
    internal class HistogramBirthdayChance
    {
        private const int MinGroupSize = 2;
        private const int MaxGroupSize = 100;
        private const int CountGroup = MaxGroupSize - MinGroupSize + 1;
        private const int SampleSize = 5000;
        public static HistogramData GetData(NameData[] names)
        {
            var dataLength = names.Length;
            var probabilities = new double[CountGroup];
            var random = new Random();
            for (var curSizeGroup = MinGroupSize; curSizeGroup <= MaxGroupSize; curSizeGroup++)
            {
                var countMatches = 0;
                for (var j = 0; j < SampleSize; j++)
                {
                    var group = new DateTime[curSizeGroup];
                    for (var k = 0; k < curSizeGroup; k++)
                    {
                        var randomIndex = random.Next(dataLength);
                        group[k] = names[randomIndex].BirthDate;
                    }
                    if (CheckMatchBirthdays(group)) countMatches++;
                }

                probabilities[curSizeGroup - MinGroupSize] = (countMatches / (double) SampleSize) * 100;
            }
            return new HistogramData(
                "Парадокс дней рождения",
                Enumerable.Range(MinGroupSize, CountGroup).Select(e => e.ToString()).ToArray(),
                probabilities
                );
        }

        private static bool CheckMatchBirthdays(DateTime[] dates)
        {
            return dates.Select(e => e.Month + "" + e.Day).Distinct().Count() != dates.Length;
        }
    }
}