namespace ShopBuoi.Data.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using ShopBuoi.Model.Models;
    using System;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ShopBuoi.Data.ShopBuoiDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ShopBuoi.Data.ShopBuoiDBContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.

            var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ShopBuoiDBContext()));

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new ShopBuoiDBContext()));

            var user = new ApplicationUser()
            {
                UserName = "shopbuoi",
                Email = "caodung01101996@gmail.com",
                EmailConfirmed = true,
                BirthDay = DateTime.Now,
                FullName = "ShopBuoi"
            };

            manager.Create(user, "123654$");

            if (!roleManager.Roles.Any())
            {
                roleManager.Create(new IdentityRole { Name = "Admin" });
                roleManager.Create(new IdentityRole { Name = "User" });
            }

            var adminUser = manager.FindByEmail("caodung01101996@gmail.com");

            manager.AddToRoles(adminUser.Id, new string[] { "Admin", "User" });
        }
    }
}