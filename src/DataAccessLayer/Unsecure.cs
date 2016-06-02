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
			var user = new User();
			using (SqlConnection conn = new SqlConnection(ConnectionString))
			{
				SqlCommand command = new SqlCommand($"SELECT id, UserName FROM Users WHERE UserName = '{userName}' AND Password = '{password}'", conn);
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

		public static bool AddPet(string animal, string name)
		{
			bool result;
			using (SqlConnection conn = new SqlConnection(ConnectionString))
			{
				string sql = $"insert into ChosenPets (animal, name) values ('{animal}', '{name}')";
				SqlCommand command = new SqlCommand(sql, conn);
				conn.Open();
				result = command.ExecuteNonQuery() > 0;
			}
			return result;
		}

		public static Dictionary<string, int> GetPetCounters()
		{
			Dictionary<string, int> result = new Dictionary<string, int>();
			using (SqlConnection conn = new SqlConnection(ConnectionString))
			{
				SqlCommand command = new SqlCommand("select animal as Pet, count(*) as Count from ChosenPets group by animal", conn);
				conn.Open();

				SqlDataReader reader = command.ExecuteReader();

				while (reader.Read())
				{
					result.Add((string)reader["Pet"], (int)reader["Count"]);
				}
			}
			return result;
		}

		//public static string LastChosenPet()
		//{
		//	using (SqlConnection conn = new SqlConnection(ConnectionString))
		//	{
		//		SqlCommand command = new SqlCommand("select top 1 animal, name from ChosenPets order by id desc", conn);
		//		conn.Open();

		//		SqlDataReader reader = command.ExecuteReader();
		//		if (reader.Read())
		//		{
		//			return $"{reader.GetString(0)}, named: {reader.GetString(1)}";
		//		}
		//		else
		//		{
		//			return null;
		//		}
		//	}
		//}

		public static IEnumerable<string> GetPetsNames(string animal)
		{
			var result = new List<string>();
			using (var conn = new SqlConnection(ConnectionString))
			{
				var command = new SqlCommand($"select name from ChosenPets where animal = '{animal}'", conn);
				conn.Open();

				var reader = command.ExecuteReader();
				while (reader.Read())
				{
					result.Add((string)reader["name"]);
				}
			}
			return result;
		}

	//internal static DataSet GetChosenPets()
	//{
	//	using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Szkolenie"].ConnectionString))
	//	{
	//		SqlCommand command = new SqlCommand("select animal as Pet, count(*) as Count from ChosenPets group by animal", conn);
	//		conn.Open();

	//		DataSet dataSet = new DataSet("Pets");
	//		SqlDataAdapter adapter = new SqlDataAdapter(command);

	//		adapter.TableMappings.Add("ChosenPets", "Pets");
	//		adapter.Fill(dataSet);

	//		return dataSet;
	//	}
	//}

	//internal static void StoreChosenPet(string pet, string name)
	//{
	//	using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Szkolenie"].ConnectionString))
	//	{
	//		string sql = "insert into ChosenPets (animal, name) values ('" + pet + "', '" + name + "')";
	//		SqlCommand command = new SqlCommand(sql, conn);
	//		conn.Open();
	//		command.ExecuteNonQuery();
	//	}
	//}

	//internal static UserModel LogIn(string userName, string password)
	//{
	//	var user = new UserModel();

	//	using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Szkolenie"].ConnectionString))
	//	{
	//		SqlCommand command = new SqlCommand("SELECT id, UserName FROM Users WHERE UserName = '" + userName + "' AND Password = '" + password + "'", conn);
	//		conn.Open();

	//		SqlDataReader reader = command.ExecuteReader();

	//		while (reader.Read())
	//		{
	//			user.CredentialsCorrect = true;
	//			user.UserId = (int)reader["id"];
	//			user.Username = (string)reader["UserName"];
	//			break;
	//		}
	//	}

	//	return user;
	//}

	//internal static string LastChosenPet()
	//{
	//	using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Szkolenie"].ConnectionString))
	//	{
	//		SqlCommand command = new SqlCommand("select top 1 animal, name from ChosenPets order by id desc", conn);
	//		conn.Open();

	//		SqlDataReader reader = command.ExecuteReader();
	//		if (reader.Read())
	//		{
	//			return reader.GetString(0) + ", named: " + reader.GetString(1);
	//		}
	//		else
	//		{
	//			return null;
	//		}
	//	}
	//}

	//internal static void InsertLink(string link)
	//{
	//	using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Szkolenie"].ConnectionString))
	//	{
	//		SqlCommand command = new SqlCommand(string.Format("insert into Links (link) values ('{0}')", link), conn);
	//		conn.Open();

	//		command.ExecuteNonQuery();
	//	}
	//}

	//internal static DataSet GetLinks()
	//{
	//	using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Szkolenie"].ConnectionString))
	//	{
	//		SqlCommand command = new SqlCommand("select link from Links", conn);
	//		conn.Open();

	//		DataSet dataSet = new DataSet("LinksSet");
	//		SqlDataAdapter adapter = new SqlDataAdapter(command);

	//		adapter.TableMappings.Add("Links", "LinksSet");
	//		adapter.Fill(dataSet);

	//		return dataSet;
	//	}
	//}

	//internal static void AddComment(string comment)
	//{
	//	using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Szkolenie"].ConnectionString))
	//	{
	//		UserModel loggedInUser = AuthenticationService.GetLoggedInUser();

	//		SqlCommand command = new SqlCommand("insert into Comments (comment, user_id) values (@txt, @user_id)", conn);

	//		command.Parameters.Add(new SqlParameter("@txt", comment));
	//		command.Parameters.Add(new SqlParameter("@user_id", loggedInUser.UserId));

	//		conn.Open();
	//		command.ExecuteNonQuery();
	//	}
	//}

	//internal static DataSet GetNames(string animal)
	//{
	//	using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Szkolenie"].ConnectionString))
	//	{
	//		SqlCommand command = new SqlCommand(string.Format("select name from ChosenPets where animal = '{0}'", animal), conn);
	//		conn.Open();

	//		DataSet dataSet = new DataSet("ChosenPets");
	//		SqlDataAdapter adapter = new SqlDataAdapter(command);

	//		adapter.TableMappings.Add("Names", "ChosenPets");
	//		adapter.Fill(dataSet);

	//		return dataSet;
	//	}
	//}

	//internal static DataSet GetComments()
	//{
	//	using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Szkolenie"].ConnectionString))
	//	{
	//		UserModel loggedInUser = AuthenticationService.GetLoggedInUser();

	//		SqlCommand command = new SqlCommand("select comment from Comments where user_id = @currentUserId", conn);
	//		command.Parameters.Add(new SqlParameter("@currentUserId", loggedInUser.UserId));
	//		conn.Open();

	//		DataSet dataSet = new DataSet("CommentsSet");
	//		SqlDataAdapter adapter = new SqlDataAdapter(command);

	//		adapter.TableMappings.Add("Comments", "CommentsSet");
	//		adapter.Fill(dataSet);

	//		return dataSet;
	//	}
	//}

}
}
