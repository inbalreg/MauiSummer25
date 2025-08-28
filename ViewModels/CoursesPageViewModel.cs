using SQLite;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiSummer25.Models;
using SQLite;
using System.Collections.ObjectModel;

namespace MauiSummer25.ViewModels;

public partial class CoursesPageViewModel : ObservableObject
{
    private readonly SQLiteAsyncConnection _db;

    [ObservableProperty]
    private ObservableCollection<ObservableCourse> allCourses = new();

    [ObservableProperty]
    private ObservableCourse selectedCourse;

    [ObservableProperty]
    private bool isBusy;
    //public bool IsBusy
    //{
    //    get => isBusy;
    //    set
    //    {
    //        SetProperty(ref isBusy, value);
    //        LoadDataCommand.NotifyCanExecuteChanged();
    //    }
    //}

    [ObservableProperty]
    private bool hasError;

    public CoursesPageViewModel(SQLiteAsyncConnection db)
    {
        _db = db;
        _ = LoadDataAsync();
    }

    [RelayCommand]
    private async Task LoadDataAsync()
    {
        try
        {
            IsBusy = true;
            HasError = false;

            //await _db.CreateTableAsync<OCourse>();
            var list = await _db.Table<Course>().ToListAsync();

            AllCourses = new ObservableCollection<ObservableCourse>(list.Select(c => new ObservableCourse(c)));
        }
        catch
        {
            HasError = true;
        }
        finally
        {
            IsBusy = false;
        }
    }

    [RelayCommand]
    private async Task DeleteCourseAsync(ObservableCourse course)
    {
        if (course == null)
            return;

        await _db.DeleteAsync(course);
        AllCourses.Remove(course);
    }
}

