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

        public class Operation
        {
            public string OP; //operation
            public bool Done; //isdone
            public int Par; //parameter
            public Operation(string op, int par)
            {
                OP = op;
                Par = par;
                Done = false;
            }
        }



        public static List<Operation> ReadData(string path)
        {
            List<Operation> data = new List<Operation>();
            StreamReader reader = File.OpenText(path);
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                string[] linesplit = line.Split(' ');
                data.Add(new Operation(linesplit[0], int.Parse(linesplit[1])));
            }
            return data;
        }

        
        public static void  SolveFirst()
        {
            int index = 0;
            int acc = 0;
            List<Operation> operations = ReadData("failas.txt");
            while (true)
            {
                Operation operation = operations[index];
                if (operation.Done) break;

                if (operation.OP == "nop")
                {
                    index++;
                    operation.Done = true;
                }
                else if (operation.OP == "jmp")
                {
                    index += operation.Par;
                    operation.Done = true;
                }
                else if (operation.OP == "acc")
                {
                    acc += operation.Par;
                    index++;
                    operation.Done = true;
                }
            }
            Console.WriteLine("Result of first task is {0}", acc);

        }

       
        
        //dear god save me from this code
        //in my defense installing cuda fricked my VS so it was like typing it out in notepad :(
        public static void SolveSecond()
        {
            List<Operation> operations = ReadData("failas.txt");
            foreach (var item in operations)
            {
                if (item.OP != "acc")
                {
                    int index = 0;
                    int acc = 0;
                    item.OP = item.OP == "jmp" ? "nop" : "jmp";
                    while (true)
                    {
                        Operation operation = operations[index];
                        if (operation.Done) break;

                        if (operation.OP == "nop")
                        {
                            index++;
                            operation.Done = true;
                        }
                        else if (operation.OP == "jmp")
                        {
                            index += operation.Par;
                            operation.Done = true;
                        }
                        else if (operation.OP == "acc")
                        {
                            acc += operation.Par;
                            index++;
                            operation.Done = true;
                        }



                        if (index == operations.Count)
                        {
                            Console.WriteLine(acc);
                            break;
                        }
                    }
                    foreach (var oper in operations)
                    {
                        oper.Done = false;
                    }
                    item.OP = item.OP == "jmp" ? "nop" : "jmp";
                }
                
                


            }

        }
       

    }
}
