using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.IO;

namespace DataGiperConsoleBase
{
    class DataBase
    {
        public SQLiteConnection connection;
        public DataBase()
        {
            string path = @"C:\Work\Test.db";
            connection = new SQLiteConnection("DataSource = " + path);
            if (!File.Exists(path))
            {
                Console.WriteLine("DataBase created");
                SQLiteConnection.CreateFile(path);
            }
            // rename the database
            /*
            else
            {
                string path1 = @"C:\Work\Test.db";
                File.Move(path, path1);
                Console.WriteLine("DataBase renamed");
                //SQLiteConnection.CreateFile(path);
            }*/
        }
        public void OpenConnection()
        {
            if (connection.State != System.Data.ConnectionState.Open)
                connection.Open();
        }
        public void CloseConnection()
        {
            if (connection.State != System.Data.ConnectionState.Closed)
                connection.Close();
        }
    }
}
