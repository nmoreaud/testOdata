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
        public string lastName { get; set; }

        [StringLength(1073741823)]
        public string firstName { get; set; }

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
