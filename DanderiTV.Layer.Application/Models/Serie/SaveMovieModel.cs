using DanderiTV.Layer.Application.Models.Actor;
using System.ComponentModel.DataAnnotations;



namespace DanderiTV.Layer.Application.Models.Serie
{
    public class SaveMovieModel
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "You must enter a Title")]
        [DataType(DataType.Text)]
        public string Title { get; set; }

        public int Year { get; set; }

        [Required(ErrorMessage = "You must enter a Description")]
        [DataType(DataType.Text)]
        public string? Description { get; set; }

        [Required(ErrorMessage = "You must enter an Image")]
        [DataType(DataType.Text)]
        public string ImagePath { get; set; }
        public int? Streams { get; set; }

        [Required(ErrorMessage = "You must enter a trailer Url")]
        [DataType(DataType.Text)]
        public string TrailerPath { get; set; }

        public int DirectorID { get; set; }

        public List<TrailersApp.Entity.Entities.Actor>? Actors { get; set; }
        public List<TrailersApp.Entity.Entities.Director>? Directors { get; set; }

    }
}
