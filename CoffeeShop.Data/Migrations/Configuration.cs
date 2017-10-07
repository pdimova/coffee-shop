namespace CoffeeShop.Data.Migrations
{
    using CoffeeShop.Data.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<CoffeeShop.Data.ApplicationDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = false;
            this.AutomaticMigrationDataLossAllowed = false; //TODO
            ContextKey = "CoffeeShop.Data.ApplicationDbContext";
        }

        protected override void Seed(CoffeeShop.Data.ApplicationDbContext context)
        {
            this.SeedAdmin(context);
        }

        private void SeedAdmin(ApplicationDbContext context)
        {
            const string AdminUserName = "admin@admin";
            const string AdminUserNamePassword = "123456";

            if (!context.Roles.Any())
            {
                var roleStore = new RoleStore<IdentityRole>(context);
                var roleManager = new RoleManager<IdentityRole>(roleStore);
                var role = new IdentityRole { Name = "Admin" };
                roleManager.Create(role);

                var userStore = new UserStore<User>(context);
                var userManager = new UserManager<User>(userStore);
                var user = new User
                {
                    UserName = AdminUserName,
                    Email = AdminUserName,
                    EmailConfirmed = true
                };
                userManager.Create(user, AdminUserNamePassword);
                userManager.AddToRole(user.Id, "Admin");

            }
        }
    }
}
