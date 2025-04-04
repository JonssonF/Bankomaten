using System;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Threading;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hejsan och välkommen till mitt processar test.");



            Console.Write("Enter your password:  ");
            string password = Console.ReadLine();
            if (password == null)
            {
                return;
            }
            else
            {
                Process();
            }

            Console.ReadLine();

        }

        public static void Process()
        {
            string Proccess = "Processing...";
            string rounds = "1";
            foreach (char c in rounds)
            {
                Console.Clear();
                foreach (char d in Proccess)
                {
                    Console.Write(d);
                    Thread.Sleep(35);
                }
                Console.Clear();
                if (amount > allowed)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Transaction granted.");
                    Thread.Sleep(1500);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Transaction denied.");
                    Thread.Sleep(1500);
                }
                Console.ResetColor();
                Console.Clear();
            }
        }
    }
}
