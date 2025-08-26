
using MauiSummer25.Helper;
using MauiSummer25.Models;
using MauiSummer25.Service;
using MauiSummer25.ViewModels;

namespace MauiSummer25.Views;

public partial class LoginPage : ContentPage
{
	

	public LoginPage(LoginPageViewModel vm)
	{
		
		InitializeComponent();
		
		
		BindingContext = vm ;
	}

	

	
}