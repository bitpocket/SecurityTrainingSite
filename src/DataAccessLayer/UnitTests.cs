using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccessLayer;
using Xunit;

namespace DataBaseAccess
{
	public class UnitTests
	{
		[Fact]
		public void LoginProper_PasswordPropper()
		{
			User u = SQLHelper.LogIn("admin", "admin1");
			Assert.Equal(true, u.CredentialsCorrect);
		}

		[Fact]
		public void LoginProper_PasswordBad()
		{
			User u = SQLHelper.LogIn("admin", "wrong password");
			Assert.Equal(false, u.CredentialsCorrect);
		}

		[Fact]
		public void LoginProper_PasswordNotChecked()
		{
			User u = SQLHelper.LogIn("admin", "x' or '1'='1");
			Assert.Equal(true, u.CredentialsCorrect);
		}

		[Fact]
		public void LoginBad_PasswordNotChecked()
		{
			User u = SQLHelper.LogIn("x' or '1'='1", "x' or '1'='1");
			Assert.Equal(true, u.CredentialsCorrect);
		}
	}
}
