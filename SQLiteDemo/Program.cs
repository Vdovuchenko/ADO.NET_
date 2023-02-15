using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SQLite;

namespace SQLiteDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = @"Data Source=sqlite.db;*Version=3;New=True;Compress=True;";
            SQLiteConnection connection = new SQLiteConnection(connectionString);
            connection.Open();
            int choose;
            do
            {
                Console.WriteLine("Select an option from the list below");
                Console.WriteLine("0 - Get all tables");
                Console.WriteLine("1 - Add row to the table");
                Console.WriteLine("2 - Request with table joins");
                Console.WriteLine("3 - Request with filtering");
                Console.WriteLine("4 - Request with aggregate function");
                Console.WriteLine("5 - Close");

                choose = Int32.Parse(Console.ReadLine());
               
                switch (choose)
                {
                    case 0:
                        {
                            DisplayData(connection, "SELECT * from SERVICE_STATION", 0);
                            DisplayData(connection, "SELECT * from EMPLOYEE", 1);
                            DisplayData(connection, "SELECT * from SERVICE", 2);
                            DisplayData(connection, "SELECT * from MOTORIST", 3);
                            DisplayData(connection, "SELECT * from INVOICE", 4);
                            break;
                        }
                    case 1:
                        {
                            try
                            {
                                int id;
                                Console.WriteLine("Write id:");
                                id = Int32.Parse(Console.ReadLine());
                                AddRow(connection, "SERVICE_STATION", new object[] { id, "Service Station 1", "Address 1", "45686869", "8" });
                                AddRow(connection, "EMPLOYEE", new object[] { id, "Employee 1", "SS001", "10000", "4", "3" });
                                AddRow(connection, "SERVICE", new object[] { id, "Service 1", "100" });
                                AddRow(connection, "MOTORIST", new object[] { id, "Motorist 1", "Address 1", "465313943", "678643697843" });
                                AddRow(connection, "INVOICE", new object[] { id, "2022-01-01", "100" });
                            }catch(Exception e)
                            {
                                Console.WriteLine("This id exists");
                            }
                            break;
                        }
                    case 2:
                        {
                            string joinQuery = "SELECT EMPLOYEE.Name AS EmployeeName, SERVICE_STATION.Name AS StationName " +
                                "FROM EMPLOYEE " +
                                "INNER JOIN SERVICE_STATION " +
                                "ON EMPLOYEE.Service_station_id = SERVICE_STATION.id";
                            DisplayData(connection, joinQuery, 0);
                            break;
                        }
                    case 3:
                        {
                            string filterQuery = "SELECT * FROM INVOICE " +
                                  "WHERE INVOICE.date >= '2022-02-01'";
                            DisplayData(connection, filterQuery, 0);
                            break;
                        }
                    case 4:
                        {
                            string aggregateQuery = "SELECT SUM(Amount) AS TotalAmount " +
                                     "FROM INVOICE";
                            DisplayData(connection, aggregateQuery, 0);
                            break;
                        }
                }
            } while (choose != 5);

            connection.Close();
            
        }

        static void DisplayData(SQLiteConnection connection, string com, int tableName)
        {
            SQLiteCommand command = new SQLiteCommand(com, connection);
            SQLiteDataReader reader = command.ExecuteReader();
            Console.WriteLine("Data from " + reader.GetTableName(tableName).ToString() + ":");

            for (int i = 0; i < reader.FieldCount; i++) {
                string a = reader.GetName(i);
                Console.Write("{0, -18}", a);
            }

            Console.WriteLine();

            while (reader.Read())
            {
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    string a = reader[i].ToString();
                    Console.Write("{0, -18}", a);
                }
                Console.WriteLine();
            }

            Console.WriteLine();
        }
        static void AddRow(SQLiteConnection connection, string tableName, object[] values)
        {
            string query = "INSERT INTO " + tableName + " VALUES (";
            for (int i = 0; i < values.Length; i++)
            {
                query += "@value" + i + ", ";
            }
            query = query.Remove(query.Length - 2) + ")";
            SQLiteCommand command = new SQLiteCommand(query, connection);

            for (int i = 0; i < values.Length; i++)
            {
                command.Parameters.AddWithValue("@value" + i, values[i]);
            }

            command.ExecuteNonQuery();
        }
    }
}