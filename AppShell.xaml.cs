using MauiSummer25.Models;
using MauiSummer25.Views;

namespace MauiSummer25
{
    public partial class AppShell : Shell
    {
        public User CurrentUser { get; set; }

        internal AppShell(ViewModels.AppShellViewModel shellVm, User currentUser)
        {
            InitializeComponent();
            BindingContext = shellVm;

            CurrentUser = currentUser;
            shellVm.CurrentUser = currentUser;
            //רישום של דפים פנימיים
           // Routing.RegisterRoute("UserTaskPage/DetailsPage", typeof(TaskDetailsPage));
            Routing.RegisterRoute("UserProfilePage", typeof(UserProfilePage));

            // אם יש צורך להוסיף את המשתמש הנוכחי ל-BindingContext של ה-Shell
            //BindingContext = new { CurrentUser = currentUser };
            // או אם יש צורך להוסיף את המשתמש הנוכחי ל-BindingContext של ה-Shell
            //Shell.SetBindingContext(this, new { CurrentUser = currentUser });
            // אם יש צורך להוסיף את המשתמש הנוכחי ל-BindingContext של ה-Shell
            //Shell.SetBindingContext(this, shellVm);
        }
    }
}
