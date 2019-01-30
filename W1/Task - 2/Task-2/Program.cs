using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_2
{
    // created class Student
    class Student
    {
        // created public string and int
        public string name;
        public string id;
        public int year;

        // created public method
        public Student(string name, string id, int year)
        {
        this.name = name;
        this.id = id;
        this.year = year;
        }
        // created public method, to print info about the student
        public void Print()
        {
            Console.WriteLine(name + " " + id + " " + year);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            // created name, which operator input
            string name = Console.ReadLine();
            // created id, which operator input
            string id = Console.ReadLine();
            // created int year, which converts to int 
            int year = int.Parse(Console.ReadLine());
            
            for (int i = 0; i < 4; i++)
            {
                Student a = new Student(name, id, year);
                year++;
                a.Print();
            }
            Console.ReadKey();
        }
    }
}
