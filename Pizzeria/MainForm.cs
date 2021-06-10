using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using GalakPizza.Models;


namespace GalakPizza
{
	public partial class MainForm : Form
	{
		//chyba będzie Pan musiał zmienić ścieżkę do pliku
		string pizzaFilePath = @"C:\Users\Krystian\Desktop\Folder - VS\Pizzeria\Pizzeria\Resources\pizze.txt";
		List<Pizza> pizzaList;
		
		public MainForm()
		{
			InitializeComponent();
			pizzaList = GetPizzas();

			foreach (Pizza x in pizzaList)
			{
				listBox1.Items.Add(x.Name);	
			}
		}
		
		List<Pizza> GetPizzas()
		{
			List<Pizza> pizzas = new List<Pizza>();
			List<string> lines = File.ReadAllLines(pizzaFilePath).ToList();
			
			foreach (var line in lines)
			{
				string[] entries = line.Split('-');
				Pizza newPizza = new Pizza(entries[0], decimal.Parse(entries[1]), decimal.Parse(entries[2]), decimal.Parse(entries[3]), entries[4]);
				pizzas.Add(newPizza);
			}

			return pizzas;  
		}
		private void SetPrice()
		{
			decimal price = 0m;
			decimal takeawayPrice = 0m;
			if (listBox1.SelectedItem != null)
			{
				//decimal price = 0m;
				Pizza chosenPizza = pizzaList.ElementAt(listBox1.SelectedIndex);
				label6.Text = chosenPizza.Ingreedients;
				
				if (radioButton1.Checked == false && radioButton2.Checked == false && radioButton3.Checked == false)
				{
					label3.Text = "Chose pizza size";
				}
				else
				{
					if (radioButton1.Checked == true)
					{
						price = chosenPizza.PriceS;
					}
					else if (radioButton2.Checked == true)
					{
						price = chosenPizza.PriceM;
					}
					else if (radioButton3.Checked == true)
					{
						price = chosenPizza.PriceL;
					}
					label3.Text = price.ToString() + "zl";
				}
			}
			else if (listBox1.SelectedItem == null)
			{
				label3.Text = "Chose pizza type";
			}

			if (radioButton1.Checked == true || radioButton2.Checked == true || radioButton3.Checked == true)
			{
				if (listBox1.SelectedItem != null)
				{
					takeawayPrice = price + 5;
					label8.Text = takeawayPrice.ToString() + "zl";
				}
			}

		}

		//Log out -> switch to LoginForm
		private void button2_Click(object sender, EventArgs e)
		{
			this.Hide();
			LoginForm loginForm = new LoginForm();
			loginForm.ShowDialog();
			this.Close();
		}

		//Update price
		private void button1_Click_1(object sender, EventArgs e)
		{
			SetPrice();
		}
		private void listBox1_SelectedIndexChanged(object sender, EventArgs e) 
		{
			SetPrice();
		}	
		private void radioButton3_CheckedChanged(object sender, EventArgs e)
		{
			SetPrice();
		}
		private void radioButton1_CheckedChanged(object sender, EventArgs e)
		{
			SetPrice();
		}
		private void radioButton2_CheckedChanged(object sender, EventArgs e)
		{
			SetPrice();
		}
		
		//poniżej smieci, ktorych nie umiem usunac
		private void MainForm_Load(object sender, EventArgs e) { }
		private void groupBox1_Enter(object sender, EventArgs e) { }
	}
}
