using HammerSpace.Data;
using HammerSpace.Data.Games;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HammerSpace.Models.GamesModels
{
    [Serializable]
    public class VideoGameCreate : GameCreate
    {
        public bool LocalCoop { get; set; }
        public Genre VideoGameGenre { get; set; }
        public ESRBRating ESRBRating { get; set; }
        public string Publisher { get; set; }
        public string Console { get; set; }

        //Constructor that sets the game type to VideoGame
        public VideoGameCreate()
        {
            GameType = GameType.VideoGame;
        }
    }
}
