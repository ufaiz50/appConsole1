using System;
using System.Collections.Generic;
using System.Text;

namespace Departement
{
	public class Employees
	{
		public string Nik { get; protected set; }
		public string Name { get; set; }
		public string Username { get; set; }
		public string Email { get; set; }
		public string Password { get; set; }
		public string Role { get; set; }

		public Employees()
		{
		}

        public Employees(string nik, string name, string username, string email, string password, string role)
        {
            Nik = nik;
            Name = name;
            Username = username;
            Email = email;
            Password = password;
			Role = role;
        }
    }

}