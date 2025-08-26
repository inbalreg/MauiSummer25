using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MauiSummer25.Models;
using MauiSummer25.Views;

namespace MauiSummer25.ViewModels
{
    [QueryProperty(nameof(CurrentUser), "CurrentUser")]
    internal class AppShellViewModel : ViewModelBase
    {
        IServiceProvider provider;
        private User? currentUser;
        public User? CurrentUser
        {
            get => currentUser;
            set
            {
                if (currentUser != value)
                {
                    currentUser = value;
                    OnPropertyChanged();
                }
            }
        }

        public bool IsAdmin
        {
            get;
            //get => (Application.Current as App)?.CurrentUser?.IsAdmin ?? false;
        }

     public ICommand UserProfilCommand
        {
            get;
        }

        public ICommand LogoutCommand
        {
            get;
        }

        public AppShellViewModel(IServiceProvider provider)//, User user)
        {
            this.provider = provider;

            LogoutCommand = new Command(Logout);
            UserProfilCommand = new Command(async () => 
            {
                // Navigate to UserProfilePage with the current user
                var userProfilePage = provider.GetService<UserProfilePage>();
                if (userProfilePage != null)
                {
                    //userProfilePage.CurrentUser = this.CurrentUser;
                    //userProfilePage.BindingContext = this.CurrentUser;
                    
                    Dictionary<string, object> param = new Dictionary<string, object>();
                    param.Add("CurrentUser", this.CurrentUser);
                    await Shell.Current.GoToAsync("UserProfilePage", param);
                   // Application.Current.MainPage.Navigation.PushAsync(userProfilePage);
                }
            });

        }

        private void Logout()
        {
           // (Application.Current as App)!.CurrentUser = null; // איפוס המשתמש הנוכחי לאפס
            //OnPropertyChanged(nameof(IsAdmin));
           // Page loginPage = provider.GetService<LoginPage>()!;
           // Application.Current.Windows[0].Page = loginPage; // החלפת הדף הנוכחי לדף ההתחברות
        }


    }
}
