using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalakPizza.Models
{
	class Pizza
	{
		public Pizza(string name, decimal priceS, decimal priceM, decimal priceL,string ingreedients)
		{
			Name = name;
			PriceS = priceS;
			PriceM = priceM;
			PriceL = priceL;
			Ingreedients = ingreedients;
		}

		public string Name { get; set; }
		public decimal PriceS { get; set; }
		public decimal PriceM { get; set; }
		public decimal PriceL { get; set; }
		public string Ingreedients { get; set; }

	}
}
