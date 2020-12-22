using HammerSpace.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HammerSpace.Models.GamesModels
{
    public class BoardGameListItem
    {
        public Genre Genre { get; set; }
        public string Category { get; set; }
        public string Publisher { get; set; }
    }
}
