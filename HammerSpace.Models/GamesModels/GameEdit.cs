﻿using HammerSpace.Data.Games;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HammerSpace.Models.GamesModels
{
    public class GameEdit
    {
        [Key]
        public int GameId { get; set; }
        [Display(Name ="Game Title")]
        public string GameTitle { get; set; }
        [Display(Name = "Game Description")]
        public string GameDescription { get; set; }
        [Display(Name = "Avg Playtime Length (in hours)")]
        public double AveragePlaytime { get; set; }
        [Display(Name = "Min. # of Players")]
        public int MinGamePlayers { get; set; }
        [Display(Name = "Max # of Players")]
        public int? MaxGamePlayers { get; set; }

        ////Enum type to check later with LINQ methods to then display appropriate information within GameService
        public GameType GameType { get; set; }


        //Board Game specific properties
        [Display(Name = "Board Game Genre")]
        public Genre BoardGameGenre { get; set; }
        public string Category { get; set; }
        public string BGPublisher { get; set; }
        public bool IsDiceGame { get; set; }
        public bool IsCardGame { get; set; }


        //Video Game specific properties
        public bool LocalCoop { get; set; }
        [Display(Name = "Video Game Genre")]
        public Genre VideoGameGenre { get; set; }
        public ESRBRating ESRBRating { get; set; }
        public string VGPublisher { get; set; }
        public string Console { get; set; }
    }
}
