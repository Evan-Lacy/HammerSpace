using HammerSpace.Data.Games;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HammerSpace.Models.GamesModels
{
    public class GameCreate
    {
        [Required]
        public string GameTitle { get; set; }
        [Required]
        public string GameDescription { get; set; }
        [Required]
        public double AveragePlaytime { get; set; }
        [Required]
        public int MinGamePlayers { get; set; }
        public int? MaxGamePlayers { get; set; }

        //Bool property here to have a check later in the view to generate the necessary field for a video game or board game creation screen
        public GameType GameType { get; set; }

    }
}
