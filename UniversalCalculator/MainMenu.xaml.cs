using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.Core;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Calculator
{
	/// <summary>
	/// An empty page that can be used on its own or navigated to within a Frame.
	/// </summary>
	public sealed partial class MainMenu : Page
	{
		public MainMenu()
		{
			this.InitializeComponent();
		}

		// page functions
		private void pageLoaded(object sender, RoutedEventArgs e)
		{
			// window minimum size
			ApplicationView.GetForCurrentView().SetPreferredMinSize(new Size(256, 384));

			// enable title bar full customiztion
			CoreApplication.GetCurrentView().TitleBar.ExtendViewIntoTitleBar = true;
			// title bar customization
			ApplicationViewTitleBar titleBar = ApplicationView.GetForCurrentView().TitleBar;

			titleBar.ButtonBackgroundColor = Windows.UI.Colors.Transparent;
			titleBar.ButtonInactiveBackgroundColor = Windows.UI.Colors.Transparent;
			titleBar.ButtonInactiveForegroundColor = Windows.UI.Colors.White;
		}

		private void MortgageCalcButton_Click(object sender, RoutedEventArgs e)
		{
			Frame menuFrame = new Frame();

			menuFrame.Navigate(typeof(MortgageCalculator));

			Window.Current.Content = menuFrame;
		}

		private void CurrencyCalcButton_Click(object sender, RoutedEventArgs e)
		{
			Frame menuFrame = new Frame();

			menuFrame.Navigate(typeof(CurrencyConverter));

			Window.Current.Content = menuFrame;
		}
	}
}
