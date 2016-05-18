using System.Data.SqlClient;

namespace DataAccessLayer
{
	public class SQLHelper
	{
		public static string ConnectionString { get; set; } = "Server = (localdb)\\mssqllocaldb;Database=SecurityTraining";

		public static User LogIn(string userName, string password)
		{
			var user = new User();

			using (SqlConnection conn = new SqlConnection(ConnectionString))
			{
				SqlCommand command = new SqlCommand("SELECT id, UserName FROM Users WHERE UserName = '" + userName + "' AND Password = '" + password + "'", conn);
				conn.Open();

				SqlDataReader reader = command.ExecuteReader();

				while (reader.Read())
				{
					user.CredentialsCorrect = true;
					user.UserId = (int)reader["id"];
					user.Username = (string)reader["UserName"];
					break;
				}
			}

			return user;
		}

	}
}
