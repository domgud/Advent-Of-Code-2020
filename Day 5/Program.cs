using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Tracing;
using System.IO;
using System.Linq;
using System.Timers;

namespace Day01
{
    class Program
    {
        static void Main(string[] args)
        {
            SolveSecond();
            Stopwatch timer = new Stopwatch();
            timer.Start();
            SolveSecond();
            timer.Stop();
            Console.WriteLine("Time spent: {0}", timer.Elapsed);
        }
        public static List<string> ReadData(string path)
        {
            StreamReader reader = File.OpenText(path);
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
            List<int> ids = getID(data);
            int id = 0;
            foreach (var item in ids)
            {
                if (item > id) id = item;
            }
            Console.WriteLine("Result of first task:{0}", id);

        }

        public static void SolveSecond()
        {
            List<string> data = ReadData("failas.txt");
            List<int> ids = getID(data);
            int id = 0;
            int n = ids.Count;
            ids.Sort();
            for (int i = 0; i < n; i++)
            {
                if (ids[i] + 1 != ids[i + 1])
                {
                    id = ids[i]+1;
                    break;
                }
            }
            Console.WriteLine("Result of second task:{0}", id);
        }
        public static List<int> getID(List<string> list)
        {

            List<int> id = new List<int>();
            foreach (string s in list)
            {
                int row = 0;
                for (int i = 0; i < 7; i++)
                {
                    row <<= 1;
                    int bit = s[i] == 'F' ? 0 : 1;
                    row |= bit;
                }
                int col = 0;
                for (int i = 7; i < 10; i++)
                {
                    col <<= 1;
                    int bit = s[i] == 'L' ? 0 : 1;
                    col |= bit;
                }
                id.Add(row * 8 + col);
            }
            return id;

        }

    }
}
