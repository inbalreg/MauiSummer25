using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MauiSummer25.Models;

public class ObservableCourse : INotifyPropertyChanged
{
    private Course course;

    public ObservableCourse(Course course)
    {
        this.course = course;
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public int? CourseId
    {
        get => course.CourseId;
        set
        {
            if (value.HasValue)
            {
                course.CourseId = value.Value;
                OnPropertyChanged();
            }
        }
    }

        public string? CourseName
    {
        get => course.CourseName    ;
            set
            {
                course.CourseName = value;
                OnPropertyChanged();
            }
        }

        public int? HoursNum
        {
            get => course.HoursNum;
            set
            {
                if (value.HasValue)
                {
                    course.HoursNum = value.Value;
                    OnPropertyChanged();
                }
            }
    }

      
        // Expose the underlying entity if needed
        public Course ToCourse()
        {
            return course;
        }
    }
