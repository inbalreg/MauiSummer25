namespace MauiSummer25.ViewModels;

public class CoursesPageViewModel : ContentView
{
	public CoursesPageViewModel()
	{
		Content = new VerticalStackLayout
		{
			Children = {
				new Label { HorizontalOptions = LayoutOptions.Center, VerticalOptions = LayoutOptions.Center, Text = "Welcome to .NET MAUI!"
				}
			}
		};
	}
}