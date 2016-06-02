using DataAccessLayer.Models;
using Xunit;

namespace UnitTests
{
	public class Unsecure
	{
		public Unsecure()
		{
			DataAccessLayer.Unsecure.ConnectionString = "Server=(localdb)\\mssqllocaldb;Database=SecurityTraining";
		}

		[Theory]
		[InlineData("admin", "admin1")]
		[InlineData("admin", "x' or '1'='1")]
		[InlineData("x' or '1'='1", "x' or '1'='1")]
		public void ShouldPass(string login, string password)
		{
			User u = DataAccessLayer.Unsecure.LogIn(login, password);
			Assert.Equal(true, u.CredentialsCorrect);
		}

		[Theory]
		[InlineData("admin", "wrong password")]
		public void ShouldNotPass(string login, string password)
		{
			User u = DataAccessLayer.Unsecure.LogIn(login, password);
			Assert.Equal(false, u.CredentialsCorrect);
		}
	}
}
