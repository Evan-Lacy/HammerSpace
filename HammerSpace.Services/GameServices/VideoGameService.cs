using HammerSpace.Data;
using HammerSpace.Data.Games;
using HammerSpace.Models.GamesModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HammerSpace.Services.GameServices
{
    public class VideoGameService
    {
        private readonly Guid _userId;
        //Assign the Users Guid to the variable to use throughout the service method
        public VideoGameService(Guid userId)
        {
            _userId = userId;
        }

        public IEnumerable<GameListItem> GetGames()
        {
            using (var ctx = new ApplicationDbContext())
            {
                //Using asEnumerable is garbage code
                var query = ctx.Games.AsEnumerable().Select(e => new GameListItem
                {
                    //General Game properties
                    GameId = e.GameId,
                    GameTitle = e.GameTitle,
                    GameType = e.GameType,
                    GameDescription = e.GameDescription,
                    AveragePlaytime = e.AveragePlaytime,
                    PlayerCount = e.PlayerCount(),

                    //Video Game specific properties
                    LocalCoop = ((VideoGame)e).LocalCoop,
                    VideoGameGenre = ((VideoGame)e).VideoGameGenre,
                    ESRBRating = ((VideoGame)e).ESRBRating,
                    VGPublisher = ((VideoGame)e).VGPublisher,
                    Console = ((VideoGame)e).Console,
                });
                return query.ToArray();
            }
        }

        public bool CreateVideoGame(GameCreate model)
        {
            var entity = new VideoGame()
            {
                //General Game properties
                GameTitle = model.GameTitle,
                GameDescription = model.GameDescription,
                AveragePlaytime = model.AveragePlaytime,
                MinGamePlayers = model.MinGamePlayers,
                MaxGamePlayers = model.MaxGamePlayers,
                GameType = model.GameType,

                //Video Game specific properties
                LocalCoop = model.LocalCoop,
                VideoGameGenre = model.VideoGameGenre,
                ESRBRating = model.ESRBRating,
                VGPublisher = model.VGPublisher,
                Console = model.Console
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Games.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
