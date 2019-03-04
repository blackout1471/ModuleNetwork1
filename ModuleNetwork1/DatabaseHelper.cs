using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleNetwork1
{
    class DatabaseHelper
    {
        public static string ConnectionString =
            "Data Source=192.168.1.4,1433\\MSSQLSERVER;Network Library=DBMSSOCN;Initial Catalog=RackUdstyr;User ID=sa;Password=!Admin123;";

        public static string ExecuteFunction(string functionName, string[] parameters)
        {
            StringBuilder cmd = new StringBuilder();
            cmd.Append("EXEC " + functionName + " ");
            for (int i = 0; i < parameters.Length; i++)
            {
                cmd.Append(parameters[i]);
                if (i != parameters.Length - 1)
                {
                    cmd.Append(",");
                }
            }

            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                using (SqlCommand command = new SqlCommand(cmd.ToString(), connection))
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                }
                return "Success!";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        public static string[,] GetTable(string table)
        {
            int colAmount = GetColumnAmount(table);
            int rowAmount = GetRowAmount(table);
            string[,] output = new string[rowAmount,colAmount];
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            using (SqlCommand command = new SqlCommand("SELECT * FROM " + table, connection))
            {
                connection.Open();  
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    int i = 0;
                    while (reader.Read())
                    {
                        for (int j = 0; j < colAmount; j++)
                        {
                            output[i,j] = reader[j].ToString();
                        }
                        i++;
                    }
                }
            }

            return output;
        }

        public static int GetColumnAmount(string table)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            using (SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM INFORMATION_SCHEMA.COLUMNS WHERE table_catalog = 'RackUdstyr' AND table_name = '" + table + "'", connection))
            {
                connection.Open();  
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    reader.Read();
                    return int.Parse(reader[0].ToString());
                }
            }
        }

        public static int GetRowAmount(string table)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            using (SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM " + table, connection))
            {
                connection.Open();  
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    reader.Read();
                    return int.Parse(reader[0].ToString());
                }
            }
        }
    }
}
