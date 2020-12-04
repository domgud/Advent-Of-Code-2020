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
        static void Main(string[] args)
        {
            //SolveFirst();
            SolveSecond();
        }
        public static List<Dictionary<string, string>> ReadData(string FileName)
        {
            StreamReader reader = File.OpenText(FileName);
            List<Dictionary<string, string>> list = new List<Dictionary<string, string>>();
            Dictionary<string, string> dict = new Dictionary<string, string>();
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                if (line != "")
                {
                    string[] data = line.Split(' ').ToArray(); // fieldname:data
                    foreach (string item in data)
                    {
                        string[] field = item.Split(':').ToArray(); //split into field name and the data
                        dict[field[0]] = field[1]; //put into the dictionary name:data
                    }
                }
                else
                {
                    list.Add(dict);
                    dict = new Dictionary<string, string>();
                }
                
            }
            if (dict.Count() > 0)
            {
                list.Add(dict);
            }
            return list;
        }
        public static void  SolveFirst()
        {
            List<Dictionary<string, string>> input = ReadData("failas.txt");
            int valid = 0;
            foreach (var d in input)
            {
                int n = 0;
                n += d.ContainsKey("byr") ? 1 : 0;
                n += d.ContainsKey("iyr") ? 1 : 0;
                n += d.ContainsKey("eyr") ? 1 : 0;
                n += d.ContainsKey("hgt") ? 1 : 0;
                n += d.ContainsKey("hcl") ? 1 : 0;
                n += d.ContainsKey("ecl") ? 1 : 0;
                n += d.ContainsKey("pid") ? 1 : 0;
                if (n >= 7)
                    valid++;
            }
            Console.WriteLine("Answer of first task {0}", valid);
        }

        public static void SolveSecond()
        {
            List<Dictionary<string, string>> input = ReadData("failas.txt");
            int valid = 0;
            foreach (var d in input)
            {
                int n = 0;
                if (d.ContainsKey("byr"))
                {
                    int a = int.Parse(d["byr"]);
                    if (a >= 1920 && a <= 2002)
                        n++;
                }
                if (d.ContainsKey("iyr"))
                {
                    int a = int.Parse(d["iyr"]);
                    if (a >= 2010 && a <= 2020)
                        n++;
                }
                if (d.ContainsKey("eyr"))
                {
                    int a = int.Parse(d["eyr"]);
                    if (a >= 2020 && a <= 2030)
                        n++;
                }
                if (d.ContainsKey("hgt"))
                {
                    string s = d["hgt"];
                    int a = 0;
                    if (s.Length > 2)
                        a = int.Parse(s.Remove(s.Length - 2));
                    if (s.EndsWith("cm") && a >= 150 && a <= 193)
                        n++;
                    else if (s.EndsWith("in") && a >= 59 && a <= 76)
                        n++;
                }
                if (d.ContainsKey("hcl"))
                {
                    string s = d["hcl"];
                    if (s.Length == 7 && s[0] == '#')
                    {
                        string hex = new string(s.Where(Uri.IsHexDigit).ToArray()); // <3 c# built in methods
                        if (hex.Length == 6)
                            n++;
                    }
                }
                if (d.ContainsKey("ecl"))
                {
                    string s = d["ecl"];
                    if (s == "amb" || s == "blu" || s == "brn" || s == "gry" || s == "grn" || s == "hzl" || s == "oth")
                        n++;
                }
                if (d.ContainsKey("pid"))
                {
                    string s = d["pid"];
                    string dec = new string(s.Where(char.IsDigit).ToArray());
                    if (dec.Length == 9)
                        n++;
                }
                if (n >= 7)
                    valid++;
            }
            Console.WriteLine("Answer of second task {0}", valid);
        }

    }
}
