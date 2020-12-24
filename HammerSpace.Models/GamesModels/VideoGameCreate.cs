using HammerSpace.Data;
using HammerSpace.Data.Games;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HammerSpace.Models.GamesModels
{
    public class VideoGameCreate
    {
        public bool LocalCoop { get; set; }
        public Genre Genre { get; set; }
        public ESRBRating ESRBRating { get; set; }
        public string Publisher { get; set; }
        public string Console { get; set; }
    }
}
