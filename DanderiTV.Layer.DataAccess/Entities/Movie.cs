
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrailersApp.Entity.Entities
{
    [Table("Movies")]
    public class Movie
    {
        [Key]
        [Column("ID")]
        public int ID { get; set; }
        [Column("Title")]
        public string Title { get; set; }
        [Column("Year")]
        public int Year { get; set; }
        [Column("Description")]
        public string Description { get; set; }
        [Column("ImagePath")]
        public string ImagePath { get; set; }
        [Column("Streams")]
        public int Streams { get; set; }
        [Column("TrailerPath")]
        public string TrailerPath { get; set; }
        [Column("DirectorID")]
        public int DirectorID { get; set; }
       
        
    }
}
