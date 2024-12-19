using Microsoft.Extensions.DependencyInjection;
using SuperPOS.Data;
using SuperPOS.Models;
using SuperPOS.Repositories.UserRepository;
using SuperPOS.Views.Commons;
using System;
using System.Data.Entity;
using System.Windows.Forms;

namespace SuperPOS
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Apply migrations automatically at startup (optional)
            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<SuperPosDataContext, SuperPOS.Migrations.Configuration>());
            Database.SetInitializer(new AppDbInitializer());

            using (var context = new SuperPosDataContext())
            {
                context.Database.Initialize(force: false);
            }

            // Create service collection
            var services = new ServiceCollection();

            // Register dependencies
            ConfigureServices(services);


            // Build the service provider
            ServiceProvider = services.BuildServiceProvider();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LoginForm());
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<SuperPosDataContext>();
            services.AddScoped<IUserRepository, EntityFrameworkUserRepository>();
        }

        public static ServiceProvider ServiceProvider { get; private set; }

        public static User CurrentUser { get; set; }
    }
}
