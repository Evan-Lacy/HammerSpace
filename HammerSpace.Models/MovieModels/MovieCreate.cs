using HammerSpace.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HammerSpace.Models.MovieModels
{
    public class MovieCreate
    {
        [Required]
        public string MovieTitle { get; set; }
        [Required]
        [MinLength(10, ErrorMessage = "Please enter at least 10 characters.")]
        [MaxLength(300, ErrorMessage = "You description is too long.")]
        public string MovieDescription { get; set; }
        [Required]
        [Display(Name = "Run Time")]
        public double MovieRunTime { get; set; }
        public string Director { get; set; }
        [Required]
        [Display(Name = "Rated")]
        public MovieRating MovieRating { get; set; }
        [Required]
        [Display(Name = "Genre")]
        public MovieGenre MovieGenre { get; set; }
        [Display(Name = "Released")]
        public int? ReleaseYear { get; set; }
    }
}
