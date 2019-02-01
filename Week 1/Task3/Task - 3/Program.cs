using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_3
{
    class Program
    {
        // creat the method
        static void CopyVar(int n)
        {
            // creat string of array and input string of array without " "
            string[] arr = Console.ReadLine().Split();
            // creat string of array with double lenght of first array
            string[] copy = new string[(arr.Length * 2)];
            // creat a new val
            int a = 0;
            // creat a loop
            for(int i = 0; i < n; i++)
            {
                // copying ex. (copy[0] = arr[0])
                copy[a++] = arr[i];
                // copying ex. (copy[1] = arr[0])
                copy[a++] = arr[i];
            }
            // creat a loop of output the array
            for (int i = 0; i < copy.Length; i++)
            {
                // convert from string to int and out the array
                Console.Write(int.Parse(copy[i]));
            }
            
            

        } 
        static void Main(string[] args)
        {
            // creat a new value and input it
            int n = int.Parse(Console.ReadLine());
            // use the method to "CopyVar"
            CopyVar(n);
          
        }
    }
}
