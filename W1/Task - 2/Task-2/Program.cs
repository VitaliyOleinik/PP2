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
        // created public method, which prints info about the student
        public void Print()
        {
            Console.WriteLine(name + " " + id + " " + year);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            // declared string (name), which operator inputs
            string name = Console.ReadLine();
            // declared string (id), which operator inputs
            string id = Console.ReadLine();
            // declared int (year), which converts to int from string
            int year = int.Parse(Console.ReadLine());
            // created a loop, which increment year
            for (int i = 0; i < 4; i++)
            {
                // created a value for class Student and created a new person using method Student
                Student a = new Student(name, id, year);
                year++;
                // call method Print, which will write student "a" info
                a.Print();
            }
            // created for cmd, will close after click any key (cmd)
            Console.ReadKey();
        }
    }
}
