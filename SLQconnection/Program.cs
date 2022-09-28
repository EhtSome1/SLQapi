using System;
using System.Data.SqlClient;
using System.Text;

namespace sqltest
{
    class Program
    {
        static void Main(string[] args)
        {
            string userId;
            string password;

            int vast = 0;

            try
            {

                Console.Write("UserID: ");
                userId = Console.ReadLine();

                Console.Write("\nPassword: ");
                password = Console.ReadLine();

                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                builder.DataSource = "firmaoydb.database.windows.net";
                builder.UserID = userId;
                builder.Password = password;
                builder.InitialCatalog = "FirmaOY";

                Console.Clear();

                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {
                    Console.WriteLine(userId);

                    Console.WriteLine("\nQuery data:");
                    Console.WriteLine("=========================================\n");
                    Console.Write("Anna taulu: ");
                    string taulu = Console.ReadLine();
                    String sql = "SELECT * FROM " + taulu;

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (vast != 9)
                            {
                                Console.WriteLine("1. 1.column");
                                Console.WriteLine("2. 2.column");
                                Console.WriteLine("3. 3.column");
                                Console.WriteLine("3. 4.column");
                                Console.WriteLine("9. Loppu");

                                vast = Convert.ToInt32(Console.ReadLine());
                                switch (vast)
                                {
                                    case 1:
                                        Console.WriteLine("ID");
                                        while (reader.Read())
                                        {
                                            Console.WriteLine(reader.GetValue(vast));
                                        }
                                        break;

                                    case 2:
                                        Console.WriteLine("username");
                                        while (reader.Read())
                                        {
                                            Console.WriteLine(reader.GetValue(vast));
                                        }
                                        break;
                                    case 3:
                                        Console.WriteLine("password");
                                        while (reader.Read())
                                        {
                                            Console.WriteLine(reader.GetValue(vast));
                                        }
                                        break;
                                    case 4:
                                        Console.WriteLine("update date");
                                        while (reader.Read())
                                        {
                                            Console.WriteLine(reader.GetValue(vast));
                                        }
                                        break;
                                    case 9:
                                        Console.WriteLine("Heippa!");
                                        break;

                                    default:
                                        Console.WriteLine("Antamallasi numerolla ei ole mitään!");
                                        break;
                                }

                            }

                         }

                    }
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }
            Console.ReadLine();
        }
    }
}