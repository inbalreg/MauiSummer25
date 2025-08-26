using MauiSummer25.Models;
using MauiSummer25.Service;
using MauiSummer25.ViewModels;

namespace MauiSummer25.Views;

public partial class UserProfilePage : ContentPage, IQueryAttributable
{

    private readonly IUserServices _userService;

    public UserProfilePage(UserProfilePageViewModel vm, IUserServices userService)
    {
        InitializeComponent();
       // BindingContext = vm;
        _userService = userService;

        

        //var hasStyle = Application.Current.Resources.ContainsKey("BlueContentBackground");
        //Console.WriteLine($"Style found? {hasStyle}");
        
    }

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
       {
            if (query.ContainsKey("CurrentUser"))
            {
                if (query["CurrentUser"] is User user)
                {
                    // Now you have a User instance
                    // Example: Set as BindingContext or use as needed
                    BindingContext = new UserProfilePageViewModel(user);
                    //(BindingContext as UserProfilePageViewModel).CurrentUser = user;
                }
                else
                {
                    // Handle error: object is not a User
                }
            }

        } 
    }

    //public void ApplyQueryAttributes(IDictionary<string, object> query)
    //{
    //    if (query.TryGetValue("user", out var userObj))// && userObj is string userId)
    //    {
    //        //var user = _userService.getUserByUsername (userId);
            
    //        BindingContext = userObj;
    //    }
    //}
}

        //public void ApplyQueryAttributes(IDictionary<string, object> query)
        //{
        //    if (query.TryGetValue("user", out var userObj))// && userObj is string userId)
        //    {
        //        // Example: Fetch user from a service
        //        var user =  UserService.GetUserById(userId); // Replace with your actual service
        //        BindingContext = user;
        //    }
        //}
