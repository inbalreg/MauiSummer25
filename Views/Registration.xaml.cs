using MauiSummer25.ViewModels;

namespace MauiSummer25.Views;

public partial class RegistrationPage : ContentPage
{
	public RegistrationPage(RegistrationPageViewModel vm)
    {

        InitializeComponent();


        BindingContext = vm;
    }

	
}