using DataAccessLayer.Models;
using Xunit;

namespace UnitTests
{
	public class Secure
	{
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
		[InlineData("x' or '1'='1", "x' or '1'='1")]
		public void ShouldNotPass(string login, string password)
		{
			User u = DataAccessLayer.Secure.LogIn(login, password);
			Assert.Equal(false, u.CredentialsCorrect);
		}
	}
}
