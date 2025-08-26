//using IntelliJ.Lang.Annotations;
using System.Collections.ObjectModel;
using System.Windows.Input;
using MauiSummer25.Models;
using MauiSummer25.Service;

namespace MauiSummer25.ViewModels;

public class UserListPageViewModel : ViewModelBase
{

    #region Fields
    IUserServices _service;
    List<User> _allUsersList = new();
    Task loadDataTask;
    string _searchText;
    bool _hasError = false;
    bool _isLoading;
    private ObservableUser? selectedUser;
    ObservableCollection<ObservableUser> _allUsersObserve = new(); // Collection of User for binding to the UI
    ObservableCollection<ObservableUser> _filteredUsers = new(); // Collection of filtered Users for binding to the UI

    #endregion

    #region

    public UserListPageViewModel(IUserServices service)
    {
        SearchText = string.Empty;
        _service = service;
        //_basicUsersList = new();
        //LoadUsersCommand = new Command(async () => await LoadUserAsync());
        FilterUserCommand = new Command<string>(async (query) => await FilterUsers(query));
        ClearFilterCommand = new Command(async () => await FilterUsers(string.Empty), () => string.IsNullOrEmpty(SearchText) && !IsLoading);
                                                                                                                                 // ChangeTaskDescriptionCommand = new Command(() => { if (_basicUsersList.Count > 0) { Tasks[0].TaskDescription = "וואחד שינוי"; } });
        DeleteUserCommand = new Command<ObservableUser>(DeleteUser);
        //SearchCommand = new Command<string>(FilterUsers);    //OnSearch);

        ShowDetailsPageCommand = new Command(async () => await ShowDetails());
        loadDataTask = LoadUserAsync();
        SelectedUser = null;
        LoadDataCommand = new Command(async () => await LoadUserAsync(), () => !IsLoading); 

        /*
        _service = (IUserServices)(service as DBMokup);
        // Initialize properties or commands here if needed
        
        ClearFilterCommand = new Command(ClearFilter, () => string.IsNullOrEmpty(SearchText));
       
        */

        // Load all tasks from the service
        ////*****//////loadDataTask = GetTasksAsync(1);
        //DeleteTaskCommand = new Command<User>(DeleteTask);
        //AllTasks = new();
    }

    private async Task ShowDetails()
    {
        throw new NotImplementedException();
    }

    //{
    //	Content = new VerticalStackLayout
    //	{
    //		Children = {
    //			new Label { HorizontalOptions = LayoutOptions.Center, VerticalOptions = LayoutOptions.Center, Text = "Welcome to .NET MAUI!"
    //			}
    //		}
    //	};

    public ObservableUser? SelectedUser
    {
        get => selectedUser;
        set
        {
            if (selectedUser != value)
            {
                selectedUser = value;
                OnPropertyChanged();
            }
        }
    }
    public ObservableCollection<ObservableUser> AllUsers 
    { get => _allUsersObserve;
        set
        {
            if (_allUsersObserve != value)
            {
                _allUsersObserve = value;
                OnPropertyChanged();
            }
        }
    }
   // public ObservableCollection<ObservableUser> FilteredUsers { get; set; } ;

    public bool IsLoading
    {
        get => _isLoading;
        set
        {
            if (_isLoading != value)
            {
                _isLoading = value;
                OnPropertyChanged();
                (ClearFilterCommand as Command)?.ChangeCanExecute(); // Update the command state when SearchText changes


            }
        }
    }

    public bool HasError

    {
        get => _hasError;
        set
        {
            if (_hasError != value)
            {
                _hasError = value;
                OnPropertyChanged();
            }
        }
    }

    public string SearchText
    {
        get => _searchText;
        set
        {
            if (_searchText != value)
            {
                _searchText = value;
                OnPropertyChanged();
                // Update the command state when SearchText changes
                (ClearFilterCommand as Command)?.ChangeCanExecute();
            }
        }
    }
    #endregion

    #region Commands
    // Define commands for user interactions, e.g., search, add task, etc.

    //public ICommand DeleteUserCommand
    //{
    //    get;
    //}
    public ICommand SearchCommand
    {
        get;
    }
    //public ICommand ClearFilterCommand
    //{
    //    get;
    //}

    public ICommand LoadDataCommand
    {
        get;
    }
    //#endregion


    // change to user, Users list? or basic?
    private void DeleteUser(ObservableUser user)
    {
        if (user == null) return; // Ensure task is not null
        _allUsersObserve.Remove(user);
    }



    //public ICommand LoadUsersCommand
    //{
    //    get;
    //}
    public ICommand FilterUserCommand
    {
        get;
    }
    public ICommand ClearFilterCommand
    {
        get;
    }
    public ICommand ChangeUserDescriptionCommand
    {
        get;
    }
    public ICommand DeleteUserCommand
    {
        get;
    }
    public ICommand ShowDetailsPageCommand
    {
        get;
    }

    #endregion
    private async Task LoadUserAsync()//GetUsersAsync()//int userId)
    {
        if (IsBusy)
            return;
        IsBusy = true;
        try
        {
            _allUsersList.Clear();
            _allUsersObserve.Clear();
            _allUsersList = await _service.GetUsers();
            // Clear the existing collection and add the new tasks
          
            foreach (var user in _allUsersList)
            {
                _allUsersObserve.Add(new ObservableUser(user));
            }
        }
        catch (Exception ex)
        {
            HasError = true; // Set error state if an exception occurs	
                             // Handle exceptions, e.g., log the error or show a message to the user
            Console.WriteLine($"Error loading users: {ex.Message}");
        }
        finally
        {//*****
            //loadDataTask = null; // Reset the task after loading
            OnPropertyChanged(nameof(_allUsersObserve)); // Notify that tasks have been loaded
            IsBusy = false;
        }
    }


    private async Task FilterUsers(string query)
    {
        IsLoading = true;
        if (!string.IsNullOrEmpty(query))
        {
            _filteredUsers = new ObservableCollection<ObservableUser>(_allUsersObserve.Where(x => x.Name.Contains(query)));
            Application.Current?.Dispatcher.Dispatch(() =>
            {
                AllUsers.Clear();
                foreach (var user in _filteredUsers)
                {
                    AllUsers.Add(user);
                }
            });
            IsLoading = false;
            return;
        }
        await LoadUserAsync();
        IsLoading = false;
    }

    /// <summary>
    /// Loads User tasks from the service.
    /// </summary>
    //public async Task LoadUsersAsync()
    //{
    //    IsLoading = true;
    //    try
    //    {
    //        userTask.Clear();
    //        _allUserTasks.Clear();
    //        userTask = await _taskService.GetTasks(UserId); // Assuming 1 is the User ID
    //        if (userTask != null && userTask.Count > 0)
    //        {
    //            foreach (var task in userTask)
    //            {
    //                _allUserTasks.Add(new ObservableUserTask(task));
    //            }
    //        }

    //        Tasks.Clear();
    //        foreach (var task in _allUserTasks)
    //        {
    //            Tasks.Add(task);
    //        }
    //        await Task.Delay(500);
    //        IsLoading = false;
    //        HasError = false;

    //    }
    //    catch (Exception ex)
    //    {
    //        Console.WriteLine($"Error loading tasks: {ex.Message}");
    //        HasError = true;
    //    }
    //    finally
    //    {
    //        IsLoading = false;
    //        IsBusy = false;
    //    }
    //}

    //private void ClearFilter()
    //{
    //    throw new NotImplementedException();
    //}


    // Add properties, commands, and methods for the UserTasksPage functionality
}

