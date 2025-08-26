using MauiSummer25.Service;
using MauiSummer25.ViewModels;

namespace MauiSummer25.Views;

public partial class UserList : ContentPage
{
	public UserList(UserListPageViewModel vm )
	{
		InitializeComponent();
		this.BindingContext = vm;
	}
}