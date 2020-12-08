using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Tracing;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Timers;

namespace Day01
{
    class Program
    {
        static void Main(string[] args)
        {
            SolveSecond();

        }

        public class Bag
        {
            public string name;
            public Dictionary<Bag, int> children;
            public Bag(string n)
            {
                name = n;
                children = new Dictionary<Bag, int>();
            }
        };

        public static Dictionary<string, Bag> ReadData(string path)
        {
            StreamReader reader = File.OpenText(path);
            var bags = new Dictionary<string, Bag>();
            Bag GetBag(string s) //helper method to get the bag reference
            {
                if (bags.ContainsKey(s))
                    return bags[s];
                Bag n = new Bag(s);
                bags[s] = n;
                return n;
            }
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                string[] dad = line.Split(" bags contain ").ToArray(); //ARE YA WINNING SON?
                string[] sons = dad[1].Split(", ").ToArray(); //no im crashing :(
                Bag bag = GetBag(dad[0]);
                if (!sons[0].Contains("no other"))
                {
                    for (int i = 0; i < sons.Length; i++)
                    {
                        Regex parts = new Regex(@"(\d+) (\w+ \w+)"); // 1 or more digit, 2 or more words
                        MatchCollection matches = parts.Matches(sons[i]);
                        if (matches.Count > 0)
                        {
                            GroupCollection groups = matches[0].Groups;
                            string n = groups[2].Value; //the actual color not some fancy words
                            Bag child = GetBag(n);
                            bag.children[child] = int.Parse(groups[1].Value);
                        }
                    }
                }
            }
            return bags;

        }

        public static bool ContainsInside(Bag bag, Bag inside)
        {
            return bag.children.Where(x => x.Key == inside || ContainsInside(x.Key, inside)).Count() > 0;
        }
        public static void  SolveFirst()
        {
            var bags = ReadData("failas.txt");
            Bag our = bags["shiny gold"];
            int ans = bags.Where(x => ContainsInside(x.Value, our)).Count();
            Console.WriteLine("Result of first task:{0}", ans);


        }

        public static long BagsContained(Bag bag)
        {
            return bag.children.Select(x => x.Value * (BagsContained(x.Key) + 1)).Sum();
        }
        public static void SolveSecond()
        {
            var bags = ReadData("failas.txt");
            Bag our = bags["shiny gold"];
            long ans = BagsContained(our);
            Console.WriteLine("Result of second task:{0}", ans);
        }
       

    }
}
