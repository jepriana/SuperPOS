using SuperPOS.Core.Helpers;
using SuperPOS.Models;
using System.Data.Entity;
using System.Data.Entity.Migrations.Infrastructure;

namespace SuperPOS.Data
{
    internal class AppDbInitializer : CreateDatabaseIfNotExists<SuperPosDataContext>
    {
        public AppDbInitializer() 
        {
        }
        protected override void Seed(SuperPosDataContext context)
        {
            context.Users.Add(new User
            {
                Firstname = "Admin",
                Lastname = "User",
                Username = "admin",
                Password = PasswordHelper.HashPassword("Rahasia"),
                IsAdmin = true,
            });
            base.Seed(context);
        }
    }
}
