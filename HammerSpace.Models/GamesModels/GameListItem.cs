using HammerSpace.Data.Games;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HammerSpace.Models.GamesModels
{
    public class GameListItem
    {
        public int GameId { get; set; }
        public string Title { get; set; }
        [Display(Name = "Game Description")]
        public string GameDescription { get; set; }
        [Display(Name = "Average Playtime Length")]
        public double AveragePlaytime { get; set; }
        [Display(Name ="Player Count")]
        public string PlayerCount { get; set; }

        //Enum type to check later with LINQ methods to then display appropriate information within GameService
        public GameType GameType { get; set; }
    }
}
