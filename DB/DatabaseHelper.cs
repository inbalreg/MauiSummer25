//using Android.Content.Res;
using MauiSummer25.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using static Android.Graphics.ImageDecoder;

namespace MauiSummer25.DB
{
    public class DatabaseHelper
    {
    private readonly SQLiteAsyncConnection _db;
        private string dbName = "Ex4.db";
        //dbPath = "C:\\Users\\teach\\source\\repos\\MauiSummer25\\DB\\Ex4.db";
        string dbPath = "";

        public DatabaseHelper()
    {
            dbPath = Path.Combine(FileSystem.AppDataDirectory, dbName);
            initDb();

            _db = new SQLiteAsyncConnection(dbPath);

            //dbPath = Path.Combine(FileSystem.AppDataDirectory, "Ex4.db");
            //_db = new SQLiteAsyncConnection(dbPath);
            Console.WriteLine($"DB Path: {dbPath}");
            Console.WriteLine($"DB Path: {Path.Combine(FileSystem.AppDataDirectory, "Ex4.db")}");

            //_db.CreateTableAsync<User>().Wait();
            //_db.CreateTableAsync<Student>().Wait();
            //_db.CreateTableAsync<Course>().Wait();
        }


        public async Task initDb()
        {
            dbPath = Path.Combine(FileSystem.AppDataDirectory, dbName);

            // Copy the database from Resources/Raw if it doesn’t exist yet
            if (!File.Exists(dbPath))
            {
                using var stream = await FileSystem.OpenAppPackageFileAsync("C:\\Users\\teach\\source\\repos\\MauiSummer25\\Resources\\Raw\\Ex4.db");
                var dest = File.Create(dbPath);
                await stream.CopyToAsync(dest);
            }

        }

        // --------------------- Users ---------------------
        public Task<int> AddUserAsync(User user) => _db.InsertAsync(user);
    public Task<int> UpdateUserAsync(User user) => _db.UpdateAsync(user);
    public Task<int> DeleteUserAsync(User user) => _db.DeleteAsync(user);
    public Task<List<User>> GetUsersAsync() => _db.Table<User>().ToListAsync();


    // --------------------- Students ---------------------
    public Task<int> AddStudentAsync(Student student) => _db.InsertAsync(student);
    public Task<int> UpdateStudentAsync(Student student) => _db.UpdateAsync(student);
    public Task<int> DeleteStudentAsync(Student student) => _db.DeleteAsync(student);
    public Task<List<Student>> GetStudentsAsync() => _db.Table<Student>().ToListAsync();


    // --------------------- Courses ---------------------
    public Task<int> AddCourseAsync(Course course) => _db.InsertAsync(course);
    public Task<int> UpdateCourseAsync(Course course) => _db.UpdateAsync(course);
    public Task<int> DeleteCourseAsync(Course course) => _db.DeleteAsync(course);
    public Task<List<Course>> GetCoursesAsync() => _db.Table<Course>().ToListAsync();
}
}
