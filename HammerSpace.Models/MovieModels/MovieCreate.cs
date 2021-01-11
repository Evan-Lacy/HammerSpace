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
        [Display(Name ="Movie Title")]
        public string MovieTitle { get; set; }
        [Required]
        [MinLength(10, ErrorMessage = "Please enter at least 10 characters.")]
        [MaxLength(3000, ErrorMessage = "You description is too long.")]
        [Display(Name ="Movie Description")]
        public string MovieDescription { get; set; }
        [Required]
        [Display(Name = "Run Time (in min)")]
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
