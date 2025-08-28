using MauiSummer25.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiSummer25.Service
{
	/// <summary>
	/// ממשק (Interface) המגדיר את החוזה עבור שירותי התחברות.
	/// כל מחלקה שתממש ממשק זה חייבת לספק לוגיקת התחברות.
	/// </summary>
	public interface IUserServices
	{
		/// <summary>
		/// פעולה לאימות פרטי משתמש.
		/// </summary>
		/// <param name="username">שם המשתמש.</param>
		/// <param name="password">סיסמת המשתמש.</param>
		/// <returns>מחזירה אמת (true) אם ההתחברות הצליחה, אחרת שקר (false).</returns>
		public Task<bool> Login(string username, string password);

		/// <summary>
		/// Registers a new user with the specified username and password.
		/// </summary>
		/// <param name="username">The username for the new user. Cannot be null or empty.</param>
		/// <param name="password">The password for the new user. Cannot be null or empty.</param>
		/// <returns><see langword="true"/> if the registration is successful; otherwise, <see langword="false"/>.</returns>
		public Task<bool> Register(string name, string username, string password, string email, string phoneNum, DateTime date);

        /// <summary>
        /// Retrieves a user by their username.
        /// </summary>
        /// <remarks>This method performs a case-sensitive search for the specified username. Ensure that the username
        /// provided matches the exact case of the stored username.</remarks>
        /// <param name="username">The username of the user to retrieve. Cannot be null or empty.</param>
        /// <returns>The <see cref="User"/> object associated with the specified username, or <see langword="null"/> if no user is
        /// found.</returns>
        public Task<User?> getUserByUsername(string username);

		/// <summary>
		/// Deletes a user from the system based on their username.
		/// </summary>
		/// <remarks>This method attempts to remove the user associated with the specified username.  If no user with
		/// the given username exists, the method returns <see langword="false"/>.</remarks>
		/// <param name="username">The username of the user to be deleted. This value cannot be null or empty.</param>
		/// <returns><see langword="true"/> if the user was successfully deleted; otherwise, <see langword="false"/>.</returns>
		public Task<bool> deleteUserByUsername(string username);

        /// <summary>
        /// Retrieves a list of all users in the system.
        /// </summary>
        /// <returns>A list of <see cref="User"/> objects representing all users.</returns>
        /// </summary>
        /// <returns></returns>
        public Task<List<User>> GetUsers();
    }
}

//////////////
/////using System;
//using System.Collections.Generic;
//using System.Threading.Tasks;
//using MauiSummer25.Models;

//namespace MauiSummer25.Service
//{
//    public interface IUserServices
//    {
//        /// <summary>
//        /// פעולה לאימות פרטי משתמש.
//        /// </summary>
//        /// <param name="username">שם המשתמש.</param>
//        /// <param name="password">סיסמת המשתמש.</param>
//        /// <returns>מחזירה אמת (true) אם ההתחברות הצליחה, אחרת שקר (false).</returns>
//        Task<bool> Login(string username, string password);

//        /// <summary>
//        /// Registers a new user with the specified username and password.
//        /// </summary>
//        /// <param name="username">The username for the new user. Cannot be null or empty.</param>
//        /// <param name="password">The password for the new user. Cannot be null or empty.</param>
//        /// <returns><see langword="true"/> if the registration is successful; otherwise, <see langword="false"/>.</returns>
//        Task<bool> Register(string name, string username, string password, string email, string phoneNum, DateTime date);

//        /// <summary>
//        /// Retrieves a user by their username.
//        /// </summary>
//        /// <remarks>This method performs a case-sensitive search for the specified username. Ensure that the username
//        /// provided matches the exact case of the stored username.</remarks>
//        /// <param name="username">The username of the user to retrieve. Cannot be null or empty.</param>
//        /// <returns>The <see cref="User"/> object associated with the specified username, or <see langword="null"/> if no user is
//        /// found.</returns>
//        Task<User?> getUserByUsername(string username);

//        /// <summary>
//        /// Deletes a user from the system based on their username.
//        /// </summary>
//        /// <remarks>This method attempts to remove the user associated with the specified username.  If no user with
//        /// the given username exists, the method returns <see langword="false"/>.</remarks>
//        /// <param name="username">The username of the user to be deleted. This value cannot be null or empty.</param>
//        /// <returns><see langword="true"/> if the user was successfully deleted; otherwise, <see langword="false"/>.</returns>
//        Task<bool> deleteUserByUsername(string username);

//        /// <summary>
//        /// Retrieves a list of all users in the system.
//        /// </summary>
//        /// <returns>A list of <see cref="User"/> objects representing all users.</returns>
//        Task<List<User>> GetUsers();
//    }
//}
