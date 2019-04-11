using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;

namespace Person
{
    public class Person
    {
        public int age;
        public string name;
        public int weight;
        public Person() { }
        public Person(string name, int weight, int age)
        {
            this.age = age;
            this.name = name;
            this.weight = weight;
        }
        public override string ToString()
        {
            return name + " " + age + " " + weight;
        }
        public void Ser(string fileName)
        {
            FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate);
            XmlSerializer XML = new XmlSerializer(typeof(Person));
            XML.Serialize(fs, this);
            fs.Close();
        }
        public void Des(string fileName)
        {
            FileStream fs1 = new FileStream(fileName, FileMode.Open);
            XmlSerializer XML = new XmlSerializer(typeof(Person));
            Person person2 = (Person)XML.Deserialize(fs1);
            Console.WriteLine(person2);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Person person = new Person("Vit", 73, 18);
            person.Ser("Ser.xml");
            person.Des("Ser.xml");
        }
        
    }
}
