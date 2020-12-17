using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HammerSpace.Data
{
    public class Game
    {
        private static string playerAmt;

        [Key]
        public int GameId { get; set; }

        [Required]
        [Display(Name = "Title")]
        public string GameTitle { get; set; }
        [Required]
        [Display(Name = "Game Description")]
        public string GameDescription { get; set; }
        [Required]
        [Display(Name = "Average Playtime")]
        public double AveragePlaytime { get; set; }

        [Required]
        public int MinGamePlayers { get; set; }
        public int? MaxGamePlayers { get; set; }

        [Display(Name = "Number of Players")]
        public string PlayerCount
        {
            get
            {
                if (MaxGamePlayers == null)
                {
                    playerAmt = MinGamePlayers.ToString() + "player";
                }
                else
                {
                    playerAmt = MinGamePlayers.ToString() + " to " + MaxGamePlayers.ToString() + "players";
                }
                return playerAmt;
            }
        }
    }

}
