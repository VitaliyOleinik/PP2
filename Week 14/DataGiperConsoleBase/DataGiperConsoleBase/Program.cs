using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
namespace DataGiperConsoleBase
{
    class Program
    {
        static void Main(string[] args)
        {
            DataBase dataBase = new DataBase();
            dataBase.OpenConnection();
            /*
             * * добавляем в таблицу значения
             * 
            string query = "insert into students(name, surname) values (@name, @surname)";
            SQLiteCommand command = new SQLiteCommand(query, dataBase.connection);
            
            command.Parameters.AddWithValue("@name", "Danil");
            command.Parameters.AddWithValue("@surname", "Yakunin");
            
            var result = command.ExecuteNonQuery();
            Console.WriteLine(result);
            */
            string query = "select * from students";
            SQLiteCommand command = new SQLiteCommand(query, dataBase.connection);
            SQLiteDataReader result = command.ExecuteReader();
            string push = "     ";
            if (result.HasRows)
            {
                while (result.Read())
                {
                    Console.WriteLine("Name = {0},"+ push +" Surname = {1},"+push+" ID = {2}",
                        result["name"], result["surname"], result["id"]);
                }
            }
            dataBase.CloseConnection();
            Console.ReadKey();
        }
    }
}
