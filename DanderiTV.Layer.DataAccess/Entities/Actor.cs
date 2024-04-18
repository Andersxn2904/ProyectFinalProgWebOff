
using System.ComponentModel.DataAnnotations.Schema;

namespace TrailersApp.Entity.Entities
{
    [Table("Actors")]
    public class Actor
    {
        [Column("ID")]
        public int ID { get; set; }
		[Column("Name")]
		public string Name { get; set; }
		[Column("Lastname")]
		public string Lastname { get; set; }
    }
}
