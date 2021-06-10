using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GalakPizza.Models;
using System.IO;


namespace GalakPizza
{
	public partial class LoginForm : Form
	{
		//chyba będzie Pan musiał zmienić ścieżkę do pliku
		string vendorsFilePath = @"C:\Users\Krystian\Desktop\Folder - VS\Pizzeria\Pizzeria\Resources\Vendors.txt";
		List<Vendor> vendorList;
		string userPassword;

		public LoginForm()
		{
			InitializeComponent();
			vendorList = GetVendors();

			foreach (Vendor x in vendorList)
			{
				listBox1.Items.Add(x.FullName);
			}
		}

		List<Vendor> GetVendors()
		{
			List<Vendor> vendors = new List<Vendor>();
			List<string> lines = File.ReadAllLines(vendorsFilePath).ToList();

			foreach (var line in lines)
			{
				string[] entries = line.Split('-');
				Vendor newVendor = new Vendor(int.Parse(entries[0]), entries[1], entries[2], entries[3]);
				vendors.Add(newVendor);
			}
			return vendors;
		}

		//Log in password verification
		private void button1_Click(object sender, EventArgs e)
		{
			if (listBox1.SelectedItem != null) 
			{
				if (textBox1.Text == userPassword)
				{
					this.Hide();
					MainForm mainForm = new MainForm();
					mainForm.ShowDialog();
					this.Close();
				}
				else
				{
					label2.Text = "Incorrect password";
					textBox1.Text = "";
				}
			}
			else
			{
				label1.Text = "Chose user!";
			}
		}

		private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
		{	
				Vendor chosenVendor = vendorList.ElementAt(listBox1.SelectedIndex);
				userPassword = chosenVendor.Password;
		}
	}
}
