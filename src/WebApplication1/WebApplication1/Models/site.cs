namespace TestOdataWS.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("sites")]
    public partial class Site
    {
        public Site()
        {
            users = new HashSet<User>();
        }

        public int id { get; set; }

        [Required]
        [StringLength(1073741823)]
        public string name { get; set; }

        public virtual ICollection<User> users { get; set; }
    }
}
