using MauiSummer25.Helper;
using MauiSummer25.Service;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace MauiSummer25.ViewModels
{
    public class RegistrationPageViewModel : ViewModelBase
    {

        // שדה פרטי לשמירת שירות ההתחברות שהוזרק
        private readonly IUserServices db;
        /// <summary>
        /// בנאי של ה-ViewModel.
        /// </summary>
        /// <param name="service">שירות ההתחברות שיוזרק באמצעות Dependency Injection.</param>
        public RegistrationPageViewModel(IUserServices loginService)
        {
            db = loginService;
            // אתחול הפקודות והגדרת ערכים ראשוניים
            ShowPasswordCommand = new Command(TogglePasswordVisiblity);
            RegisterCommand = new Command(Register, CanRegister);
            ShowPasswordIcon = FontHelper.CLOSED_EYE_ICON; // הגדרת אייקון ברירת מחדל
            IsPassword = true; // הגדרת שדה הסיסמה כמוסתר כברירת מחדל
            UserMessage = "TEST!!!";
            MessageIsVisible = false;
            SelectedDate = new DateTime(2000, 1, 1);
            errorMessage = "Test Error Message";
            UserNameText = "";
        }

        private string? _userName;
        private string? _password;
        private string? _name;
        private string? _email;
        private string? _phoneNum;
        private DateTime _date;


        /// <summary>
        /// שם המשתמש המוזן על ידי המשתמש ב-UI.
        /// </summary>
        public string? UserNameText
        {
            get => _userName;
            set
            {
                if (_userName != value && value != null)
                {
                    _userName = value;
                    OnPropertyChanged(); // מודיע ל-UI על שינוי כדי לעדכן את התצוגה
                    (RegisterCommand as Command)?.ChangeCanExecute(); // בודק מחדש אם ניתן להפעיל את כפתור ההתחברות
                }
            }
        }

        /// <summary>
        /// הסיסמה המוזנת על ידי המשתמש ב-UI.
        /// </summary>
        public string? Password
        {
            get => _password;
            set
            {
                if (_password != value)
                {
                    _password = value;
                    OnPropertyChanged(); // מודיע ל-UI על שינוי
                    (RegisterCommand as Command)?.ChangeCanExecute(); // בודק מחדש אם ניתן להפעיל את כפתור ההתחברות
                }
            }
        }

        /// <summary>
        /// Gets or sets the name associated with the object.
        /// </summary>
        /// <remarks>Setting this property raises the <c>PropertyChanged</c> event if the value
        /// changes.</remarks>
        public string? Name
        {
            get => _name;
            set
            {
                if (_name != value)
                {
                    _name = value;
                    OnPropertyChanged();
                }
            }
        }

        public string? Email
        {
            get => _email;
            set
            {
                if (_email != value)
                {
                    _email = value;
                    OnPropertyChanged();
                }
            }
        }

        public DateTime? SelectedDate
        {
            get { return _date;  }
            set {
                    if (_date != value)
                    {
                        _date = (DateTime)value;
                        OnPropertyChanged();
                        OnPropertyChanged(nameof(Age));
                        OnPropertyChanged(nameof(AgeStr));
                        Console.WriteLine(Age);
                    Age = null;
                    AgeStr = "----";
                }
                }
            }

    //public event PropertyChangedEventHandler PropertyChanged;

    //    protected void OnPropertyChanged([CallerMemberName] string name = null)
    //    {
    //        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    //    }

        private string? ageStr;
        public string? AgeStr
        {
            get => ageStr;
            set { 
                ageStr = "   Age:  " + Age + "   ";
                OnPropertyChanged();
            }
        }

        private int? age;
        public int? Age
        {
            get => age;

            set
            {

                //if (_date == null)
                //    return null;
                
                DateTime today = DateTime.Today;
                age = today.Year - _date.Year;

                // אם יום ההולדת עוד לא הגיע השנה – הפחת שנה אחת
                if (_date.Month > today.Month || (_date.Month == today.Month && _date.Day > today.Day)) 
                    age--;
                OnPropertyChanged();
            }
               
            //DateTime currentDate = DateTime.Today;
            //DateTime? selectedDate = _date;
            //TimeSpan? ts = selectedDate - currentDate;
            //return ((TimeSpan?)(selectedDate - currentDate))?.Days / 365;
        }
        

        public string? PhoneNum
        {
            get => _phoneNum;
            set
            {
                if (_phoneNum != value)
                {
                    _phoneNum = value;
                    OnPropertyChanged();
                }
            }
        }

        //public string? Date
        //{
        //    get => _date;
        //    set
        //    {
        //        if (_date != value)
        //        {
        //            _date = value;
        //            OnPropertyChanged();
        //        }
        //    }
        //}

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

        private string errorMessage;

        public string ErrorMessage
        {
            get { return errorMessage; }
            set 
            { 
                if(errorMessage != value)
                {
                    errorMessage = value;
                }
                OnPropertyChanged();
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

        private string? userMessage;
        /// <summary>
        /// טקסט הודעת המשוב שתוצג למשתמש לאחר ניסיון התחברות.
        /// </summary>
        public string? UserMessage
        {
            get => userMessage;
            set
            {
                if (userMessage != value)
                {
                    userMessage = value;
                    OnPropertyChanged();
                }
            }
        }


        /// <summary>
        /// תנאי הקובע אם ניתן להפעיל את פקודת ההתחברות.
        /// </summary>
        /// <returns>אמת אם גם שם המשתמש וגם הסיסמה אינם ריקים.</returns>
        public bool CanRegister()
        {
           return (!string.IsNullOrEmpty(UserNameText) && !string.IsNullOrEmpty(Password));
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
        public ICommand RegisterCommand
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
        private void Register()
        {
            IsBusy = true; // מסמן שהאפליקציה בתהליך (להצגת מחוון טעינה)
            MessageIsVisible = true; // מציג את אזור הודעת המשוב
            try
            {
                if (UserNameText.Contains(" "))
                {
                    throw new ArgumentException("Username cannot contain spaces");
                }
                if (Char.IsDigit(UserNameText.ToCharArray()[0]))
                {
                    throw new ArgumentException("Username cannot start with a digit");
                }
                if (Age < 18)
                {
                    throw new ArgumentException("Age cannot be under 18");
                }
                // קורא לשירות ההתחברות עם הפרטים שהוזנו
                if (db.Register(Name!, UserNameText!, Password!, Email!, PhoneNum!, (DateTime)SelectedDate))
                {
                    // במקרה של הצלחה
                    MessageIsVisible = true;
                    UserMessage = AppMessages.RegisteredMessage;
                    MessageColor = Colors.Green;
                    // כאן ניתן להוסיף ניווט לדף הבא
                }
                else
                {
                    // במקרה של כישלון
                    UserMessage = AppMessages.RegisterErrorMessage;
                    MessageColor = Colors.Red;
                    MessageIsVisible = true;
                }
               
            }
            catch (ArgumentException ex)
            {
                UserMessage = ex.Message;//AppMessages.RegisterErrorMessage;
                MessageIsVisible = true;
                MessageColor = Colors.Red;
            }
            finally
            {
                IsBusy = false; // מסיים את מצב "עסוק"
            }
        }


    }
}