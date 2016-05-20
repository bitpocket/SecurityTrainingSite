using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace Opole
{
    internal class SqlHelper
    {
        internal static DataSet GetChosenPets()
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Szkolenie"].ConnectionString))
            {
                SqlCommand command = new SqlCommand("select animal as Pet, count(*) as Count from ChosenPets group by animal", conn);
                conn.Open();

                DataSet dataSet = new DataSet("Pets");
                SqlDataAdapter adapter = new SqlDataAdapter(command);

                adapter.TableMappings.Add("ChosenPets", "Pets");
                adapter.Fill(dataSet);
                
                return dataSet;
            }           
        }

        internal static void StoreChosenPet(string pet, string name)
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Szkolenie"].ConnectionString))
            {
                string sql = "insert into ChosenPets (animal, name) values ('" + pet + "', '" + name + "')";
                SqlCommand command = new SqlCommand(sql, conn);
                conn.Open();
                command.ExecuteNonQuery();
            }
        }

        internal static bool CredentialsCorrect(string userName, string password)
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Szkolenie"].ConnectionString))
            {
                SqlCommand command = new SqlCommand("SELECT UserName FROM Users WHERE UserName = '" + userName + "' AND Password = '" + password + "'", conn);
                conn.Open();

                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        internal static string LastChosenPet()
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Szkolenie"].ConnectionString))
            {
                SqlCommand command = new SqlCommand("select top 1 animal, name from ChosenPets order by id desc", conn);
                conn.Open();

                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    return reader.GetString(0) + ", named: " + reader.GetString(1);
                }
                else
                {
                    return null;
                }
            }
        }

        internal static void InsertLink(string link)
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Szkolenie"].ConnectionString))
            {
                SqlCommand command = new SqlCommand(string.Format("insert into Links (link) values ('{0}')", link), conn);
                conn.Open();

                command.ExecuteNonQuery();
            }
        }

        internal static DataSet GetLinks()
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Szkolenie"].ConnectionString))
            {
                SqlCommand command = new SqlCommand("select link from Links", conn);
                conn.Open();

                DataSet dataSet = new DataSet("LinksSet");
                SqlDataAdapter adapter = new SqlDataAdapter(command);

                adapter.TableMappings.Add("Links", "LinksSet");
                adapter.Fill(dataSet);

                return dataSet;
            }
        }

        internal static void AddComment(string comment)
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Szkolenie"].ConnectionString))
            {
                SqlCommand command = new SqlCommand("insert into Comments (comment) values (@txt)", conn);

                command.Parameters.Add(new SqlParameter("@txt", comment));

                conn.Open();
                command.ExecuteNonQuery();
            }
        }

        internal static DataSet GetNames(string animal)
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Szkolenie"].ConnectionString))
            {
                SqlCommand command = new SqlCommand(string.Format("select name from ChosenPets where animal = '{0}'", animal), conn);
                conn.Open();

                DataSet dataSet = new DataSet("ChosenPets");
                SqlDataAdapter adapter = new SqlDataAdapter(command);

                adapter.TableMappings.Add("Names", "ChosenPets");
                adapter.Fill(dataSet);

                return dataSet;
            }
        }

        internal static DataSet GetComments()
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Szkolenie"].ConnectionString))
            {
                SqlCommand command = new SqlCommand("select comment from Comments", conn);
                conn.Open();

                DataSet dataSet = new DataSet("CommentsSet");
                SqlDataAdapter adapter = new SqlDataAdapter(command);

                adapter.TableMappings.Add("Comments", "CommentsSet");
                adapter.Fill(dataSet);

                return dataSet;
            }
        }
    }
}