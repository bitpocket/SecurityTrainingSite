using System.Collections.Generic;
using System.Data.SqlClient;
using DataAccessLayer.Models;

namespace DataAccessLayer
{
	public static class Secure
	{
		public static string ConnectionString { private get; set; }

		public static User LogIn(string userName, string password)
		{
			var user = new User();

			using (var conn = new SqlConnection(ConnectionString))
			{
				var command = new SqlCommand("SELECT id, UserName FROM Users WHERE UserName = @userName AND Password = @password", conn);
				command.Parameters.AddWithValue("@userName", userName);
				command.Parameters.AddWithValue("@password", password);
				conn.Open();

				var reader = command.ExecuteReader();

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

		public static List<string> GetLinks()
		{
			var links = new List<string>();

			using (var conn = new SqlConnection(ConnectionString))
			{
				var command = new SqlCommand("select link from Links", conn);
				conn.Open();

				var reader = command.ExecuteReader();

				while (reader.Read())
				{
					links.Add((string)reader["link"]);
				}

				return links;
			}
		}

		public static int ClearLinks()
		{
			using (var conn = new SqlConnection(ConnectionString))
			{
				var command = new SqlCommand("delete from Links", conn);
				conn.Open();

				return command.ExecuteNonQuery();
			}
		}

		public static int ClearComments()
		{
			using (var conn = new SqlConnection(ConnectionString))
			{
				var command = new SqlCommand("delete from Comments", conn);
				conn.Open();

				return command.ExecuteNonQuery();
			}
		}

		public static int ClearPets()
		{
			using (var conn = new SqlConnection(ConnectionString))
			{
				var command = new SqlCommand("delete from ChosenPets", conn);
				conn.Open();

				return command.ExecuteNonQuery();
			}
		}
	}
}
