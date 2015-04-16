using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;

namespace _04Domino
{
    public class DominoMatcher
    {
        public List<Domino> Dominoes
        {
            get { return dominoes; }
        }
        private readonly List<Domino> dominoes;

        public DominoMatcher(IEnumerable<Domino> dominoes)
        {
            this.dominoes = new List<Domino>(dominoes);
        }

        public DominoMatcher()
        {
            dominoes = new List<Domino>();
        }

        public void Open(string path)
        {
            dominoes.Clear();
            using (StreamReader reader = new StreamReader(path))
            {
                string line = reader.ReadLine();
                MatchCollection matches = Regex.Matches(line, @"\[([1-6]):([1-6])\]");
                foreach (Match match in matches)
                {
                    dominoes.Add(new Domino()
                        {
                            A = byte.Parse(match.Groups[1].Value),
                            B = byte.Parse(match.Groups[2].Value)
                        });
                }
            }
        }


        List<string> buffer = new List<string>();

        public string Match()
        {
            int i;
            int[] used = new int[dominoes.Count];
            for (i = 0; i < used.Length; i++)
            {
                used[i] = i;
            }

            buffer.Clear();
            for (i = 0; i < used.Length; i++)
            {
                Match(i, (int[])used.Clone(), "");
            }

            string longest = "";
            foreach (string thread in buffer)
            {
                if (thread.Length > longest.Length)
                {
                    longest = thread;
                }
            }

            return longest;
        }

        void Match(int current, int[] used, string thread)
        {
            used[current] = -1;
            thread += dominoes[current].ToString();
            byte match = dominoes[current].B;

            int matches = 0;
            for (int i = 0; i < used.Length; i++)
            {
                if (used[i] == -1)
                    continue;

                if (match == dominoes[i].A)
                {
                    Match(i, (int[])used.Clone(), thread);
                    matches++;
                }
            }

            if (matches == 0)
            {
                buffer.Add(thread);
            }
        }
    }
}
