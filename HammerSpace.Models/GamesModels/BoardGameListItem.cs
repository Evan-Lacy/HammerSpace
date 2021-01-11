using HammerSpace.Data.Games;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HammerSpace.Models.GamesModels
{
    public class BoardGameListItem
    {
        public Genre BoardGameGenre { get; set; }
        public string Category { get; set; }
        public string BGPublisher { get; set; }
        public bool IsDiceGame { get; set; }
        public bool IsCardGame { get; set; }
    }
}
