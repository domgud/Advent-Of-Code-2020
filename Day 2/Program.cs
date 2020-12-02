using System;
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
            //SolveFirst("failas.txt");
            Timer timer = new Timer();
            timer.Start();
            SolveFirst("e2p8ir.txt");
            timer.Stop();
            
            Console.WriteLine("Time elapsed: {0}", timer.Interval);
        }
        public static void SolveFirst(string FileName)
        {
            int counter = 0;
            foreach (string line in File.ReadLines(FileName))
            {
                string[] data = line.Split(new[] { '-', ' ', ':' }, StringSplitOptions.RemoveEmptyEntries);
                int from = int.Parse(data[0]);
                int to = int.Parse(data[1]);
                char ch = char.Parse(data[2]);
                string chars = data[3];

                int n = 0;
                foreach (var item in chars)
                {
                    if (item == ch) n++;
                }
                if (n >= from && n <= to)
                    counter++;
            }
            Console.WriteLine(counter);
        }
        public static void SolveSecond(string FileName)
        {
            int counter = 0;
            foreach (string line in File.ReadLines(FileName))
            {
                string[] data = line.Split(new[] { '-', ' ', ':' }, StringSplitOptions.RemoveEmptyEntries);
                int yes = int.Parse(data[0]);
                int no = int.Parse(data[1]);
                char ch = char.Parse(data[2]);
                string chars = data[3];

                if (chars[yes - 1] == ch^chars[no - 1] == ch)
                {
                    counter++;
                }
            }
            Console.WriteLine(counter);
        }

    }
}
