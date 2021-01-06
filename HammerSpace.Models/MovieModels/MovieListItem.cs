using HammerSpace.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HammerSpace.Models.MovieModels
{
    public class MovieListItem
    {
        public int Id { get; set; }
        public string MovieTitle { get; set; }
        public string MovieDescription { get; set; }
        [Display(Name = "Run Time")]
        public double MovieRunTime { get; set; }
        public string Director { get; set; }
        [Display(Name = "Rated")]
        public MovieRating MovieRating { get; set; }
        [Display(Name = "Genre")]
        public MovieGenre MovieGenre { get; set; }
        [Display(Name = "Released")]
        public int? ReleaseYear { get; set; }
    }
}
