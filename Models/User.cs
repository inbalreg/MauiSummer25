using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiSummer25.Models;

[Table("Users")]
/// <summary>
/// מייצג את מודל הנתונים של משתמש באפליקציה.
/// </summary>
public class User
{
	/// <summary>
	/// Represents the name associated with the current instance.
	/// </summary>
	/// <remarks>This member is private and is not directly accessible outside the class.  Use the appropriate public
	/// properties or methods to interact with this value.</remarks>
    private string firstName;

    public string? FirstName
    {
        get { return firstName; }
        set { 
			
			if(value == null)
				throw new ArgumentNullException(nameof(value), "Name cannot be null.");
            firstName = value; 
		
		}
    }

	/// <summary>
	/// שם המשתמש לצורך הזדהות.
	/// </summary>
	private string username;
    public string? Username
	{
		get { return username; }
		set { 
			if (string.IsNullOrWhiteSpace(value))
				throw new ArgumentException("Username cannot be null or whitespace.", nameof(value));
			username = value;
        }
	}

    /// <summary>
    /// סיסמת המשתמש.
    /// </summary>
    private string password;
    public string? Password
	{
		get { return password;  }
		set
		{
			if (string.IsNullOrWhiteSpace(value))
				throw new ArgumentException("Password cannot be null or whitespace.", nameof(value));
			password = value;
        }
	}

	private EmailAddress email;

	public string Email
	{
		get { return email.Email; }
		set
		{
				if (email == null)
					email = new EmailAddress(value);
				else email.Email = value;
		}
    }

    private string phoneNum;
    public string? PhoneNum
	{
		get { return phoneNum; }
		set
		{
			if (string.IsNullOrWhiteSpace(value))
				throw new ArgumentException("Phone number cannot be null or whitespace.", nameof(value));
			phoneNum = value;
		}
    }

	private string birthDate; //DateTime?

    public string BirthDate
    {
		get { return birthDate; }
		set { birthDate = value; }
	}

	private string profilePicture;

	public string ProfilePicture
    {
		get { return profilePicture; }
		set { profilePicture = value; }
	}

	public User(string name, string username,string password, string emailStr, string phoneNum, DateTime birthDate, string profilePicture)
    {
        FirstName = name;
        Username = username;
        Password = password;
        Email = emailStr;
        PhoneNum = phoneNum;
		//if(birthDate != null)
		BirthDate = birthDate.ToString();
		ProfilePicture = profilePicture;
    }



	public User()
	{
		this.Username = "a";
		this.FirstName = "a";
		this.BirthDate = new DateTime(2000, 1, 1).ToString();
		this.Email = "A1";
		this.Password = "a";
		this.PhoneNum = "a";
		this.profilePicture = "a";
	}

	public User(User user)
	{
		this.Username = user.Username;
		this.FirstName = user.FirstName;
		this.BirthDate = user.BirthDate;
		this.Email = user.Email;
		this.Password = user.Password;
		this.PhoneNum = user.PhoneNum;
		this.profilePicture = user.profilePicture;
	}

    //string name, string username, string password, string email, string phoneNum, Date date
}