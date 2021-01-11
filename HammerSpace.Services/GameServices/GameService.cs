using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HammerSpace.Services.GameServices
{
    public class GameService
    {
        private readonly Guid _userId;

        public  GameService(Guid userId)
        {
            _userId = userId;
        }
        //get all games
        // load up list of games
        //query context for video games = ctx.VideoGames
        //Set game type to video game
    }
}
