using System;
using System.IO;
using System.Linq;

namespace Day01
{
    class Program
    {
        public static int size = 200;
        static void Main(string[] args)
        {
            int[] masyvas = ReadFile("failas.txt");
            findTriplets(masyvas, masyvas.Length-1);
        }
        public static int[] ReadFile(string FileName)
        {
            int[] arr = new int[size];
            int i = 0;
            foreach (var line in File.ReadLines(FileName))
            {
                arr[i++] = int.Parse(line);
            }
            return arr;
        }
        public static void findTriplets(int []arr, int n)
        {
            bool found = false;

            Array.Sort(arr);

            for (int i = 0; i < n-1; i++)
            {
                int l = i + 1;
                int r = n - 1;
                int x = arr[i];
                while (l < r)
                {
                    
                    if (x + arr[l] + arr[r] == 2020)
                    {
                        Console.Write(x + " ");
                        Console.Write(arr[l] + " ");
                        Console.Write(arr[r] + " ");
                        Console.WriteLine();
                        Console.WriteLine(x*arr[l]*arr[r]);
                        l++;
                        r--;
                        found = true;
                    }

                    else if (x + arr[l]+ arr[r]<2020)
                    {
                        l++;
                    }

                    else
                    {
                        r--;
                    }
                }
                if (!found)
                {
                    Console.WriteLine("Not found");
                }
            }
        }
    }
}
