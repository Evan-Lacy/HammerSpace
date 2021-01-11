using HammerSpace.Data.Games;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HammerSpace.Models.GamesModels
{
    [Serializable]
    public class GameListItem
    {
        [Key]
        public int GameId { get; set; }
        public string GameTitle { get; set; }
        [Display(Name = "Game Description")]
        public string GameDescription { get; set; }
        [Display(Name = "Average Playtime Length")]
        public double AveragePlaytime { get; set; }
        [Display(Name ="Player Count")]
        public string PlayerCount { get; set; }

        //Enum type to check later with LINQ methods to then display appropriate information within GameService
        public GameType GameType { get; set; }


        //Board Game specific properties
        public Genre BoardGameGenre { get; set; }
        public string Category { get; set; }
        public string BGPublisher { get; set; }
        public bool IsDiceGame { get; set; }
        public bool IsCardGame { get; set; }


        //Video Game specific properties
        public bool LocalCoop { get; set; }
        public Genre VideoGameGenre { get; set; }
        public ESRBRating ESRBRating { get; set; }
        public string VGPublisher { get; set; }
        public string Console { get; set; }
    }
}
