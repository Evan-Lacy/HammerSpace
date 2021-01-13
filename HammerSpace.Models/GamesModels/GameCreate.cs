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
    public class GameCreate
    {
        [Key]
        public int GameId { get; set; }
        public string GameTitle { get; set; }
        public string GameDescription { get; set; }
        public double AveragePlaytime { get; set; }
        public int MinGamePlayers { get; set; }
        public int? MaxGamePlayers { get; set; }

        //Enum property here to have a check later in the view to generate the necessary field for a video game or board game creation screen
        public GameType GameType { get; set; }


        //BoardGame section
        public Genre BoardGameGenre { get; set; }
        public string Category { get; set; }
        public string BGPublisher { get; set; }
        public bool IsDiceGame { get; set; } 
        public bool IsCardGame { get; set; }

        //Constructor that sets the game type to BoardGame
        //public GameCreate()
        //{
        //    GameType = GameType.BoardGame;
        //}

        //VideoGame Section
        public bool LocalCoop { get; set; }
        public Genre VideoGameGenre { get; set; }
        public ESRBRating ESRBRating { get; set; }
        public string VGPublisher { get; set; }
        public string Console { get; set; }

        //Constructor that sets the game type to VideoGame
        //public GameCreate()
        //{
        //    GameType = GameType.VideoGame;
        //}
    }
}
