using MauiSummer25.Service;
using MauiSummer25.ViewModels;
using Microsoft.Extensions.Logging;
using CommunityToolkit.Maui;
//using Camera.MAUI;
using MauiSummer25.DB;
using Microsoft.Extensions.DependencyInjection;

namespace MauiSummer25
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkitCamera() // Add the use of the core toolkit
                .UseMauiCommunityToolkit() // Add the use of the general toolkit
             //   .UseMauiCameraView() // Add the use of the plugging
                //.UseMauiCommunityToolkit()          // general toolkit
                //.UseMauiCommunityToolkitCamera()   // camera toolkit
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("MaterialSymbolsOutlined.ttf", "MaterialSymbols");

                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                })
                .AddDB()
               ;


            ;

            // builder.Services.AddSingleton<Views.LoginPage>();
            // builder.Services.AddTransient<ViewModels.LoginPageViewModel>();

            // builder.Services.AddSingleton<Views.RegistrationPage>();
            // builder.Services.AddTransient<ViewModels.RegistrationPageViewModel>();


            // builder.Services.AddSingleton<Views.UserList>();
            // builder.Services.AddTransient<ViewModels.UserListPageViewModel>();

            // builder.Services.AddSingleton<Views.AddUserPage>();
            // builder.Services.AddTransient<ViewModels.AddUserPageViewModel>();

            // builder.Services.AddSingleton<Views.UserProfilePage>();
            //// builder.Services.AddTransient<ViewModels.UserPro>();



            // builder.Services.AddSingleton<IUserServices, DBMokup>();

            #region הזרקת דפים
            builder.AddPages().AddViewModels().AddServices();
            #endregion


#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }

        #region load DB

        public static MauiAppBuilder AddDB(this MauiAppBuilder builder)
        {
            string dbPath = Path.Combine(FileSystem.AppDataDirectory, "/DB/Ex4.db");
            builder.Services.AddSingleton<DatabaseHelper>(s => ActivatorUtilities.CreateInstance<DatabaseHelper>(s, dbPath));
            return builder;
        }
        #endregion

        #region load Pages
        public static MauiAppBuilder AddPages(this MauiAppBuilder builder)
        {
            builder.Services.AddSingleton<Views.LoginPage>();
            builder.Services.AddSingleton<Views.RegistrationPage>();
            builder.Services.AddSingleton<Views.UserList>();
            builder.Services.AddSingleton<Views.CoursesPage>();
            builder.Services.AddSingleton<Views.UserProfilePage>();
       
            builder.Services.AddSingleton<AppShell>();


            return builder;
        }
        #endregion
        #region load ViewModels
        public static MauiAppBuilder AddViewModels(this MauiAppBuilder builder)
        {
            builder.Services.AddTransient<ViewModels.LoginPageViewModel>();
            builder.Services.AddTransient<ViewModels.RegistrationPageViewModel>();
            builder.Services.AddTransient<ViewModels.UserListPageViewModel>();
            builder.Services.AddTransient<ViewModels.UserProfilePageViewModel>();

            builder.Services.AddTransient<ViewModels.CoursesPageViewModel>();
            builder.Services.AddSingleton<AppShellViewModel>();

            return builder;
        }
        #endregion

        #region load Services
        public static MauiAppBuilder AddServices(this MauiAppBuilder builder)
        {
           // builder.Services.AddSingleton<IUserServices, DBMokup>();
            builder.Services.AddSingleton<IUserServices, ApiService>();

            return builder;
        }
        #endregion
    }
}
