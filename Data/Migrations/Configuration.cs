namespace Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Core.Helpers.Security;
    using Core.Domains;

    internal sealed class Configuration : DbMigrationsConfiguration<Data.AppContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Data.AppContext context)
        {
            var users = context.Set<Account>();

            if (users.Any())
                return;

            // else seed your data here
            var salt = "";
            //  This method will be called after migrating to the latest version.

            var user = new Account()
            {
                Username = "admin",
                PasswordHash = SecurityHelper.HashPassword("password", ref salt),
                PasswordSalt = salt
            };
            users.AddOrUpdate(user);
            context.SaveChanges();

            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
