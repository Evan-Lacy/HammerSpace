using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HammerSpace.Data.Games
{
    public class BoardGame : Game
    {
        public Genre Genre { get; set; }
        public string Category { get; set; }
        public string Publisher { get; set; }
        public bool IsDiceGame { get; set; }
        public bool IsCardGame { get; set; }
    }

}
