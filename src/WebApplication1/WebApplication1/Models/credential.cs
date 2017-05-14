namespace TestOdataWS.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("credentials")]
    public partial class Credential
    {
        public int id { get; set; }

        [Required]
        [StringLength(1073741823)]
        public string graphicalReference { get; set; }

        public int userId { get; set; }

        public virtual User user{ get; set; }
    }
}
