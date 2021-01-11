﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HammerSpace.Data.Games
{
    public class Game
    {
        private static string playerAmt;
        public Guid UserId { get; set; }
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

        public GameType GameType { get; set; }

        public string PlayerCount()
        {
            if (MaxGamePlayers == null)
            {
                playerAmt = MinGamePlayers.ToString() + " player";
            }
            else
            {
                playerAmt = MinGamePlayers.ToString() + " to " + MaxGamePlayers.ToString() + " players";
            }
            return playerAmt;
        }

    }


    public enum GameType
    {
        [Display(Name = "Video Game")]
        VideoGame = 1,
        [Display(Name = "Board Game")]
        BoardGame
    }

    public enum Genre
    {
        Action = 1,
        [Display(Name = "Action-adventure")]
        ActionAdventure,
        Adventure,
        Horror,
        Idle,
        Logic,
        MMO,
        Party,
        Puzzle,
        [Display(Name = "Role-playing")]
        RolePlaying,
        Sandbox,
        Simulation,
        Strategy,
        Sports
    }

}