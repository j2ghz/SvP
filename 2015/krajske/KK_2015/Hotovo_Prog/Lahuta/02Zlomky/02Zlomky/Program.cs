using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace _02Zlomky
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int[]> input = new List<int[]>();

            try
            {
                using (StreamReader reader = new StreamReader("zadani.txt"))
                {
                    while (!reader.EndOfStream)
                    {
                        input.Add(reader
                            .ReadLine()
                            .Split(new char[] { ' ' })
                            .Select(number => int.Parse(number))
                            .ToArray());
                    }
                }
            }
            catch
            {
                Console.WriteLine("Ve vstupním souboru 'zadani.txt' je chyba nebo neexistuje.");
            }

            try
            {
                using (StreamWriter writer = new StreamWriter("vystup.txt", false))
                {
                    Fraction a, b, c;
                    foreach (int[] numbers in input)
                    {
                        a = new Fraction()
                        {
                            Numerator = numbers[0],
                            Denominator = numbers[1]
                        };
                        b = new Fraction()
                        {
                            Numerator = numbers[2],
                            Denominator = numbers[3]
                        };

                        c = a + b;
                        writer.WriteLine(c.ToString());
                    }
                }
            }
            catch
            {
                Console.WriteLine("Nepodařilo se zpracovat data.");
            }

            Console.WriteLine("Hotovo...");
            Console.Write("Stiskněte libovolné tlačítko pro ukončení programu...");
            Console.ReadKey();
        }
    }
}
