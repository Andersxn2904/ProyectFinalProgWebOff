
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrailersApp.Entity.Entities
{
    [Table("Actors")]
    public class Actor
    {
        [Key]
        [Column("ID")]
        public int ID { get; set; }
		[Column("Name")]
		public string Name { get; set; }
		[Column("Lastname")]
		public string Lastname { get; set; }
    }
}
