using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _04Domino
{
    class Program
    {
        static void Main(string[] args)
        {
            DominoMatcher matcher = new DominoMatcher();
            matcher.Open("zadani.txt");

            Console.WriteLine(matcher.Match());
            Console.ReadKey();
        }
    }
}
