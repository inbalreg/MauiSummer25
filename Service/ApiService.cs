using MauiSummer25.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace MauiSummer25.Service
{
	/// <summary>
	/// מימוש של שירות ההתחברות המדמה קריאה ל-API חיצוני.
	/// </summary>
	public class ApiService : IUserServices
	{
		/// <summary>
		/// בנאי של שירות ה-API.
		/// כאן ניתן להגדיר תלויות כמו HttpClient או הגדרות תצורה.
		/// </summary>
		public ApiService()
		{
			// Initialize any necessary services or configurations here
		}

		/// <summary>
		/// מבצע אימות פרטי משתמש מול שירות API.
		/// </summary>
		/// <param name="username">שם המשתמש.</param>
		/// <param name="password">סיסמת המשתמש.</param>
		/// <returns>אמת (true) אם ההתחברות הצליחה, אחרת שקר (false).</returns>
		public bool Login(string username, string password)
		{
			// זהו מימוש דמה (placeholder). בלוגיקה אמיתית, תתבצע כאן קריאת רשת
			// לשרת שיאמת את הפרטים ויחזיר תשובה בהתאם.
			return true;
		}

        //public bool Register(string username, string password)
        //{
        //    throw new NotImplementedException();
        //}

        bool IUserServices.deleteUserByUsername(string username)
        {
            throw new NotImplementedException();
        }

        User? IUserServices.getUserByUsername(string username)
        {
            throw new NotImplementedException();
        }

        //List<User> IUserServices.GetUsers() => throw new NotImplementedException();

        async Task<List<User>> IUserServices.GetUsers()
        {
            throw new NotImplementedException();
        }

        bool IUserServices.Register(string name, string username, string password, string email, string phoneNum, DateTime date)
        {
            throw new NotImplementedException();
        }

        
    }
}