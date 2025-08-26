using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using CommunityToolkit.Maui.Alerts;
using MauiSummer25.Models;
//using CommunityToolkit.Mvvm;
#if WINDOWS
using Microsoft.Maui.Storage; // Ensure this using is present for FilePicker
#endif

namespace MauiSummer25.ViewModels
{
    //[QueryProperty(nameof(CurrentUser), "CurrentUser")]
    public class UserProfilePageViewModel : ViewModelBase
    {

        // Properties for user profile
        /*public string UserName { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNum { get; set; }
        public DateTime BirthDate { get; set; }
        public string ProfilePicture { get; set; }*/


        private User currentUser;
        public User CurrentUser
        {
            get => currentUser;
            set
            {
                Console.WriteLine("Set user ");
                currentUser = value;
            }
        }
        public string Name
        {
            get => CurrentUser.Name;
            set
            {
                if (CurrentUser.Name != value)
                {
                    CurrentUser.Name = value;
                    OnPropertyChanged();
                }
            }
        }


        public string Username
        {
            get => CurrentUser.Username;
            set
            {
                if (CurrentUser.Username != value)
                {
                    CurrentUser.Username = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Password
        {
            get => CurrentUser.Password;
            set
            {
                if (CurrentUser.Password != value)
                {
                    CurrentUser.Password = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Email
        {
            get => CurrentUser.Email;
            set
            {
                if (CurrentUser.Email != value)
                {
                    CurrentUser.Email = value;
                    OnPropertyChanged();
                }
            }
        }

        public string PhoneNum
        {
            get => CurrentUser.PhoneNum;
            set
            {
                if (CurrentUser.PhoneNum != value)
                {
                    CurrentUser.PhoneNum = value;
                    OnPropertyChanged();
                }
            }
        }

        public DateTime BirthDate
        {
            get => CurrentUser.BirthDate;
            set
            {
                if (CurrentUser.BirthDate != value)
                {
                    CurrentUser.BirthDate = value;
                    OnPropertyChanged();
                }
            }
        }

        public string ProfilePicture
        {
            get => CurrentUser.ProfilePicture;
            set
            {
                if (CurrentUser.ProfilePicture != value)
                {
                    CurrentUser.ProfilePicture = value;
                    OnPropertyChanged();
                }
            }
        }


        private string? newPicturePath;

        public string? NewPicturePath
        {
            get => newPicturePath;
            set => newPicturePath = value;
        }

        public void registerCommands()
        {
#if ANDROID
            ChangeProfileCommand = new Command(changeProfilePicture, canUseProfile);
            SelectImageCommand = new Command(PickImageFileAsync);
            TakeAPictureCommand = new Command(TakeAPicture);
            GetFromContacts = new Command(PickAContact);
#endif
#if WINDOWS
            ChangeProfileCommand = new Command(changeProfilePicture, canUseProfile);
            SelectImageCommand = new Command(PickImageFileWinAsync);

        }

        public UserProfilePageViewModel(string userName, string password, string name, string email, string phoneNum, DateTime birthDate, string profilePicture)
        {
            //CurrentUser = new User();
            Username = userName;
            Password = password;
            Name = name;
            Email = email;
            PhoneNum = phoneNum;
            BirthDate = birthDate;
            ProfilePicture = profilePicture;


            //InitSelectImageCommand = new Command(async () =>
            //{
            //    var result = await FilePicker.PickAsync(new PickOptions
            //    {
            //        PickerTitle = "Select an image file",
            //        FileTypes = FilePickerFileType.Images
            //    });
            //    if (result != null)
            //    {
            //        NewPicturePath = result.FullPath;
            //        //ChangeProfileCommand.ChangeCanExecute();
            //    }
            //}, canUseProfile);
//#if WINDOWS
//            ChangeProfileCommand = new Command(changeProfilePicture, canUseProfile);
//            SelectImageCommand = new Command(PickImageFileWinAsync);

//            SelectImageCommand = new Command(() =>
//            {
//                // Logic to select an image file
//                var filePicker = new Microsoft.Win32.OpenFileDialog
//                {
//                    Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif;*.tiff;*.webp;*.svg"
//                };
//                if (filePicker. ShowDialog() == true)
//                {
//                    NewPicturePath = filePicker.FileName;
//                    ChangeProfileCommand.ChangeCanExecute();
//                }
//            }, canUseProfile);
//#if WINDOWS

//SelectImageCommand = new Command(PickImageFileWinAsync);
//async () =>
//{
//    var result = await FilePicker.PickAsync(new PickOptions
//    {
//        PickerTitle = "Select an image file",
//        FileTypes = FilePickerFileType.Images
//    });
//    if (result != null)
//    {
//        NewPicturePath = result.FullPath;
//        if (ChangeProfileCommand is Command cmd)
//            cmd.ChangeCanExecute();
//    }
//});//, canUseProfile);
#endif
        }

        private async void TakeAPicture(object obj)
        {
            {
                try
                {
                    var photo = await MediaPicker.CapturePhotoAsync();
                    if (photo != null)
                    {
                        NewPicturePath = photo.FullPath;
                        ProfilePicture = NewPicturePath;
                        if (ChangeProfileCommand is Command cmd)
                            cmd.ChangeCanExecute();
                    }
                }
                catch (FeatureNotSupportedException fnsEx)
                {
                    // Feature is not supported on the device
                    Console.WriteLine($"Feature not supported: {fnsEx.Message}");
                }
                catch (PermissionException pEx)
                {
                    // Permissions not granted
                    Console.WriteLine($"Permission error: {pEx.Message}");
                }
                catch (Exception ex)
                {
                    // Other errors
                    Console.WriteLine($"An error occurred: {ex.Message}");
                }
            }
        }

        private async void PickAContact(object obj)
        {
#if ANDROID
            PermissionStatus status = await Permissions.CheckStatusAsync<Permissions.ContactsRead>();

            if (status != PermissionStatus.Granted)
            {
                status = await Permissions.RequestAsync<Permissions.ContactsRead>();
            }

            if (status == PermissionStatus.Granted)
            {
                try
                {
                    var contact = await Contacts.Default.PickContactAsync();

                    if (contact == null)
                        return;

                    string id = contact.Id;
                    string namePrefix = contact.NamePrefix;
                    string givenName = contact.GivenName;
                    string middleName = contact.MiddleName;
                    string familyName = contact.FamilyName;
                    string nameSuffix = contact.NameSuffix;
                    string displayName = contact.DisplayName;
                    List<ContactPhone> phones = contact.Phones; // List of phone numbers
                    List<ContactEmail> emails = contact.Emails; // List of email addresses
                    Name = givenName;
                    PhoneNum = phones[0].ToString();
                    Email = emails[0].ToString();
                    }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    // Most likely permission denied
                }
            }
            else
            {

                var toast = Toast.Make("Cannot get contacts - permission denied", CommunityToolkit.Maui.Core.ToastDuration.Short, 15);
                await toast.Show(new CancellationTokenSource().Token);
          
                // Handle permission denied scenario (e.g., inform the user)
            }
#endif
        }

        // Fix for CS1061: Await the Task<FileResult?> and then access FullPath

        public async void PickImageFileWinAsync()
        {
            var result = await FilePicker.PickAsync(new PickOptions
            {
                PickerTitle = "Select an image file",
                FileTypes = FilePickerFileType.Images
            });
            if (result != null)
            {
                NewPicturePath = result.FullPath;
                if (ChangeProfileCommand is Command cmd)
                    cmd.ChangeCanExecute();
            }
        }

        public async void PickImageFileAsync()
        {
            var result = await FilePicker.PickAsync(new PickOptions
            {
                PickerTitle = "Select an image file",
                FileTypes = FilePickerFileType.Images
            });

            NewPicturePath = result?.FullPath;
            ProfilePicture = NewPicturePath;
            Console.WriteLine(  NewPicturePath);

        }

        private bool canUseProfile()
        {
            if (string.IsNullOrEmpty(newPicturePath)) return false;
            if (!System.IO.File.Exists(newPicturePath)) return false;
            var allowedExtensions = new[] { ".jpg", ".jpeg", ".png", ".bmp", ".gif", ".tiff", ".webp", ".svg" };
            var extension = System.IO.Path.GetExtension(newPicturePath)?.ToLowerInvariant();
            if (string.IsNullOrEmpty(extension) || !allowedExtensions.Contains(extension))
                return false;
            return true;
        }

        private void changeProfilePicture()
        {
            ProfilePicture = newPicturePath;

        }

        public UserProfilePageViewModel(User user)
        {
            if (user == null) throw new ArgumentNullException(nameof(user));
            LoadFromUser(user);
            Console.WriteLine("User Loaded!!");
            Console.WriteLine(ToString());
            registerCommands();
        }

        public UserProfilePageViewModel()
        {

            Console.WriteLine("check2");
        }
        public override string ToString()
        {
            return $"UserName: {Username}, Name: {Name}, Email: {Email}, PhoneNum: {PhoneNum}, BirthDate: {BirthDate.ToShortDateString()}, ProfilePicture: {ProfilePicture}";
        }
        public void UpdateProfile(string userName, string password, string name, string email, string phoneNum, DateTime birthDate, string profilePicture)
        {
            Username = userName;
            Password = password;
            Name = name;
            Email = email;
            PhoneNum = phoneNum;
            BirthDate = birthDate;
            ProfilePicture = profilePicture;
        }
        public bool IsValid()
        {
            return !string.IsNullOrWhiteSpace(Username) &&
                   !string.IsNullOrWhiteSpace(Password) &&
                   !string.IsNullOrWhiteSpace(Name) &&
                   !string.IsNullOrWhiteSpace(Email) &&
                   !string.IsNullOrWhiteSpace(PhoneNum) &&
                   BirthDate != default(DateTime) &&
                   !string.IsNullOrWhiteSpace(ProfilePicture);
        }
        public void ClearProfile()
        {
            Username = string.Empty;
            Password = string.Empty;
            Name = string.Empty;
            Email = string.Empty;
            PhoneNum = string.Empty;
            BirthDate = default(DateTime);
            ProfilePicture = string.Empty;
        }
        public void LoadFromUser(Models.User user)
        {
            if (user == null) throw new ArgumentNullException(nameof(user));
            CurrentUser = user;
            Username = user.Username;
            Password = user.Password;
            Name = user.Name;
            Email = user.Email;
            PhoneNum = user.PhoneNum;
            BirthDate = user.BirthDate;
            ProfilePicture = user.ProfilePicture;
        }
        public Models.User ToUser()
        {
            return new Models.User
            {
                Username = Username,
                Password = Password,
                Name = Name,
                Email = Email,
                PhoneNum = PhoneNum,
                BirthDate = BirthDate,
                ProfilePicture = ProfilePicture
            };
        }
        public void UpdateFromUser(Models.User user)
        {
            if (user == null) throw new ArgumentNullException(nameof(user));
            Username = user.Username;
            Password = user.Password;
            Name = user.Name;
            Email = user.Email;
            PhoneNum = user.PhoneNum;
            BirthDate = user.BirthDate;
            ProfilePicture = user.ProfilePicture;
        }

        public ICommand InitSelectImageCommand
        {
            get;
            set;
        }

        public ICommand ChangeProfileCommand
        {
            get;
            set;
        }

        public ICommand SelectImageCommand
        {
            get;
            set;
        }

        public ICommand TakeAPictureCommand
        {
            get;
            set;
        }

        public ICommand GetFromContacts
        {
            get;
            set;
        }
    }
}
