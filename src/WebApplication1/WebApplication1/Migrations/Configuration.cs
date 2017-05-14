namespace WebApplication1.Migrations
{
    using System.Data.Entity.Migrations;
    using TestOdataWS.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<WebApplication1.Models.ModelDb>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;

            SetSqlGenerator("MySql.Data.MySqlClient", new MySql.Data.Entity.MySqlMigrationSqlGenerator());
        }

        protected override void Seed(WebApplication1.Models.ModelDb context)
        {
            Site bordeaux = new Site { name = "Bordeaux" };
            Site paris = new Site { name = "Paris" };
            Site aix = new Site { name = "Aix en Provence" };
            context.sites.AddOrUpdate(
                s => s.name,
                bordeaux,
                paris,
                aix
            );

            context.users.AddOrUpdate(
                p => p.firstName,
                new User { firstName = "Nicolas", lastName = "Moreaud", site = bordeaux },
                new User { firstName = "Kevin", lastName = "Gossent", site = paris },
                new User { firstName = "Magali", lastName = "Moreaud", site = paris }
            );

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
