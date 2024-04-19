
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrailersApp.Entity.Entities
{
    [Table("Users")]
    public class User
    {
        [Key]
        [Column("ID")]
        public string ID { get; set; }
		[Column("UserName")]
		public string UserName { get; set; }
		[Column("Password")]
		public string Password { get; set; }
		[Column("Role")]
		public string Role { get; set; }


    }
}
