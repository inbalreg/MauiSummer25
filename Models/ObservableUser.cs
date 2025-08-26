
using MauiSummer25.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MauiSummer25.Models
{
    public class ObservableUser : INotifyPropertyChanged
    {
        User user;

        public ObservableUser(User user)
        {
            this.user = user;
        }

        public event PropertyChangedEventHandler? PropertyChanged;


        protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public string? Name
        {
            get => user.Name;
            set
            {
                user.Name = value;
                OnPropertyChanged();

            }
        }

        public string? Username
        {
            get => user.Username;
            set
            {
                user.Username = value;
                OnPropertyChanged();
            }
        }

        public string? Password
        {
            get => user.Password;
            set
            {
                user.Password = value;
                OnPropertyChanged();

            }
        }
        public string Email
        {
            get => user.Email;
            set
            {
                user.Email = value;
                OnPropertyChanged();
            }
        }

        public string? PhoneNum
        {
            get => user.PhoneNum;
            set
            {
                user.PhoneNum = value;
                OnPropertyChanged();

            }
        }

        public DateTime BirthDate
        {
            get => user.BirthDate;
            set
            {
                user.BirthDate = value;
                OnPropertyChanged();

            }
        }

        public string? ProfilePicture
        {
            get => user.ProfilePicture;
            set
            {
                user.ProfilePicture = value;
                OnPropertyChanged();

            }
        }


        //	public string TaskDescription
        //	{
        //		get => task.TaskDescription;
        //		set
        //		{
        //			task.TaskDescription = value;
        //			OnPropertyChanged();
        //		}
        //	}


        //	public User? User
        //	{
        //		get => task.User;
        //		set
        //		{
        //			task.User = value;
        //			OnPropertyChanged();
        //		}
        //	}
        //	public int  TaskId
        //	{
        //		get
        //		{
        //			return task.TaskId;
        //		}
        //		set
        //		{

        //			task.TaskId = value;
        //			OnPropertyChanged();
        //		}
        //	}

        //	public UrgencyLevel? UrgencyLevel
        //	{
        //		get => task.UrgencyLevel;
        //		set
        //		{
        //			task.UrgencyLevel = value;
        //			OnPropertyChanged();
        //		}
        //	}
        //	public DateOnly TaskDueDate
        //	{
        //		get => task.TaskDueDate;
        //		set
        //		{
        //			task.TaskDueDate = value;
        //		}
        //	}
        //	public DateOnly? TaskActualDate
        //	{
        //		get=>task.TaskActualDate; set {
        //			task.TaskActualDate = value;OnPropertyChanged(); }
        //	}
        //	public ObservableCollection<TaskComment> TaskComments
        //	{
        //		get=>new ObservableCollection<TaskComment>(task.TaskComments); set {
        //			task.TaskComments = value.ToList();
        //			OnPropertyChanged();

        //		}
        //	}
        //	public string TaskImage { get=>task.TaskImage; set { task.TaskImage = value;OnPropertyChanged(); } } 
        //	public ObservableUser(UserTask t)
        //	{
        //		task = t;
        //	}

        //	public UserTask ToUserTask()
        //	{
        //		return task;
        //	}
        //}
    }
}
