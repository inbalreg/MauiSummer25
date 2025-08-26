using MauiSummer25.ViewModels;

namespace MauiSummer25.Views;

public partial class AddUserPage : ContentPage
{
	public AddUserPage(AddUserPageViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}