using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using static System.Net.WebRequestMethods;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Calculator
{
	/// <summary>
	/// An empty page that can be used on its own or navigated to within a Frame.
	/// </summary>
	public sealed partial class BlankPage1 : Page
	{
		public BlankPage1()
		{
			this.InitializeComponent();
		}


		private async void calculateButton_Click(object sender, RoutedEventArgs e)
		 {
			double input;
			double final;
			double one = 1;
			double usdToEuro = 0.85189982;
			double usdToPound = 0.72872436;
			double usdToRupee = 74.257327;
			double euroToUSD = 1.1739732;
			double euroToPound = 0.8556672;
			double euroToRupee = 87.00755;
			double poundToUSD = 1.371907;
			double poundToEuro = 1.1686692;
			double poundToRupee = 101.68635;
			double rupeeToUSD = 0.011492628;
			double rupeeToEuro = 0.013492774;
			double rupeeToPound = 0.0098339397;


			try
			{
				input = double.Parse(inputAmount.Text);
			}
			catch
			{
				var dialog = new MessageDialog("Input amount not a number. Please retry");
				await dialog.ShowAsync();
				inputAmount.Focus(FocusState.Programmatic);
				inputAmount.SelectAll();
				return;
			}

			if (typeFrom.SelectedValue.ToString() == "USD - US Dollar")
			{
				amountTextBox.Text = input + " US Dollars =";
				if (typeTo.SelectedValue.ToString() == "USD - US Dollar")
				{
					final = input * 1;
					convertedTextBox.Text = "$" + final + " US Dollars";
					conversion1TextBox.Text = "1 USD = 1 USD";
					conversion2TextBox.Text = "1 USD = 1 USD";
				}	
				else if (typeTo.SelectedValue.ToString() == "Euro")
				{
					final = input * 0.85189982;
					convertedTextBox.Text = "€" + final + " Euros";
					conversion1TextBox.Text = "1 USD = 0.85189982 Euros";
					conversion2TextBox.Text = "1 Euro = 1.1739732 USD";
				}
				else if (typeTo.SelectedValue.ToString() == "British Pound")
				{
					final = input * 0.72872436;
					convertedTextBox.Text = "£" + final + " Pounds";
					conversion1TextBox.Text = "1 USD = 0.72872436 Pounds";
					conversion2TextBox.Text = "1 Pound = 1.371907 USD";
				}
				else if (typeTo.SelectedValue.ToString() == "Indian Rupees")
				{
					final = input * 74.257327;
					convertedTextBox.Text = "₹" + final + " Rupees";
					conversion1TextBox.Text = "1 USD = 74.257327 Rupees";
					conversion2TextBox.Text = "1 Rupee = 0.011492628 USD";
				}
			}
			else if (typeFrom.SelectedValue.ToString() == "Euro")
			{
				amountTextBox.Text = input + " Euros =";
				if (typeTo.SelectedValue.ToString() == "USD - US Dollar")
				{
					final = input * 1.1739732;
					convertedTextBox.Text = "$" + final + " US Dollars";
					conversion1TextBox.Text = "1 Euro = 1.1739732 USD";
					conversion2TextBox.Text = "1 USD = 0.85189982 Euros";
				}
				else if (typeTo.SelectedValue.ToString() == "Euro")
				{
					final = input * 1;
					convertedTextBox.Text = "€" + final + " Euros";
					conversion1TextBox.Text = "1 Euro = 1 Euro";
					conversion2TextBox.Text = "1 Euro = 1 Euro";
				}
				else if (typeTo.SelectedValue.ToString() == "British Pound")
				{
					final = input * 0.8556672;
					convertedTextBox.Text = "£" + final + " Pounds";
					conversion1TextBox.Text = "1 Euro = 0.8556672 Pounds";
					conversion2TextBox.Text = "1 Pound = 1.1686692 Euros";
				}
				else
					final = input * 87.00755;
					convertedTextBox.Text = "₹" + final + " Rupees";
					conversion1TextBox.Text = "1 Euro = 87.00755 Rupees";
					conversion2TextBox.Text = "1 Rupee = 0.013492774 Euros";
			}
			else if (typeFrom.SelectedValue.ToString() == "British Pound")
			{
				amountTextBox.Text = input + " Pounds =";
				if (typeTo.SelectedValue.ToString() == "USD - US Dollar")
				{
					final = input * 1.371907;
					convertedTextBox.Text = "$" + final + " US Dollars";
					conversion1TextBox.Text = "1 Pound = 1.371907 USD";
					conversion2TextBox.Text = "1 USD = 0.72872436 Pounds";
				}	
				else if (typeTo.SelectedValue.ToString() == "Euro")
				{
					final = input * 1.1686692;
					convertedTextBox.Text = "€" + final + " Euros";
					conversion1TextBox.Text = "1 Pound = 1.1686692 Euros";
					conversion2TextBox.Text = "1 Euro = 0.8556672 Pounds";
				}
				else if (typeTo.SelectedValue.ToString() == "British Pound")
				{
					final = input * 1;
					convertedTextBox.Text = "£" + final + " Pounds";
					conversion1TextBox.Text = "1 Pound = 1 Pound";
					conversion2TextBox.Text = "1 Pound = 1 Pound";
				}
				else
					final = input * 101.68635;
					convertedTextBox.Text = "₹" + final + " Rupees";
					conversion1TextBox.Text = "1 Pound = 101.68635 Rupees";
					conversion2TextBox.Text = "1 Rupee = 0.0098339397 Pounds";
			}
			else
			{
				amountTextBox.Text = input + " Rupees =";
				if (typeTo.SelectedValue.ToString() == "USD - US Dollar")
				{
					final = input * 0.011492628;
					convertedTextBox.Text = "$" + final + " US Dollars";
					conversion1TextBox.Text = "1 Rupee = 0.011492628 USD";
					conversion2TextBox.Text = "1 USD = 74.257327 Rupees";
				}
				else if (typeTo.SelectedValue.ToString() == "Euro")
				{
					final = input * 0.013492774;
					convertedTextBox.Text = "€" + final + " Euros";
					conversion1TextBox.Text = "1 Rupee = 0.013492774 Euros";
					conversion2TextBox.Text = "1 Euro = 87.00755 Rupees";
				}
				else if (typeTo.SelectedValue.ToString() == "British Pound")
				{
					final = input * 0.0098339397;
					convertedTextBox.Text = "£" + final + " Pounds";
					conversion1TextBox.Text = "1 Rupee = 0.0098339397 Pounds";
					conversion2TextBox.Text = "1 Pound = 101.68635 Rupees";
				}
				else
					final = input * 1;
					convertedTextBox.Text = "₹" + final + " Rupees";
					conversion1TextBox.Text = "1 Rupee = 1 Rupee";
					conversion1TextBox.Text = "1 Rupee = 1 Rupee";
			}

		}

		private void exitButton_Click(object sender, RoutedEventArgs e)
		{

		}
	}
}
