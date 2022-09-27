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

            int vast;

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

                    Console.WriteLine("\nQuery data example:");
                    Console.WriteLine("=========================================\n");

                    String sql = "SELECT * FROM alponTaulu";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {

                        connection.Open();
                        while(true)
                        {
                            using (SqlDataReader reader = command.ExecuteReader())
                            {
                                vast = Convert.ToInt32(Console.ReadLine());

                                while (reader.Read())
                                {
                                    Console.WriteLine(reader.GetValue(vast).ToString());
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