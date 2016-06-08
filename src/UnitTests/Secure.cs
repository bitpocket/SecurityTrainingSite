using DataAccessLayer.Models;
using Xunit;

namespace UnitTests
{
	public class Secure
	{
		public Secure()
		{
			DataAccessLayer.Secure.ConnectionString = "Server=(localdb)\\mssqllocaldb;Database=SecurityTraining";
		}

		[Theory]
		[InlineData("admin", "admin1")]
		public void ShouldPass(string login, string password)
		{
			User u = DataAccessLayer.Secure.LogIn(login, password);
			Assert.Equal(true, u.CredentialsCorrect);
		}

		[Theory]
		[InlineData("admin", "wrong password")]
		[InlineData("admin", "x' or '1'='1")]
		[InlineData("' or 1=1--", "password is not checked")]
		public void ShouldNotPass(string login, string password)
		{
			User u = DataAccessLayer.Secure.LogIn(login, password);
			Assert.Equal(false, u.CredentialsCorrect);
		}
	}
}
