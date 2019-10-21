using System;
using System.Linq;

namespace Names
{
    internal static class HistogramTask
    {
        public static HistogramData GetBirthsPerDayHistogram(NameData[] names, string name)
        {
            var countBirthsPerDay = new double[31];
            foreach (var e in names)
            {
                if(e.Name == name)
                    countBirthsPerDay[e.BirthDate.Day - 1]++;
            }

            countBirthsPerDay[0] = 0; // Так как всем людям с неизвестной датой рождения приписывали дату рождения первого дня
                
            return new HistogramData(
                string.Format("Рождаемость людей с именем '{0}'", name), 
                Enumerable.Range(1, 31).Select(e => e.ToString()).ToArray(), 
                 countBirthsPerDay);
        }
    }
}