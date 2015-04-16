using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace _03MeteoData
{
    public class DataLoader
    {
        private List<Temperature> temperatures = new List<Temperature>();

        public void Open(string path)
        {
            Dictionary<int, List<int>> weeks = new Dictionary<int, List<int>>();
            temperatures.Clear();
            
            // nacist data ze souboru
            using (StreamReader reader = new StreamReader(path))
            {
                while (!reader.EndOfStream)
                    try
                    {
                        string line = reader.ReadLine();

                        string[] test = line.Split(new char[] { ';' });

                        int[] numbers = line
                            .Split(new char[] { ';' })
                            .Select(number => int.Parse(number))
                            .ToArray();

                        if (!weeks.ContainsKey(numbers[1]))
                        {
                            weeks[numbers[1]] = new List<int>();
                        }
                        weeks[numbers[1]].Add(numbers[2]);

                        temperatures.Add(new Temperature()
                            {
                                Year = numbers[0],
                                Week = numbers[1],
                                Temp = numbers[2],
                                Date = GetTimestamp(numbers[0], numbers[1])
                            });
                    }
                    catch
                    {
                        // ignorovat nespravne radky
                    }
            }

            // spocitat minima, maxima a prumer
            Dictionary<int, int[]> data = new Dictionary<int, int[]>();
            foreach (KeyValuePair<int, List<int>> week in weeks)
            {
                int min = week.Value[0],
                    max = week.Value[0],
                    sum = 0;

                foreach (int temp in week.Value)
                {
                    min = Math.Min(min, temp);
                    max = Math.Max(max, temp);
                    sum += temp;
                }

                data.Add(week.Key, new int[] { min, max, sum / week.Value.Count });
            }

            for (int i = 0; i < temperatures.Count; i++)
            {
                if (data.ContainsKey(temperatures[i].Week))
                {
                    temperatures[i].Minimum = data[temperatures[i].Week][0];
                    temperatures[i].Maximum = data[temperatures[i].Week][1];
                    temperatures[i].Average = data[temperatures[i].Week][2];
                }
            }
        }


        public IEnumerable<Temperature> GetTemperatures()
        {
            return temperatures;
        }

        public IEnumerable<Temperature> GetTemperatures(DateTime from, DateTime to)
        {
            List<Temperature> buffer = new List<Temperature>();

            foreach (Temperature temp in temperatures)
                if ((temp.Year > from.Year && temp.Year < to.Year) || 
                    (temp.Year == from.Year && temp.Week >= from.Day / 7) ||
                    (temp.Year == to.Year && temp.Week <= to.Day / 7))
                    buffer.Add(temp);

            return buffer;
        }

        DateTime GetTimestamp(int year, int week)
        {
            // rychly ale nepresny zpusob prepoctu
            int month = (week * 7) / 31;
            return new DateTime(year, month + 1, week * 7 - month * 31);

            /* Tento zpusob je presnejsi, nicmen VELMI pomaly
            int days = week * 7,
                month = 1;

            while (days > 7)
            {
                days -= DateTime.DaysInMonth(year, month);
                month++;
            }

            return new DateTime(year, month, days);
            */
        }
    }
}