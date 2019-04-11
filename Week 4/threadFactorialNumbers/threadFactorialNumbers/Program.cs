using System;
using System.Threading;
namespace threadFactorialNumbers
{
    public class Task2
    {
        public static void Main(string[] args)
        {
            int n = Int32.Parse(Console.ReadLine());
            new Thread(() =>
            {
                Factorial(n);
            }).Start();
            new Thread(() =>
            {
                Sum(n);
            }).Start();
        }
        public static void Factorial(long n)
        {
            long result = 1;
            for (long i = 2; i <= n; i++)
            {
                result *= i;
                Console.WriteLine("Считаю факториал");
                Thread.Sleep(500);
            }
            Console.WriteLine("Факториал: " + result);
        }
        public static void Sum(long n)
        {
            long result = 1;
            for (long i = 2; i <= n; i++)
            {
                result += i;
                Console.WriteLine("Считаю сумму");
                Thread.Sleep(500);
            }
            Console.WriteLine("Сумма: " + result);
        }
    }
}