using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace ConsoleApp1
{
    class Program
    {
        
        static void Main(string[] args)
        
        {
            CultureInfo ci = (CultureInfo)CultureInfo.CurrentCulture.Clone();
            ci.NumberFormat.CurrencyDecimalSeparator = ".";
            string australian = @"C:\Users\zenek\Desktop\Si\ConsoleApp1\australian.txt";
            string australiantype = @"C:\Users\zenek\Desktop\Si\ConsoleApp1\australian-type.txt";
            //Zadanie3 a)
            //var logFile = File.ReadAllLines(australian);
            //var logList = new List<string>(logFile);
            //Console.WriteLine("Zadanie3 a)");
            ////logList.ForEach(Console.WriteLine);
            //var list = new List<List<string>>();
            //foreach(var x in logList)
            //{
            //    var line = x.Split(" ").ToList();
            //    list.Add(new List<string>());
            //    int i = 0;
            //    foreach(var y in line)
            //    {
            //        list[i].Add(y);
            //    }
            //    i++;
            //}
            
            var ListofStrings = new List<List<string>>();
            using (var fileStream = File.OpenRead(australian))
            using(var streamReader=new StreamReader(fileStream))
            {
                int i = 0;
                string line;
                while ((line = streamReader.ReadLine())!=null)
                {
                    var x = line.Split(" ").ToList();
                    ListofStrings.Add(new List<string>());
                    foreach (var y in x)
                    {
                        ListofStrings[i].Add(y);
                    }
                    i++;
                }
                
            }
            
            var ListaLegitna = new List<List<string>>();
            for (int i=0;i < ListofStrings[0].Count();i++)
            {
                ListaLegitna.Add(new List<string>());
                for(int j=0;j<ListofStrings.Count();j++)
                {
                    ListaLegitna[i].Add(ListofStrings[j][i]);
                }

            }
            //for (int i = 0; i < ListaLegitna[0].Count(); i++)
            //{
            //    for (int j = 0; j < ListaLegitna.Count(); j++)
            //    {
            //        Console.Write(ListaLegitna[j][i] + " ");
            //    }
            //    Console.WriteLine();
            //}
            //int a = 0;
            //for (int i = 0; i < ListaLegitna[0].Count(); i++)
            //{
            //    a++;
            //    for (int j = 0; j < ListaLegitna.Count(); j++)
            //    {
            //        a++;
            //    }

            //}
            //Console.WriteLine(a);

            //zadanie 3a)
            var symboleklas = new List<string>();

            for (int i = 0; i < 690; i++)
            {
                
                if(!symboleklas.Contains(ListaLegitna[14][i]))
                {
                    symboleklas.Add(ListaLegitna[14][i]);
                }
                
            }
            Console.WriteLine("\n"+"zadanie3_a");
            symboleklas.ForEach(Console.WriteLine);
            
            //Zadanie 3b)
            int a = 0;
            int b = 0;

            for (int i = 0; i < 690; i++)
            {

                if (ListaLegitna[14][i]=="0")
                {
                    a++;
                }
                else
                {
                    b++;
                }
            }
            Console.WriteLine("\n"+"zadanie3_b");
            Console.WriteLine(a+" Liczba zer");
            Console.WriteLine(b+" Liczba jedynek");
            
            
            //Zadanie 3 c)
            int a2 = 1;
            int a3 = 2;
            int a7 = 6;
            int a10 = 9;
            int a13 = 12;
            int a14 = 13;
            Console.WriteLine("\n"+"Zadanie3 c)");
            double min2 = double.Parse(ListaLegitna[a2][0], NumberStyles.Any, ci);
            for (int i = 0; i < 690; i++)
            {
                
                if (double.Parse(ListaLegitna[a2][i], NumberStyles.Any, ci) < min2)
                {
                    min2 = double.Parse(ListaLegitna[a2][i], NumberStyles.Any, ci);
                }
                
            }
            Console.WriteLine("Wartośc minimalna dla a2= "+min2);
            
            double min3 = double.Parse(ListaLegitna[a3][0], NumberStyles.Any, ci);
            for (int i = 0; i < 690; i++)
            {

                if (double.Parse(ListaLegitna[a3][i], NumberStyles.Any, ci) < min3)
                {
                    min3 = double.Parse(ListaLegitna[a3][i], NumberStyles.Any, ci);
                }

            }
            Console.WriteLine("Wartośc minimalna dla a3= " + min3);
            
            double min7 = double.Parse(ListaLegitna[a7][0], NumberStyles.Any, ci);
            for (int i = 0; i < 690; i++)
            {

                if (double.Parse(ListaLegitna[a7][i], NumberStyles.Any, ci) < min7)
                {
                    min7 = double.Parse(ListaLegitna[a7][i], NumberStyles.Any, ci);
                }

            }
            Console.WriteLine("Wartośc minimalna dla a7= " + min7);
            
            double min10 = double.Parse(ListaLegitna[a10][0], NumberStyles.Any, ci);
            for (int i = 0; i < 690; i++)
            {

                if (double.Parse(ListaLegitna[a10][i], NumberStyles.Any, ci) < min10)
                {
                    min10 = double.Parse(ListaLegitna[a10][i], NumberStyles.Any, ci);
                }

            }
            Console.WriteLine("Wartośc minimalna dla a10= " + min10);
            
            double min13 = double.Parse(ListaLegitna[a13][0], NumberStyles.Any, ci);
            for (int i = 0; i < 690; i++)
            {

                if (double.Parse(ListaLegitna[a13][i], NumberStyles.Any, ci) < min13)
                {
                    min13 = double.Parse(ListaLegitna[a13][i], NumberStyles.Any, ci);
                }

            }
            Console.WriteLine("Wartośc minimalna dla a13= " + min13);
            
            double min14 = double.Parse(ListaLegitna[a14][0], NumberStyles.Any, ci);
            for (int i = 0; i < 690; i++)
            {

                if (double.Parse(ListaLegitna[a14][i], NumberStyles.Any, ci) < min14)
                {
                    min14 = double.Parse(ListaLegitna[a14][i], NumberStyles.Any, ci);
                }

            }
            Console.WriteLine("Wartośc minimalna dla a14= " + min14);
            //Zadanie 3 d,e)
            Console.WriteLine("\n"+"Zadanie 3 d) e)");


            for (int i = 0; i < 14; i++)
            {
                var wartosci1 = new List<string>();

                for (int j = 0; j < 690; j++)
                {
                    if (!wartosci1.Contains(ListaLegitna[i][j]))
                    {
                        wartosci1.Add(ListaLegitna[i][j]);
                    }
                }
                Console.WriteLine("\n"+"Liczba różnych wartości dla a" + (i + 1) + " " + wartosci1.Count());
                Console.WriteLine("Różne wartości dla a" + (i + 1) );
                var combined = string.Join(", ", wartosci1);
                Console.Write(combined+ "\n");

            }

            //Zadanie 3 f)
            //double xD = double.Parse(ListaLegitna[0][1],NumberStyles.Any, ci);
            Console.WriteLine("\nZadanie 3 f)");
            for(int i=0;i<15;i++)
            {
                var s = new List<double>();
                for (int j=0;j<690;j++)
                {
                    s.Add(double.Parse(ListaLegitna[i][j], NumberStyles.Any, ci));
                }
                double srednia = s.Average();
                double x=0;
                for(int k = 0; k < 690; k++)
                {
                    x += Math.Pow((double.Parse(ListaLegitna[i][k], NumberStyles.Any, ci) - srednia),2);
                }
                double wynik = (x / 690);
                double odchylenie = Math.Sqrt(wynik);
                Console.WriteLine("Odchylenie standardowe dla a"+i+": "+odchylenie);
            }
            

        }
    }
}
