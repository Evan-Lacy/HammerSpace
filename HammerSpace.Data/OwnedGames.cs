using HammerSpace.Data.Games;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HammerSpace.Data
{
    public class OwnedGames
    {

        //join table to connect all the owned games to a User's personal Inventory within HammerSpace
        public int OwnedGameId { get; set; }

        [ForeignKey(nameof(Game))]
        public int GameId { get; set; }
        public virtual Game Game { get; set; }

        [ForeignKey(nameof(Inventory))]
        public int InventoryId { get; set; }
        public virtual Inventory Inventory { get; set; }
    }
}
