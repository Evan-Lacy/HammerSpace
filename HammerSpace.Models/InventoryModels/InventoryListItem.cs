using HammerSpace.Data;
using HammerSpace.Data.Games;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HammerSpace.Models.InventoryModels
{
    public class InventoryListItem
    {
        [Key]
        public int InventoryId { get; set; }
        public Guid OwnerId { get; set; }
        public virtual IEnumerable<Game> OwnedGames { get; set; }
        public virtual IEnumerable<Movie> OwnedMovies { get; set; }

    }
}
