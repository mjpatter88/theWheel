using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

// This solution shows a couple methods for generating Fibonacci numbers
// http://en.wikipedia.org/wiki/Fibonacci_number
namespace Fibonacci
{
    class Program
    {
        static void Main(string[] args)
        {
            int range = 40;
            int range2 = 1000;
            System.Console.WriteLine("Fibonacci Number Generation");
            //for (int i = 0; i < range2; i++)
            //{
            //    System.Console.WriteLine(i + ":" + recFibGen(i) + " ");
            //}
            //for (int i = 0; i < range; i++)
            //{
            //    System.Console.WriteLine(i + ":" + iterFibGen(i) + " ");
            //}

            System.Console.WriteLine("Recursive...");
            System.Console.WriteLine(range + ":" + recFibGen(range) + " ");
            System.Console.WriteLine("Iterative...");
            System.Console.WriteLine(range + ":" + iterFibGen(range) + " ");
            System.Console.WriteLine(range2 + ":" + iterFibGen(range2) + " ");

            System.Console.Read();

        }

        static long recFibGen(int num)
        {
            if(num < 0)
            {
                throw new System.ArgumentException("Cannot generate a negative Fibonacci Number.");
            }
            else if(num == 0)
            {
                return 0;
            }
            else if(num == 1)
            {
                return 1;
            }
            else
            {
                return recFibGen(num - 1) + recFibGen(num - 2);
            }
        }

        static BigInteger iterFibGen(int num)
        {
            BigInteger temp = 0;
            BigInteger numA = 0;
            BigInteger numB = 1;

            if(num < 0)
            {
                throw new System.ArgumentException("Cannot generate a negative Fibonacci Number.");
            }
            else if(num == 0)
            {
                return numA;
            }
            else if(num == 1)
            {
                return numB;
            }
            else
            {
                for (int i = 1; i < num; i++)
                {
                    temp = numA + numB;
                    numA = numB;
                    numB = temp;
                }
                return numB;
            }
        }
    }
}
