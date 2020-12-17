using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HammerSpace.Data
{
    public class BoardGame : Game
    {
        public Genre Genre { get; set; }
        public string Category { get; set; }
        public string Publisher { get; set; }
    }

}
