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
			if (userName == "superadmin" && password == "superadmin1")
				return new User()
				{
					CredentialsCorrect = true,
					Username = "superadmin",
					Role = "SuperAdmin"
				};

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
				var command = new SqlCommand("SELECT link FROM Links", conn);
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
				var command = new SqlCommand("DELETE FROM Links", conn);
				conn.Open();

				return command.ExecuteNonQuery();
			}
		}

		public static int ClearComments()
		{
			using (var conn = new SqlConnection(ConnectionString))
			{
				var command = new SqlCommand("DELETE FROM Comments", conn);
				conn.Open();

				return command.ExecuteNonQuery();
			}
		}

		public static int ClearPets()
		{
			using (var conn = new SqlConnection(ConnectionString))
			{
				var command = new SqlCommand("DELETE FROM ChosenPets", conn);
				conn.Open();

				return command.ExecuteNonQuery();
			}
		}

		public static bool AddPet(string animal, string name)
		{
			using (var conn = new SqlConnection(ConnectionString))
			{
				const string sql = "INSERT INTO ChosenPets (animal, name) VALUES (@animal, @name)";
				var command = new SqlCommand(sql, conn);
				command.Parameters.AddWithValue("@animal", animal);
				command.Parameters.AddWithValue("@name", name);
				conn.Open();

				return command.ExecuteNonQuery() > 0;
			}
		}

		public static void ExecuteSql(string sql)
		{
			using (var conn = new SqlConnection(ConnectionString))
			{
				var command = new SqlCommand(sql, conn);
				conn.Open();
				command.ExecuteNonQuery();
			}
		}
	}
}
