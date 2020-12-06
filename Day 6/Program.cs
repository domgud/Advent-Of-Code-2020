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
            //SolveFirst();
            SolveSecond();
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
            int ans = 0;
            HashSet<char> set = new HashSet<char>();
            List<string> lines = ReadData("failas.txt");
            foreach (string line in lines)
            {
                if (line == "")
                {
                    
                   ans += set.Count;
                    set = new HashSet<char>();

                }
                else
                {
                    set.UnionWith(line.ToHashSet());
                }
            }
            ans += set.Count; //last element
            Console.WriteLine("Result of first task: {0}", ans);


        }

        public static void SolveSecond()
        {
            List<string> lines = ReadData("failas.txt");
            int ans = 0;
            Dictionary<char, int> dict = new Dictionary<char, int>();
            int n = 0;
            foreach (string line in lines)
            {
                if (line == "")
                {
                    ans += dict.Where(x => x.Value == n).Count();
                    dict = new Dictionary<char, int>();
                    n = 0;
                }
                else
                {
                    foreach(char c in line)
                    {
                        if (!dict.ContainsKey(c))
                        {
                            dict[c] = 0;
                        }
                        dict[c]++;

                    }
                    n++;
                }
            }
            ans += dict.Where(x => x.Value == n).Count();
            Console.WriteLine("Result of 2nd task: {0}", ans);

        }
       

    }
}
