using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HammerSpace.Data
{
    public class Inventory
    {
        [Key]
        public int InventoryId { get; set; }

        //If GUid matches logged in Guid, display that user's inventory
        [Required]
        public Guid OwnerId { get; set; }

        //CRD methods for the users inventory
        //Create - Add Game or Movie to Inventory
        //Read - See all Owned Games and Movies
        //Delete - Remove items from the Owned lists

        public virtual List<OwnedMovies> OwnedMovies { get; set; } = new List<OwnedMovies>();
        public virtual List<OwnedGames> OwnedGames { get; set; } = new List<OwnedGames>();
    }
}
