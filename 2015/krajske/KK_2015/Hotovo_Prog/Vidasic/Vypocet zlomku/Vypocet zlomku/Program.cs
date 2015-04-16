using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Vypocet_zlomku
{
    class Program
    {
        static void Main(string[] args)
        {
            //Načtení souboru
            using (StreamReader sr = new StreamReader(@"R:\KK_2015\Zadani_Prog\zlomky\zadani.txt"))
            {




                
                string radek;
                double a, b, c, d;
                //Zápis do souboru vystup.txt
                using (StreamWriter sw = new StreamWriter(@"R:\KK_2015\Zadani_Prog\zlomky\vystup.txt"))
                {
                    //Načtení hodnot ze souboru
                    while (!sr.EndOfStream)
                    {
                        radek = sr.ReadLine();
                        string[] split = radek.Split(new Char[] { ' ' });
                        a = Convert.ToDouble(split[0]);
                        b = Convert.ToDouble(split[1]);
                        c = Convert.ToDouble(split[2]);
                        d = Convert.ToDouble(split[3]);

                        //Když se základy zlomků rovnají
                        if (b == d)
                        {
                            //Čitatel i jmenovatel je stejný
                            if ((a + c) == b)
                            {
                                //Výpis do výstupu
                                sw.WriteLine("{0}/{1} + {2}/{3} = 1", a, b, c, d);
                            }
                            //Čitatel je menší než jmenovatel
                            else if ((a + c) < b)
                            {
                                //Výpis do výstupu
                                sw.WriteLine("{0}/{1} + {2}/{3} = 0 + {4}/{1}", a, b, c, d, a + c);
                            }
                            //Čitatel je větší než jmenovatel
                            else if ((a + c) > b)
                            {
                                int celeCislo = 0;
                                double vysledek = a + c;
                                while (vysledek > b)
                                {
                                    if (vysledek > b)
                                    {
                                        vysledek -= b;
                                        celeCislo++;
                                    }
                                }
                                //Výpis do výstupu
                                sw.WriteLine("{0}/{1} + {2}/{3} = {5} + {4}/{3}", a, b, c, d, vysledek, celeCislo);
                            }
                        }
                        //Když jsou základy rozdílné
                        else if (b != d)
                        {
                            double prvniCislo = a * d;
                            double druheCislo = b * c;
                            double zaklad = b * d;
                            double vysledek = prvniCislo + druheCislo;
                            double cisloCele = 0;
                            //Čitatel je menší než jmenovatel
                            if (vysledek < zaklad)
                            {
                                //Výpis do výstupu
                                sw.WriteLine("{0}/{1} + {2}/{3} = 0 + {4}/{5}", a, b, c, d, vysledek, zaklad);
                            }
                            //Čitatel je větší než jmenovatel
                            else if (vysledek > zaklad)
                            {
                                while (vysledek > zaklad)
                                {
                                    vysledek -= zaklad;
                                    cisloCele++;
                                }
                                //Výpis do výstupu
                                sw.WriteLine("{0}/{1} + {2}/{3} = {4} + {5}/{6}", a, b, c, d, cisloCele, vysledek, zaklad);
                            }


                        }



                    }
                }

            }





            




        }
    }
}
