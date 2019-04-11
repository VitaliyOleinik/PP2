using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;

namespace SerializerClassPerson
{
    [Serializable]
    public class Employce
    {
        public string name;
        public int id;
        public int salary;
        public Employce() { }
        public Employce(string name, int id, int salary)
        {
            this.id = id;
            this.salary = salary;
            this.name = name;
        }
        public override string ToString()
        {
            return name + " " + id + " " + salary;
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            Employce person1 = new Employce("Vit", 3245678, 100);
            person1.salary += 50;
            XmlSerializer xml = new XmlSerializer(typeof(Employce));
            person1.salary += 50;
            FileStream fs = new FileStream("Person1.xml", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            xml.Serialize(fs, person1);
            fs.Close();
            // des
            FileStream fs1 = new FileStream("Person1.xml", FileMode.Open, FileAccess.ReadWrite);
            Employce person2 = (Employce)xml.Deserialize(fs1);
            person2.salary += 50;
            Console.WriteLine(person2);

            fs1.Close();
            
            
    
        }
    }
}
