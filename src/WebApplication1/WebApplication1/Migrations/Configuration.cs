namespace WebApplication1.Migrations
{
    using System.Data.Entity.Migrations;
    using TestOdataWS.Models;
    using WebApplication1.Models;

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
            context.SaveChanges();

            User Nicolas = new User { firstName = "Nicolas", lastName = "M", site = bordeaux };
            User Marthe = new User { firstName = "Marthe", lastName = "M", site = paris };
            User Kevin = new User { firstName = "Kevin", lastName = "G", site = paris };
            User Magali = new User { firstName = "Magali", lastName = "M", site = paris };
            context.users.AddOrUpdate(
                p => p.firstName,
                Nicolas,
                Kevin,
                Magali
            );
            context.SaveChanges();

            context.credentials.AddOrUpdate(
                ca => ca.graphicalReference,
                new CredentialTechnoA { graphicalReference = "Visiteur 1", technoAPrivateData = "secretKey1", user = Nicolas },
                new CredentialTechnoA { graphicalReference = "Visiteur 2", technoAPrivateData = "secretKey2" },
                new CredentialTechnoB { graphicalReference = "Visiteur 3", technoBIsWireless = false, user = Kevin },
                new CredentialTechnoB { graphicalReference = "Visiteur 4", technoBIsWireless = false, user = Magali },
                new CredentialTechnoB { graphicalReference = "Visiteur 5", technoBIsWireless = true }
            );
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
