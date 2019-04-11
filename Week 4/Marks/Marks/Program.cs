using System;
using System.Xml.Serialization;
using System.IO;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Lab4
{

    [Serializable]
    public class Mark
    {
        private int points;
        private String letter;

        public Mark() { }

        public Mark(int points)
        {
            this.Points = points;
        }

        public int Points
        {
            get
            {
                return points;
            }
            set
            {
                if (value >= 100)
                    points = 100;
                else if (value <= 0)
                    points = 0;
                else
                    points = value;

                letter = getLetter();

            }
        }

        public string Letter
        {
            get { return letter; }
            set { letter = value; }
        }

        public string getLetter()
        {
            if (points >= 95)
                return "A";
            if (points >= 90 && points <= 94)
                return "A-";
            if (points >= 85 && points <= 89)
                return "B+";
            if (points >= 80 && points <= 84)
                return "B";
            if (points >= 75 && points <= 79)
                return "B-";
            if (points >= 70 && points <= 74)
                return "C+";
            if (points >= 65 && points <= 69)
                return "C";
            if (points >= 60 && points <= 64)
                return "C-";
            if (points >= 55 && points <= 59)
                return "D+";
            if (points >= 50 && points <= 54)
                return "D";
            return "F";
        }

        public void SerializeToXmlFile(String fileName)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Mark));
            using (StreamWriter writer = new StreamWriter(fileName))
            {
                serializer.Serialize(writer, this);
            }
        }

        public void SerializeToBinaryFile(String fileName)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, this);
            }
        }

        public override string ToString()
        {
            return "Mark{\n"
                + "    points: " + this.Points + "\n"
                + "    letter: " + getLetter() + "\n"
            + "}";
        }

        public static Mark DeserializeFromXmlFile(String fileName)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Mark));
            using (FileStream inputStream = new FileStream(fileName, FileMode.Open))
            {
                return (Mark)serializer.Deserialize(inputStream);
            }
        }

        public static Mark DeserializeFromBinaryFile(String fileName)
        {
            IFormatter formatter = new BinaryFormatter();
            using (FileStream stream = File.Open(fileName, FileMode.Open))
            {
                return (Mark)formatter.Deserialize(stream);
            }
        }

    }

    class Task2
    {
        public static void Main(string[] args)
        {
            Random random = new Random();
            List<Mark> marks = new List<Mark>();

            Directory.CreateDirectory("serializedMarks");

            int amountOfFakeData = random.Next(5, 100);

            for (int i = 0; i < amountOfFakeData; i++)
            {
                int points = random.Next(0, 100);
                marks.Add(new Mark(points));
            }

            for (int i = 0; i < marks.Count; i++)
            {
                marks[i].SerializeToXmlFile("serializedMarks/mark" + i + ".xml");
                marks[i].SerializeToBinaryFile("serializedMarks/mark" + i + ".bin");
            }

            marks = new List<Mark>();

            for (int i = 0; i < amountOfFakeData; i++)
            {
                marks.Add(Mark.DeserializeFromXmlFile("serializedMarks/mark" + i + ".xml"));
                Console.WriteLine("XML: " + marks[i]);
                Console.WriteLine("Binary: " + Mark.DeserializeFromBinaryFile("serializedMarks/mark" + i + ".bin"));
            }

        }
    }

}