
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MauiSummer25.Models;
using MauiSummer25.Service;
using MauiSummer25.DB;
using SQLite;

namespace MauiSummer25.Service
    {
        public class ApiService : IUserServices
        {
            private readonly DatabaseHelper _db;

           
            public ApiService()
            {
                _db = new DatabaseHelper();
            }

            /// <summary>
            /// מבצע אימות פרטי משתמש מול שירות API.
            /// </summary>
            /// <param name="username">שם המשתמש.</param>
            /// <param name="password">סיסמת המשתמש.</param>
            /// <returns>אמת (true) אם ההתחברות הצליחה, אחרת שקר (false).</returns>

            public async Task<bool> Login(string username, string password)
            {
                var users = await _db.GetUsersAsync();
                var user = users.FirstOrDefault(u => u.Username == username);
                if (user == null)
                    return false;

                return user.Password == password; // ⚠️ In production: use hashing!
            }

            public async Task<bool> Register(string name, string username, string password, string email, string phoneNum, DateTime date)
            {
                var users = await _db.GetUsersAsync();
                var existingUser = users.FirstOrDefault(u => u.Username == username);
                if (existingUser != null)
                    return false;

                var newUser = new User
                {
                    FirstName = name,
                    //Lastname = string.Empty,
                    Username = username,
                    Password = password,
                    PhoneNum = phoneNum,
                    BirthDate = date.ToString("yyyy-MM-dd")
                };

                var result = await _db.AddUserAsync(newUser);
                return result > 0;
            }

            public async Task<User?> getUserByUsername(string username)
            {
                var users = await _db.GetUsersAsync();
                return users.FirstOrDefault(u => u.Username == username);
            }

            public async Task<bool> deleteUserByUsername(string username)
            {
                var users = await _db.GetUsersAsync();
                var user = users.FirstOrDefault(u => u.Username == username);
                if (user == null)
                    return false;

                var result = await _db.DeleteUserAsync(user);
                return result > 0;
            }

            public async Task<List<User>> GetUsers()
            {
                return await _db.GetUsersAsync();
            }
        }
    }


    /// <summary>
    /// בנאי של שירות ה-API.
  //  /// כאן ניתן להגדיר תלויות כמו HttpClient או הגדרות תצורה.
  //  /// </summary>
  //  public ApiService()
		//{
		//	// Initialize any necessary services or configurations here
		//}

		///// <summary>
		///// מבצע אימות פרטי משתמש מול שירות API.
		///// </summary>
		///// <param name="username">שם המשתמש.</param>
		///// <param name="password">סיסמת המשתמש.</param>
		///// <returns>אמת (true) אם ההתחברות הצליחה, אחרת שקר (false).</returns>
		//public bool Login(string username, string password)
		//{
		//	// זהו מימוש דמה (placeholder). בלוגיקה אמיתית, תתבצע כאן קריאת רשת
		//	// לשרת שיאמת את הפרטים ויחזיר תשובה בהתאם.
		//	return true;
		//}

  //      //public bool Register(string username, string password)
  //      //{
  //      //    throw new NotImplementedException();
  //      //}

  //      bool IUserServices.deleteUserByUsername(string username)
  //      {
  //          throw new NotImplementedException();
  //      }

  //      User? IUserServices.getUserByUsername(string username)
  //      {
  //          throw new NotImplementedException();
  //      }

  //      //List<User> IUserServices.GetUsers() => throw new NotImplementedException();

  //      async Task<List<User>> IUserServices.GetUsers()
  //      {
  //          throw new NotImplementedException();
  //      }

  //      bool IUserServices.Register(string name, string username, string password, string email, string phoneNum, DateTime date)
  //      {
  //          throw new NotImplementedException();
  //      }

        
   //}
//}