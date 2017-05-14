namespace TestOdataWS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("users")]
    public partial class User
    {
        public User()
        {
            credentials = new HashSet<Credential>();
            userRights = new HashSet<UserRights>();
        }

        public int id { get; set; }

        [Required]
        [StringLength(1073741823)]
        [Column(Order=1)]
        public string lastName { get; set; }

        [StringLength(1073741823)]
        [Column(Order = 2)]
        public string firstName { get; set; }

        /*private static readonly CompiledExpression<User, string> fullNameExpression
           = DefaultTranslationOf<User>.Property(e => e.FullName).Is(e => e.FirstName + " " + e.LastName);

        [NotMapped]
        public string fullName
        {
            get { return fullNameExpression.Evaluate(this); }
        }*/

        // https://daveaglick.com/posts/computed-properties-and-entity-framework
        [NotMapped]
        //[Computed]
        public string fullName
        {
            get { return firstName + " " + lastName; }
        }

        public DateTime? birthDate { get; set; }

        [StringLength(1073741823)]
        public string civility { get; set; }

        [ForeignKey("site")]
        public int? siteId { get; set; }

        public virtual ICollection<Credential> credentials { get; set; }

        public virtual Site site { get; set; }

        [StringLength(1073741823)]
        public string loggin { get; set; }

        [StringLength(1073741823)]
        public string password { get; set; }

        public virtual ICollection<UserRights> userRights { get; set; }

        public bool isOperator {
            get {
                return ! String.IsNullOrWhiteSpace(loggin);
            }
        }
    }
}
