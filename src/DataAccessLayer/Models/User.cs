﻿namespace DataAccessLayer.Models
{
	public class User
	{
		public int UserId { get; set; }
		public bool CredentialsCorrect { get; set; }
		public string Username { get; set; }
		public string Role { get; set; }
	}
}