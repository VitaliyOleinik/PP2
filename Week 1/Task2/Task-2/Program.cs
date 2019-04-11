using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.IO;

namespace Task_2
{
    [Serializable()]
    // created class Student
    class Student : ISerializable
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

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            throw new NotImplementedException();
        }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            // declared string (name), which operator inputs
            string name = "Vit";
            // declared string (id), which operator inputs
            string id = "56789";
            // declared int (year), which converts to int from string
            int year = 2000;
            Student a = new Student(name, id, year);
            // serialization
            FileStream fs = new FileStream("Student.dat", FileMode.Create);
            BinaryFormatter formatter = new BinaryFormatter();
            
            
            try
            {
                formatter.Serialize(fs, a);
            }
            catch (SerializationException e)
            {
                Console.WriteLine("faled: " + e.Message);
                throw;
            }
            finally
            {
                fs.Close();
            }
            // deserialiazation
            FileStream fs1 = new FileStream("Student.dat", FileMode.Open);
            try
            {
                BinaryFormatter formatter1 = new BinaryFormatter();
                a = (Student)formatter.Deserialize(fs);
            }
            catch (SerializationException e)
            {
                Console.WriteLine("Faled: " + e.Message);
                throw;
            }
            finally
            {
                fs1.Close();
            }
            // created for cmd, will close after click any key (cmd)
            Console.ReadKey();
        }
    }
}
