using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;

namespace ComplexNumber
{
    public struct Complex
    {
        public int real;
        public int imaginary;
        public Complex(int real, int imaginary)
        {
            this.real = real;
            this.imaginary = imaginary;
        }
        public static Complex operator +(Complex one, Complex two)
        {
            return new Complex(one.real + two.real, one.imaginary + two.imaginary);
        }
        public override string ToString()
        {
            return (String.Format("{0} + {1}i", real, imaginary));
        }
        public void Save (string fileName)
        {
            FileStream fs = new FileStream(fileName, FileMode.Create);
            {
                XmlSerializer XML = new XmlSerializer(typeof(Complex));
                XML.Serialize(fs, this);
            }
        }
        public static Complex LoadFromFile(string FileName)
        {
            FileStream fs1 = new FileStream(FileName, FileMode.Open);
            {
                XmlSerializer XML = new XmlSerializer(typeof(Complex));
                return (Complex)XML.Deserialize(fs1);
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Complex complex = Complex.LoadFromFile("Complex.xml");
        }
    }
}
