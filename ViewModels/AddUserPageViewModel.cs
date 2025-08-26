//using System.Security.Cryptography.X509Certificates;
using System.Windows.Input;
using MauiSummer25.Models;

namespace MauiSummer25.ViewModels;

public class AddUserPageViewModel : ContentView
{
	private User currentUser;
	public AddUserPageViewModel(User user)
	{
        currentUser = user ?? throw new ArgumentNullException(nameof(user), "User cannot be null");
        AddUserCommand = new Command(() => AddUser());
        //Content = new VerticalStackLayout
        //{
        //	Children = {
        //		new Label { HorizontalOptions = LayoutOptions.Center, VerticalOptions = LayoutOptions.Center, Text = "Welcome to .NET MAUI!"
        //		}
        //	}
        //};
    }

    private void AddUser()
    {

    }

    public void OnAppearing()
	{
        // This method can be used to perform actions when the view appears
        // For example, you can initialize data or set up event handlers here
    }
	public string Name
	{
		get => currentUser.Name;
		set
		{
			if (currentUser.Name != value)
			{
				currentUser.Name = value;
				OnPropertyChanged();
			}
		}
	}


	public string Username
    {
        get => currentUser.Username;
        set
        {
            if (currentUser.Username != value)
            {
                currentUser.Username = value;
                OnPropertyChanged();
            }
        }
    }

    public string Password
    {
        get => currentUser.Password;
        set
        {
            if (currentUser.Password != value)
            {
                currentUser.Password = value;
                OnPropertyChanged();
            }
        }
    }

    public string Email
    {
        get => currentUser.Email;
        set
        {
            if (currentUser.Email != value)
            {
                currentUser.Email = value;
                OnPropertyChanged();
            }
        }
    }

    public string PhoneNum
    {
        get => currentUser.PhoneNum;
        set
        {
            if (currentUser.PhoneNum != value)
            {
                currentUser.PhoneNum = value;
                OnPropertyChanged();
            }
        }
    }

    public DateTime BirthDate
    {
        get => currentUser.BirthDate;
        set
        {
            if (currentUser.BirthDate != value)
            {
                currentUser.BirthDate = value;
                OnPropertyChanged();
            }
        }
    }

    public string ProfilePicture
    {
        get => currentUser.ProfilePicture;
        set
        {
            if (currentUser.ProfilePicture != value)
            {
                currentUser.ProfilePicture = value;
                OnPropertyChanged();
            }
        }
    }

    public ICommand AddUserCommand
    {
		get;
	}
}