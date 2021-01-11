using HammerSpace.Data.Games;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HammerSpace.Models.GamesModels
{
    [Serializable]
    public class BoardGameCreate : GameCreate
    {
        public Genre BoardGameGenre { get; set; }
        public string Category { get; set; }
        public string Publisher { get; set; }
        public bool IsDiceGame { get; set; }
        public bool IsCardGame { get; set; }

        //Constructor that sets the game type to VideoGame
        public BoardGameCreate()
        {
            GameType = GameType.BoardGame;
        }
    }
}
