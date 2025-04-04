using Microsoft.Data.SqlClient;

namespace Lektion_med_Petter_REPETION.Services
{
    internal class ADOService
    {
        private static readonly string _connectionString = @"Data Source=localhost;Database=MemberRegistry;Integrated Security=True; Trust Server Certificate=true;";

        public static void ShowMembers()
        {
            string query = @"SELECT * FROM Members";
            ExecuteQuery(query, 25);
        }

        public static void ShowActivities()
        {
            ExecuteQuery(@"SELECT * FROM Activities", 25);
        }

        public static void ShowMembersAndActivities()
        {
            string query = @"SELECT 
                            FirstName,
                            LastName,
                            Age,
                            a.Name
                            FROM Members m
                            JOIN ActivityParticipation ap ON m.MemberID = ap.MemberID
                            JOIN Activities a ON a.ActivityID = ap.ActivityID";
            ExecuteQuery(query, 15);
        }
        public static void ExecuteQuery(string query, int padding)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                

                SqlCommand command = new SqlCommand(query, connection);

                try
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                Console.Write(reader[i].ToString().PadRight(padding));
                            }
                            Console.WriteLine();
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
