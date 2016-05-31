using System.Collections.Generic;
using System.Data.SqlClient;
using DataAccessLayer.Models;

namespace DataAccessLayer
{
	public static class Secure
	{
		public static string ConnectionString { get; set; } = "Server = (localdb)\\mssqllocaldb;Database=SecurityTraining";

		public static User LogIn(string userName, string password)
		{
			var user = new User();

			using (SqlConnection conn = new SqlConnection(ConnectionString))
			{
				SqlCommand command = new SqlCommand("SELECT id, UserName FROM Users WHERE UserName = @userName AND Password = @password", conn);
				command.Parameters.AddWithValue("@userName", userName);
				command.Parameters.AddWithValue("@password", password);
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

		public static List<Link> GetLinks()
		{
			List<Link> links = new List<Link>();

			using (SqlConnection conn = new SqlConnection(ConnectionString))
			{
				SqlCommand command = new SqlCommand("select link from Links", conn);
				conn.Open();

				SqlDataReader reader = command.ExecuteReader();

				while (reader.Read())
				{
					links.Add(new Link()
					{
						link = (string)reader["link"]
					});
				}

				return links;
			}
		}
	}
}
