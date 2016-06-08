using System.Collections.Generic;
using System.Data;
using DataAccessLayer.Models;
//using Microsoft.AspNetCore.Mvc;
//using SecurityTrainingSite.Controllers;
//using SecurityTrainingSite.Models.Pet;
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
		[InlineData("superadmin", "superadmin1")]
		[InlineData("admin", "x' or '1'='1")]
		[InlineData("' or 1=1--", "password is not checked")]
		public void ShouldLogIn(string login, string password)
		{
			User u = DataAccessLayer.Unsecure.LogIn(login, password);
			Assert.Equal(true, u.CredentialsCorrect);
		}

		[Theory]
		[InlineData("admin", "wrong password")]
		public void ShouldNotLogin(string login, string password)
		{
			User u = DataAccessLayer.Unsecure.LogIn(login, password);
			Assert.Equal(false, u.CredentialsCorrect);
		}

		[Theory]
		[InlineData("cat', ''); update users set password='fake' where username = 'admin' --", "x")]
		public void AddPetShouldChangePass(string animal, string name)
		{
			DataAccessLayer.Unsecure.AddPet(animal, name);
			var u = DataAccessLayer.Unsecure.LogIn("admin", "fake");

			// reset password
			DataAccessLayer.Secure.ExecuteSql("update users set password='admin1' where username = 'admin'");

			Assert.Equal(true, u.CredentialsCorrect);
		}

		//[Fact]
		//[InlineData("cat', ''); update users set password='fake' where username = 'admin' --", "x")]
		//public void AddPetShouldChangePass2(string animal, string name)
		//{
		//	var controller = new PetController();
		//	var model = new AddPetViewModel() {Animal = animal, Name = name};
		//	var result = controller.Add1(model) as ViewResult;
		//	//Assert.Equal("Hello", result.ViewData["Hello"]);

		//	var u = DataAccessLayer.Unsecure.LogIn("admin", "fake");

		//	// reset password
		//	DataAccessLayer.Secure.ExecuteSql("update users set password='admin1' where username = 'admin'");

		//	Assert.Equal(true, u.CredentialsCorrect);
		//}
	}
}
