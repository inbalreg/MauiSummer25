using MauiSummer25.Service;
using MauiSummer25.Views;

namespace MauiSummer25
{
    public partial class App : Application
    {
        private readonly Page firstpage;
        public App(IServiceProvider provider)
        {
            InitializeComponent();
            // Use null-forgiving operator to suppress CS8601, but also check for null and throw if not found
            this.firstpage = provider.GetService<LoginPage>() ?? throw new InvalidOperationException("UserList service not registered.");
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(firstpage);
        }
    }
}