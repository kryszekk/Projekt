using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalakPizza.Models
{
	class Vendor
	{
		public Vendor(int id, string name, string surname, string password)
		{
			Id = id;
			Name = name;
			Surname = surname;
			Password = password;
		}

		public int Id { get; set; }
		public string Name { get; set; }
		public string Surname { get; set; }
		public string Password { get; set; }
		public string FullName 
		{
			get
			{
				return Name + " " + Surname;
			}
		}
	}
}
