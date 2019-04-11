using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;

namespace NewUser
{
    
    [Serializable]
    public class User
    {
        public string login;
        public string password;
        public User() { }
        public User(string login, string password)
        {
            this.login = login;
            this.password = password;
        }
        /*public override string ToString()
        {
            return login + " " + password;
        }*/
        /*public void Des(string fileName)
        {
            FileStream fs1 = new FileStream(fileName, FileMode.Open);
            XmlSerializer XML = new XmlSerializer(typeof(User));
            User user1 = (User)XML.Deserialize(fs1);
        }*/
        
        public static User Des(string fileName)
        {
            XmlSerializer xml = new XmlSerializer(typeof(User));
            using (Stream fs = new FileStream(fileName, FileMode.Open, FileAccess.ReadWrite))
            {
                return (User)xml.Deserialize(fs);
            } 
        }
        
        public void Ser(string fileName)
        {
            FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate);
            XmlSerializer xml = new XmlSerializer(typeof(User));
            xml.Serialize(fs, this);
            fs.Close();
        }
    }
    class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("What do you want, brooo?");
            Console.WriteLine("If you wanna reg, press 1");
            Console.WriteLine("If you wanna aut, press 2");
            int num;
            num = int.Parse(Console.ReadLine());
            string login;
            string password;
            if (num == 1)
            {
                Console.WriteLine("registration");
                Console.WriteLine("Please write login and then password");
                login = Console.ReadLine();
                password = Console.ReadLine();
                User user1 = new User(login, password);
                user1.Ser("Save.xml");
                // user1.Des("Save.xml");
            }

            if (num == 2)
            {
                Console.WriteLine("authorization");
                Console.WriteLine("Please write login and then password");
                login = Console.ReadLine();
                password = Console.ReadLine();
                User user3 = new User(login, password);
                user3.Ser("Save1.xml");
                
                /*FileStream fs1 = new FileStream("Save.xml", FileMode.Open);
                FileStream fs2 = new FileStream("Save1.xml", FileMode.Open);*/
                if (User.Des("Save.xml").login == user3.login && User.Des("Save.xml").password == user3.password) 
                {
                    Console.WriteLine("Succesful");
                }
                else
                {
                    Console.WriteLine("Sorry! You cannot do it");
                }
            }
        }
    }
}
