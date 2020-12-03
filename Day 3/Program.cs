using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.IO;
using System.Linq;
using System.Timers;

namespace Day01
{
    class Program
    {
        public static int size = 200;
        static void Main(string[] args)
        {
            //SolveFirst();
            SolveSecond();
        }
        public static List<string> ReadData(string FileName)
        {
            StreamReader reader = File.OpenText(FileName);
            List<string> list = new List<string>();
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                list.Add(line);
            }
            return list;
        }
        public static void  SolveFirst()
        {
            List<string> data = ReadData("failas.txt");
            int ans = 0;
            int j = 0;
            for (int i = 0; i < data.Count; i++)
            {
                if (data[i][j % data[0].Count()] == '#')
                    ans++;
                j += 3;
            }
            Console.WriteLine("Answer: {0}", ans);
        }
        public static int OnePath(List<string> data, int iadd, int jadd)
        {
            int a = 0;
            int j = 0;
            for (int i = 0; i < data.Count; i += iadd)
            {
                if (data[i][j % data[0].Count()] == '#')
                    a++;
                j += jadd;
            }
            return a;
        }
        public static void SolveSecond()
        {
            List<string> data = ReadData("failas.txt");
            long ans = OnePath(data, 1, 1);
            ans *= OnePath(data, 1, 3);
            ans *= OnePath(data, 1, 5);
            ans *= OnePath(data, 1, 7);
            ans *= OnePath(data, 2, 1);
            Console.WriteLine("Part B: Result is {0}", ans);
        }

    }
}
