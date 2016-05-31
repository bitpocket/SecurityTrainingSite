using System;
using System.Data.SqlClient;
using DataAccessLayer.Models;

namespace DataAccessLayer
{
	public static class Unsecure
	{
		private static string ConnectionString { get; } = "Server = (localdb)\\mssqllocaldb;Database=SecurityTraining";

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

		public static void InsertLink(string link)
		{
			using (SqlConnection conn = new SqlConnection(ConnectionString))
			{
				SqlCommand command = new SqlCommand($"insert into Links (link) values ('{link}')", conn);
				conn.Open();

				command.ExecuteNonQuery();
			}
		}
	}
}
