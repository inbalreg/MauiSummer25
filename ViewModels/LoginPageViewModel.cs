using MauiSummer25.Helper;
using MauiSummer25.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MauiSummer25.Models;
//using CommunityToolkit.Mvvm.Input;

namespace MauiSummer25.ViewModels
{
	/// <summary>
	/// ה-ViewModel עבור דף ההתחברות. מנהל את הלוגיקה והמצב של הדף.
	/// </summary>
	public class LoginPageViewModel : ViewModelBase
	{
		// שדה פרטי לשמירת שירות ההתחברות שהוזרק
		IUserServices db;
		IServiceProvider provider;

		private string? _userName;
		private string? _password;


		/// <summary>
		/// המשתמש הנוכחי שהתחבר בהצלחה.
		/// </summary>
		/// <remarks>משתמש זה יכול לשמש לניווט לדפים אחרים או להצגת פרטים נוספים.</remarks>
		/// </summary>

		public User? CurrentUser;


        /// <summary>
        /// בנאי של ה-ViewModel.
        /// </summary>
        /// <param name="service">שירות ההתחברות שיוזרק באמצעות Dependency Injection.</param>
        public LoginPageViewModel(IUserServices service, IServiceProvider provider)
        {
            this.provider = provider;
            db = service;
            // אתחול הפקודות והגדרת ערכים ראשוניים
            ShowPasswordCommand = new Command(TogglePasswordVisiblity);
            LoginCommand = new Command(Login, CanLogin);
            ShowPasswordIcon = FontHelper.CLOSED_EYE_ICON; // הגדרת אייקון ברירת מחדל
            IsPassword = true; // הגדרת שדה הסיסמה כמוסתר כברירת מחדל
                               // NavigateCommand = new AsyncRelayCommand(OnNavigate);
            Routing.RegisterRoute("AppShell", typeof(MauiSummer25.AppShell));
            // Add more routes as needed

            var hasStyle = Application.Current.Resources.ContainsKey("RedButtonStyle");
            Console.WriteLine($"Style found? {hasStyle}");
        }

        /// <summary>
        /// שם המשתמש המוזן על ידי המשתמש ב-UI.
        /// </summary>
        public string? UserName
		{
			get => _userName;
			set
			{
				if (_userName != value)
				{
					_userName = value;
					OnPropertyChanged(); // מודיע ל-UI על שינוי כדי לעדכן את התצוגה
					(LoginCommand as Command)?.ChangeCanExecute(); // בודק מחדש אם ניתן להפעיל את כפתור ההתחברות
				}
			}
		}

		/// <summary>
		/// הסיסמה המוזנת על ידי המשתמש ב-UI.
		/// </summary>
		public string? Password
		{
			get { return _password; }
			//=> _password;
			set
			{
				if (_password != value)
				{
					_password = value;
					OnPropertyChanged(); // מודיע ל-UI על שינוי
					(LoginCommand as Command)?.ChangeCanExecute(); // בודק מחדש אם ניתן להפעיל את כפתור ההתחברות
				}
			}
		}

		private bool messageIsVisible;
		/// <summary>
		/// קובע אם הודעת המשוב (הצלחה/שגיאה) תוצג למשתמש.
		/// </summary>
		public bool MessageIsVisible
		{
			get => messageIsVisible;
			set
			{
				if (messageIsVisible != value)
				{
					messageIsVisible = value;
					OnPropertyChanged();
				}
			}
		}

		private Color? messageColor;
		/// <summary>
		/// קובע את צבע הודעת המשוב (למשל, ירוק להצלחה ואדום לשגיאה).
		/// </summary>
		public Color? MessageColor
		{
			get => messageColor;
			set
			{
				if (messageColor != value)
				{
					messageColor = value;
					OnPropertyChanged();
				}
			}
		}

		private bool isPassword;
		/// <summary>
		/// קובע האם שדה הסיסמה יוצג כמוסתר (true) או גלוי (false).
		/// </summary>
		public bool IsPassword
		{
			get => isPassword;
			set
			{
				if (isPassword != value)
				{
					isPassword = value;
					OnPropertyChanged();
				}
			}
		}

		private string? showPasswordIcon;
		/// <summary>
		/// האייקון שיוצג עבור כפתור הצג/הסתר סיסמה.
		/// </summary>
		public string? ShowPasswordIcon
		{
			get => showPasswordIcon;
			set
			{
				if (showPasswordIcon != value)
				{
					showPasswordIcon = value;
					OnPropertyChanged();
				}
			}
		}

		private string? loginMessage;
		/// <summary>
		/// טקסט הודעת המשוב שתוצג למשתמש לאחר ניסיון התחברות.
		/// </summary>
		public string? LoginMessage
		{
			get => loginMessage;
			set
			{
				if (loginMessage != value)
				{
					loginMessage = value;
					OnPropertyChanged();
				}
			}
		}


        /// <summary>
        /// תנאי הקובע אם ניתן להפעיל את פקודת ההתחברות.
        /// </summary>
        /// <returns>אמת אם גם שם המשתמש וגם הסיסמה אינם ריקים.</returns>
        public bool CanLogin()
		{
			return (!string.IsNullOrEmpty(UserName) && !string.IsNullOrEmpty(Password));
		}

		/// <summary>
		/// פקודה להצגה והסתרה של הסיסמה.
		/// </summary>
		public ICommand ShowPasswordCommand
		{
			get;
		}

		/// <summary>
		/// פקודה לביצוע תהליך ההתחברות.
		/// </summary>
		public ICommand LoginCommand
		{
			get;
		}

		/// <summary>
		/// מחליף את מצב התצוגה של הסיסמה (מוסתר/גלוי) ומעדכן את האייקון בהתאם.
		/// </summary>
		private void TogglePasswordVisiblity()
		{
			IsPassword = !IsPassword; // הופך את הערך הבוליאני
			if (IsPassword)
				ShowPasswordIcon = FontHelper.CLOSED_EYE_ICON;
			else
				ShowPasswordIcon = FontHelper.OPEN_EYE_ICON;
		}



		/// <summary>
		/// מבצע את לוגיקת ההתחברות.
		/// </summary>
		private async void Login()
		{
			IsBusy = true; // מסמן שהאפליקציה בתהליך (להצגת מחוון טעינה)
			MessageIsVisible = true; // מציג את אזור הודעת המשוב

			// קורא לשירות ההתחברות עם הפרטים שהוזנו
			if (db.Login(UserName!, Password!))
			{
				// במקרה של הצלחה
				LoginMessage = AppMessages.LoginMessage;
				MessageColor = Colors.Green;
				////////////////
				CurrentUser = db.getUserByUsername(UserName!); // טוען את המשתמש מהמסד נתונים

                var shellVm = provider.GetService<AppShellViewModel>()!;                                                                    // כאן ניתן להוסיף ניווט לדף הבא
                Application.Current.Windows[0].Page = new AppShell(shellVm, CurrentUser!);
  //              // Pass CurrentUser as a navigation parameter
  //              await Shell.Current.GoToAsync("AppShell", // or your target route
		//			new Dictionary<string, object>
		//			{
		//{ "UserParam", CurrentUser }
		//			});

				
			}
			//     await Application.Current!.Windows[0].Page!.DisplayAlert("חיבור כושל", AppMessages.LoginErrorMessage, "אישור");
			// במקרה של כישלון
			//LoginMessage = AppMessages.LoginErrorMessage;

			//MessageColor = Colors.Red;
			// }


			else
			{
				// במקרה של כישלון
				LoginMessage = AppMessages.LoginErrorMessage;
				MessageColor = Colors.Red;
			}
			IsBusy = false; // מסיים את מצב "עסוק"
		}

		//public User CurrentUser { get; set; }

		//public ICommand NavigateCommand { get; }


		//public async Task OnNavigate()
		//{
		//    // מעביר את המשתמש כפרמטר
		//    await Shell.Current.GoToAsync(nameof(UserProfilePageViewModel), true,
		//        new Dictionary<string, object>
		//        {
		//        { "UserParam", currentUser! }
		//        });
		//}

	}
}