using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HammerSpace.Data.Games
{
    public class VideoGame : Game
    {
        public bool LocalCoop  { get; set; }
        public Genre VideoGameGenre { get; set; }
        public ESRBRating ESRBRating { get; set; }
        public string Publisher { get; set; }
        public string Console { get; set; }
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
