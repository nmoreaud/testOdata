namespace TestOdataWS.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("userrights")]
    public partial class UserRights
    {
        public int id { get; set; }

        [Required]
        [StringLength(1073741823)]
        public string name { get; set; }

        public bool granted { get; set; }

        public int userId { get; set; }

        public virtual User user { get; set; }
    }
}
