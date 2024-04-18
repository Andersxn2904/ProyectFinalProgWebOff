
using DanderiTV.Layer.Application.Models.Actor;
using System.ComponentModel.DataAnnotations;

namespace DanderiTV.Layer.Application.Models.Serie
{
    public class MovieViewModel
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }
        public string? Description { get; set; }
        public string ImagePath { get; set; }
        public int? Streams { get; set; }
        public string TrailerPath { get; set; }
        public string? Director { get; set; }
        public int DirectorID { get; set; }
        public List<ActorViewModel>? Actors { get; set; }

    }
}
