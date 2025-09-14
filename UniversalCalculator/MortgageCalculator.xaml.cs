using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace Calculator
{
	public sealed partial class MortgageCalculator : Page
	{
		public MortgageCalculator()
		{
			this.InitializeComponent();
		}

		//Return to main menu when exit button clicked
		private void ExitButton_Click(object sender, RoutedEventArgs e)
		{
			Frame calcFrame = new Frame();

			calcFrame.Navigate(typeof(MainMenu));

			Window.Current.Content = calcFrame;
		}

		//Calculate mortage when calculate button clicked
		private void CalculateButton_Click(object sender, RoutedEventArgs e)
		{
			//Create variables to store input parameters. Years and months are stored as double to simplify.
			double principalLoan;
			double annualInterestRate;
			double repaymentYears;
			double repaymentMonths;

			//Get user's input, will stop if any field is invalid (cannot be converted to double)
			try
			{
				principalLoan = double.Parse(PrincipalLoanTextBox.Text);
				annualInterestRate = double.Parse(AnnualInterestRateTextBox.Text);
				repaymentYears = double.Parse(YearsTextBox.Text);
				repaymentMonths = double.Parse(MonthsTextBox.Text);
			}
			catch (Exception ex)
			{
				//Display an error message informing the user their input is invalid
				ErrorTextBlock.Text = "One or more input fields are invalid, please ensure only numbers have been entered";
				return;
			}

			//Clear the error message text block if no issues found
			ErrorTextBlock.Text = "";

			//Convert the annual interest rate from a percentage
			annualInterestRate = annualInterestRate / 100;

			//Calculate total repayment months from years and months
			double totalRepaymentMonths = (repaymentYears * 12) + repaymentMonths;

			//Calculate monthly interest rate from the annual interest rate
			double monthlyInterestRate = annualInterestRate / 12;

			double monthlyRepayment;

			//Provided formula will not work if the interest rate is 0. While this is very unlikely, it's good to cover this edge case as the alternative formula is simple.
			if (monthlyInterestRate == 0)
			{
				monthlyRepayment = principalLoan / totalRepaymentMonths;
			}
			else
			{
				//Calculate monthly repayment using the provided formula
				monthlyRepayment = principalLoan * ((monthlyInterestRate * Math.Pow(1 + monthlyInterestRate, totalRepaymentMonths)) / (Math.Pow(1 + monthlyInterestRate, totalRepaymentMonths) - 1));
			}

			//Place the results in the output text boxes
			MonthlyInterestRateTextBox.Text = monthlyInterestRate.ToString();
			MonthlyRepaymentTextBox.Text = monthlyRepayment.ToString();
		}
	}
}
