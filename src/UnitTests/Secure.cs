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
		public void ShouldLogin(string login, string password)
		{
			var u = DataAccessLayer.Secure.LogIn(login, password);
			Assert.Equal(true, u.CredentialsCorrect);
		}

		[Theory]
		[InlineData("admin", "wrong password")]
		[InlineData("admin", "x' or '1'='1")]
		[InlineData("' or 1=1--", "password is not checked")]
		public void ShouldNotLogin(string login, string password)
		{
			var u = DataAccessLayer.Secure.LogIn(login, password);
			Assert.Equal(false, u.CredentialsCorrect);
		}

		[Theory]
		[InlineData("cat', ''); update users set password='fake' where username = 'admin' --", "x")]
		public void AddPetShouldNotChangePass(string animal, string name)
		{
			DataAccessLayer.Secure.AddPet(animal, name);
			var u = DataAccessLayer.Secure.LogIn("admin", "fake");

			Assert.Equal(false, u.CredentialsCorrect);
		}


	}
}
