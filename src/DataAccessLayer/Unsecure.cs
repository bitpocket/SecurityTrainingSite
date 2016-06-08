using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using DataAccessLayer.Models;

namespace DataAccessLayer
{
	public static class Unsecure
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
				string sql = $"SELECT id, UserName FROM Users WHERE UserName = '{userName}' AND Password = '{password}'";
				var command = new SqlCommand(sql, conn);
				conn.Open();

				var reader = command.ExecuteReader();
				while (reader.Read())
				{
					user.CredentialsCorrect = true;
					user.UserId = (int)reader["id"];
					user.Username = (string)reader["UserName"];
					user.Role = "User";
					break;
				}
			}
			return user;
		}

		public static void InsertLink(string link)
		{
			using (var conn = new SqlConnection(ConnectionString))
			{
				string sql = $"insert into Links (link) values ('{link}')";
				var command = new SqlCommand(sql, conn);
				conn.Open();
				command.ExecuteNonQuery();
			}
		}

		public static bool AddPet(string animal, string name)
		{
			bool result;
			using (var conn = new SqlConnection(ConnectionString))
			{
				string sql = $"insert into ChosenPets (animal, name) values ('{animal}', '{name}')";
				var command = new SqlCommand(sql, conn);
				conn.Open();
				result = command.ExecuteNonQuery() > 0;
			}
			return result;
		}

		public static IEnumerable<string> GetPetsNames(string animal)
		{
			var result = new List<string>();
			using (var conn = new SqlConnection(ConnectionString))
			{
				string sql = $"select name from ChosenPets where animal = '{animal}'";
				var command = new SqlCommand(sql, conn);
				conn.Open();

				var reader = command.ExecuteReader();
				while (reader.Read())
				{
					result.Add((string)reader["name"]);
				}
			}
			return result;
		}

		public static void AddComment(string comment, string userId)
		{
			using (var conn = new SqlConnection(ConnectionString))
			{
				var command = new SqlCommand("insert into Comments (comment, user_id) values (@txt, @user_id)", conn);

				command.Parameters.Add(new SqlParameter("@txt", comment));
				command.Parameters.Add(new SqlParameter("@user_id", userId));

				conn.Open();
				command.ExecuteNonQuery();
			}
		}

		public static IEnumerable<string> GetComments(string userId)
		{
			var result = new List<string>();
			using (SqlConnection conn = new SqlConnection(ConnectionString))
			{

				SqlCommand command = new SqlCommand("select comment from Comments where user_id = @currentUserId", conn);
				command.Parameters.Add(new SqlParameter("@currentUserId", userId));
				conn.Open();

				var reader = command.ExecuteReader();
				while (reader.Read())
				{
					result.Add((string)reader["comment"]);
				}
			}
			return result;
		}
	}
}
