using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HammerSpace.Data
{
    //Movie item for the HammerSpace database - contains the below properties, with Nullable field
    //for Release Year and, if updated to C# vers 8.0, nullable Director field. Enums hold the values
    //for the Ratings and the Genre, as those attributes are premade and should not be filled in. 
    //Names for fields with the prefix 'Movie' are such solely to avoid readability confusion later
    //when referencing Genres of Books, Games, and Movies
    public class Movie
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string MovieTitle { get; set; }
        [Required]
        public string MovieDescription { get; set; }
        [Required]
        public double MovieRunTime { get; set; }
        public string Director { get; set; }
        [Required]
        public MovieRating MovieRating { get; set; }
        [Required]
        public MovieGenre MovieGenre { get; set; }
        public int? ReleaseYear { get; set; }
    }

    public enum MovieGenre
    {
        Action=1,
        Adventure,
        Comedy,
        Crime,
        Documentary,
        Drama,
        Fantasy,
        Horror,
        Mystery,
        Romance,
        Satire,
        [Description("Science Fiction")]
        ScienceFiction,
        Thriller,
        Western
    }

    public enum MovieRating
    {
        G=1,
        PG,
        [Description("PG-13")]
        PG13,
        [Description("NC-17")]
        NC17,
        R,
        NR
    }
}
