
using AllianceManagementSystem.Wpf.Controls.Landing_Page;
using AllianceManagementSystem.Wpf.Controls.Landing_Page.User_Control;
using AllianceManagementSystem.Wpf.IPresenter.User_Interface;
using AllianceManagementSystem.Wpf.Presenter.User_Presenter;
using AllianceManagementSystem.Wpf.Views.LandingPageView;
using AllianceManagementSystem.Wpf.Views.LoginView;
using EntityFramework.Interface.IUserRepository;
using EntityFramework.Repositories.User_Repositories;
using EntityFramework.Services;
using EntityFramework.StoreContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using System.Windows;

namespace AllianceManagementSystem.Wpf
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        private readonly IHost _host;

        public App()
        {
            _host = CreateHostBuilder().Build();
       
  
        }

        public static IHostBuilder CreateHostBuilder(string[]? args = null)
        {
            return Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration(x =>
                {
                    x.AddJsonFile("appsettings.json");
                })
                .ConfigureServices((context, services) =>
                {
                    string connectionString = context.Configuration.GetConnectionString("DevConnection");
                    services.AddDbContext<Datacontext>(x =>
                    {
                        x.UseSqlServer(connectionString);
                        x.UseSnakeCaseNamingConvention(); // Apply snake_case naming convention
                        x.EnableSensitiveDataLogging(); // Add this for debugging purposes
                        x.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
                        x.EnableDetailedErrors(); // Add this for detailed error messages
                        x.EnableServiceProviderCaching(); // Enable service provider caching
   
                    });

                    //services.AddScoped<IUserPresenter, UserPresenter>();
                    //services.AddDbContext<Storecontext>(o => o.UseSqlServer(connectionString));
                    //services.AddSingleton(new StoreContextFactory(connectionString));
                    services.AddSingleton<MainWindow>();
                    services.AddScoped<LoginPage>(); 
                    services.AddScoped<LandingPage>();
                    services.AddScoped<AddUserControl>();
                    services.AddScoped<UserListPresenter>();


                    services.AddSingleton<IUnitofwork, Unitofwork>();
                    services.AddSingleton<IUserService, UserService>();
                    services.AddSingleton<IUserRepository, UserRepository>();

                });
        }


        protected override void OnStartup(StartupEventArgs e)
        {

            _host.Start();

            MainWindow = _host.Services.GetRequiredService<LandingPage>();

            MainWindow.Show();

            base.OnStartup(e);



        }

        protected override async void OnExit(ExitEventArgs e)
        {
            await _host.StopAsync();
            _host.Dispose();

            base.OnExit(e);
        }



    }
}
