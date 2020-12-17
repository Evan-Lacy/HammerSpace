using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HammerSpace.Data
{
    public class VideoGame : Game
    {
        public bool LocalCoop  { get; set; }
        public Genre Genre { get; set; }
        public ESRBRating ESRBRating { get; set; }
        public string Publisher { get; set; }
    }

    //public enum Console
    //{                       //An enum for the Console type of the VideoGame to allow the User to choose
    //    [Description("Xbox One")]
    //    XboxOne = 1,        //what systems the game is available to play on. Will allow the user to select
    //    PC,                 //multiple with a dropdown select box - mdb multi selection
    //    [Description("Playstation 4")]
    //    PS4,
    //    [Description("Playstation 5")]
    //    PS5,
    //    [Description("Xbox Series X")]
    //    XboxSeriesX,
    //    [Description("Nintendo Switch")]
    //    Switch,
    //}

    public enum Genre
    {
        Action=1,
        [Description("Action-adventure")]
        ActionAdventure,
        Adventure,
        Horror,
        Idle,
        Logic,
        MMO,
        Party,
        Puzzle,
        [Description("Role-playing")]
        RolePlaying,
        Sandbox,
        Simulation,
        Strategy,
        Sports
    }

    public enum ESRBRating
    {
        [Description("E for Everyone")]
        E =1,
        [Description("Everyone 10+")]
        E10,
        [Description("T for Teen")]
        T,
        [Description("Mature 17+")]
        M,
        [Description("Adults Only 18+")]
        AO,
        [Description("Rating Pending")]
        RP
    }
}
