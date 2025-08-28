using MauiSummer25.ViewModels;

namespace MauiSummer25.Views;

public partial class CoursesPage : ContentPage
{
	public CoursesPage(CoursesPageViewModel vm)
	{
		InitializeComponent();
        BindingContext = vm;
    }
}