using System;
using System.Collections.Generic;

namespace _02Zlomky
{
    public struct Fraction
    {
        public double Numerator
        {
            get;
            set;
        }

        public double Denominator
        {
            get;
            set;
        }

        public static Fraction operator +(Fraction a, Fraction b)
        {
            double denominator = a.Denominator == b.Denominator ? a.Denominator : a.Denominator * b.Denominator,// FindMultiple(a.Denominator, b.Denominator),
                   numerator = a.Numerator * (denominator / a.Denominator) + b.Numerator * (denominator / b.Denominator),
                   divider = FindDivider(numerator, denominator);

            return new Fraction()
            {
                Numerator = numerator / divider,
                Denominator = denominator / divider
            };
        }

        public override string ToString()
        {
            double full = Math.Floor(Numerator / Denominator);
            return full + " " + (Numerator - full * Denominator) + " " + Denominator;
        }

        static double FindMultiple(double a, double b)
        {
            List<double>
                fragA = Fragment(a),
                fragB = Fragment(b),
                temp;
            /*
            if (fragA.Count < fragB.Count)
            {
                temp = fragA;
                fragA = fragB;
                fragB = temp;
            }

            for (int i = 0; i < fragB.Count; i++)
            {
                if (fragA.Contains(fragB[i]))
                {
                    fragA.Remove(fragB[i]);
                    fragB.RemoveAt(i);
                    i--;
                }
            }
            */
            double n = 1;
            foreach (double prime in fragA)
                n *= prime;

            foreach (double prime in fragB)
                n *= prime;
            
            return n;
        }

        static double FindDivider(double a, double b)
        {
            List<double>
                fragA = Fragment(a),
                fragB = Fragment(b),
                temp;

            if (fragA.Count < fragB.Count)
            {
                temp = fragA;
                fragA = fragB;
                fragB = temp;
            }

            double n = 1;
            for (int i = 0; i < fragA.Count; i++)
            {
                if (fragB.Contains(fragA[i]))
                {
                    n *= fragA[i];
                    fragB.Remove(fragA[i]);
                }
            }

            return n;
        }

        static List<double> Fragment(double n)
        {
            List<double>
                primes = Sieve((int)Math.Sqrt(n) + 1),
                fragments = new List<double>();

            foreach (int prime in primes)
            {
                while (n % prime == 0.0)
                {
                    fragments.Add(prime);
                    n /= prime;
                }
            }

            if (n != 1)
            {
                fragments.Add(n);
            }

            return fragments;
        }

        static List<double> Sieve(int max)
        {
            uint i, j;
            bool[] sieve = new bool[max];
            for (i = 0; i < max; i++)
                sieve[i] = true;

            for (i = 2; i < max; i++)
                if (sieve[i])
                    for (j = i * i; j < max; j += i)
                        sieve[j] = false;

            List<double> prime = new List<double>();
            for (i = 2; i < max; i++)
                if (sieve[i])
                    prime.Add(i);

            return prime;
        }
    }
}
