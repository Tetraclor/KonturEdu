using System;
 using System.Linq;
 namespace Names
 {
     internal static class HeatmapTask
     {
         private const int StartDay = 2;
         private const int EndDay = 31;
         private const int StartMonth = 1;
         private const int EndMonth = 12;
         private const int CountDay = EndDay - StartDay + 1;
         private const int CountMonth = EndMonth - StartMonth + 1;
         public static HeatmapData GetBirthsPerDateHeatmap(NameData[] names)
         {
             var heatmap = new double[CountDay, CountMonth];
             foreach (var e in names)
             {
                 if(e.BirthDate.Day >= StartDay)
                     heatmap[e.BirthDate.Day - StartDay, e.BirthDate.Month - StartMonth]++;
             }
             return new HeatmapData(
                 "Тепловая карта день рождений по месяцам и дням",
                  heatmap, 
                 Enumerable.Range(StartDay, CountDay).Select(e => e.ToString()).ToArray(), 
                 Enumerable.Range(StartMonth, CountMonth).Select(e => e.ToString()).ToArray()
                 );
         }
     }
 }