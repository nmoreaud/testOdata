namespace WebApplication1.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Validation;
    using System.Text;
    using TestOdataWS.Models;

    public partial class ModelDb : DbContext
    {
        public ModelDb()
            : base("name=ModelDb")
        {
        }

        public virtual DbSet<Credential> credentials { get; set; }
        public virtual DbSet<UserRights> userrights { get; set; }
        public virtual DbSet<Site> sites { get; set; }
        public virtual DbSet<User> users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {


            /*modelBuilder.Entity<Site>()
                .HasMany(e => e.users)
                .WithRequired(e => e.site)
                .HasForeignKey(e => e.SiteId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.credentials)
                .WithRequired(e => e.user)
                .HasForeignKey(e => e.UserId)
                .WillCascadeOnDelete(false);
            */


            /*
                        modelBuilder.Entity<User>()
                            .HasMany(e => e.userRights)
                            .WithRequired(e => e.user)
                            .HasForeignKey(e => e.UserId)
                            .WillCascadeOnDelete(false);


                        */

            /*modelBuilder.Entity<Credential>()
               .Property(e => e.graphicalReference)
               .IsUnicode(false);

           modelBuilder.Entity<OperatorRights>()
               .Property(e => e.name)
               .IsUnicode(false);

           modelBuilder.Entity<Site>()
               .Property(e => e.name)
               .IsUnicode(false);*/


            /*modelBuilder.Entity<User>()
                .Property(e => e.lastName)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.firstName)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.civility)
                .IsUnicode(false);*/

            /*modelBuilder.Entity<Operator>()
                .Property(e => e.loggin)
                .IsUnicode(false);

            modelBuilder.Entity<Operator>()
                .Property(e => e.password)
                .IsUnicode(false);*/
        }

        public override int SaveChanges()
        {
            try
            {
                return base.SaveChanges();
            }
            catch (DbEntityValidationException dbValEx)
            {
                var outputLines = new StringBuilder();
                foreach (var eve in dbValEx.EntityValidationErrors)
                {
                    outputLines.AppendFormat("{0}: Entity of type \"{1}\" in state \"{2}\" has the following validation errors:"
                      , DateTime.Now, eve.Entry.Entity.GetType().Name, eve.Entry.State);

                    foreach (var ve in eve.ValidationErrors)
                    {
                        outputLines.AppendFormat("- Property: \"{0}\", Error: \"{1}\""
                         , ve.PropertyName, ve.ErrorMessage);
                    }
                }

                throw new DbEntityValidationException(string.Format("Validation errors\r\n{0}"
                 , outputLines.ToString()), dbValEx);
            }
        }
    }
}