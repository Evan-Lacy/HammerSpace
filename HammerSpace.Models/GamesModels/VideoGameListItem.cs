using HammerSpace.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HammerSpace.Models.GamesModels
{
    public class VideoGameListItem
    {
        public bool LocalCoop { get; set; }
        public Genre Genre { get; set; }
        public ESRBRating ESRBRating { get; set; }
        public string Publisher { get; set; }
        public string Console { get; set; }

    }
}
