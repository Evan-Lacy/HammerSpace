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
    public class GameService
    {
        private readonly Guid _userId;
        //Assign the Users Guid to the variable to use throughout the service method
        public GameService(Guid userId)
        {
            _userId = userId;
        }

        public IEnumerable<GameListItem> GetGames()
        {
            using (var ctx = new ApplicationDbContext())
            {
                //Using asEnumerable is garbage code
                var VGquery = ctx.Games.AsEnumerable().Where(model => model.GameType == GameType.BoardGame).Select(e => new GameListItem
                {
                    //General Game properties
                    GameId = e.GameId,
                    GameTitle = e.GameTitle,
                    GameType = e.GameType,
                    GameDescription = e.GameDescription,
                    AveragePlaytime = e.AveragePlaytime,
                    PlayerCount = e.PlayerCount(),

                    //Board Game specific properties
                    BGPublisher = ((BoardGame)e).BGPublisher,
                    Category = ((BoardGame)e).Category,
                    BoardGameGenre = ((BoardGame)e).BoardGameGenre,
                    IsCardGame = ((BoardGame)e).IsCardGame,
                    IsDiceGame = ((BoardGame)e).IsDiceGame,
                });

                var BGquery = ctx.Games.AsEnumerable().Where(model => model.GameType == GameType.VideoGame).Select(e => new GameListItem
                {
                    //General Game properties
                    GameId = e.GameId,
                    GameTitle = e.GameTitle,
                    GameType = e.GameType,
                    GameDescription = e.GameDescription,
                    AveragePlaytime = e.AveragePlaytime,
                    PlayerCount = e.PlayerCount(),

                    //VideoGame specific properties
                    VGPublisher = ((VideoGame)e).VGPublisher,
                    LocalCoop = ((VideoGame)e).LocalCoop,
                    Console = ((VideoGame)e).Console,
                    VideoGameGenre = ((VideoGame)e).VideoGameGenre,
                    ESRBRating = ((VideoGame)e).ESRBRating,
                });
                var query = VGquery.Concat(BGquery);
                return query.ToArray();
            }
        }

        public bool CreateGame(GameCreate model)
        {
            var entity = new Game();
            if (model.GameType == Data.Games.GameType.BoardGame)
            {
                entity = new BoardGame()
                {
                    //General Game properties
                    UserId = _userId,
                    GameTitle = model.GameTitle,
                    GameDescription = model.GameDescription,
                    AveragePlaytime = model.AveragePlaytime,
                    MinGamePlayers = model.MinGamePlayers,
                    MaxGamePlayers = model.MaxGamePlayers,
                    GameType = model.GameType,

                    //Board Game specific properties
                    BoardGameGenre = model.BoardGameGenre,
                    Category = model.Category,
                    BGPublisher = model.BGPublisher,
                    IsDiceGame = model.IsDiceGame,
                    IsCardGame = model.IsCardGame
                };
            }
            else
            {
                entity = new VideoGame()
                {
                    //General Game properties
                    UserId = _userId,
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
            }

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Games.Add(entity);

                return ctx.SaveChanges() == 1;
            }
        }

        public static string GetEnumDescription(int enumNum)
        {
            if (enumNum == 1)
            {
                return "Video Game";
            }
            else
            {
                return "Board Game";
            }
        }

        public GameDetails GetGameById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Games
                    .Single(e => e.GameId == id);

                var detail = new GameDetails();

                detail.GameId = entity.GameId;
                detail.GameType = entity.GameType;
                detail.GameTypeString = GetEnumDescription(Convert.ToInt32(entity.GameType));
                detail.GameTitle = entity.GameTitle;
                detail.GameDescription = entity.GameDescription;
                detail.AveragePlaytime = entity.AveragePlaytime;
                detail.MinGamePlayers = entity.MinGamePlayers;
                detail.MaxGamePlayers = entity.MaxGamePlayers;
                detail.PlayerCount = entity.PlayerCount();

                //If the object has the gametype of BoardGame, do these details
                if (entity.GameType == GameType.BoardGame)
                {

                    detail.BoardGameGenre = ((BoardGame)entity).BoardGameGenre;
                    detail.Category = ((BoardGame)entity).Category;
                    detail.BGPublisher = ((BoardGame)entity).BGPublisher;
                    detail.IsCardGame = ((BoardGame)entity).IsCardGame;
                    detail.IsDiceGame = ((BoardGame)entity).IsDiceGame;


                }
                else if (entity.GameType == GameType.VideoGame)
                {
                    detail.LocalCoop = ((VideoGame)entity).LocalCoop;
                    detail.VideoGameGenre = ((VideoGame)entity).VideoGameGenre;
                    detail.ESRBRating = ((VideoGame)entity).ESRBRating;
                    detail.VGPublisher = ((VideoGame)entity).VGPublisher;
                    detail.Console = ((VideoGame)entity).Console;
                }


                return detail;
            }

        }

        public bool UpdateGame(GameEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Games.Single(e => e.GameId == model.GameId);
                entity.GameId = model.GameId;
                entity.GameType = model.GameType;
                entity.GameTitle = model.GameTitle;
                entity.GameDescription = model.GameDescription;
                entity.AveragePlaytime = model.AveragePlaytime;
                entity.MinGamePlayers = model.MinGamePlayers;
                entity.MaxGamePlayers = model.MaxGamePlayers;

                if (model.GameType == GameType.BoardGame)
                {
                    ((BoardGame)entity).BoardGameGenre = model.BoardGameGenre;
                    ((BoardGame)entity).Category = model.Category;
                    ((BoardGame)entity).BGPublisher = model.BGPublisher;
                    ((BoardGame)entity).IsDiceGame = model.IsDiceGame;
                    ((BoardGame)entity).IsCardGame = model.IsCardGame;
                }
                else if (model.GameType == GameType.VideoGame)
                {
                    ((VideoGame)entity).VideoGameGenre = model.VideoGameGenre;
                    ((VideoGame)entity).LocalCoop = model.LocalCoop;
                    ((VideoGame)entity).VGPublisher = model.VGPublisher;
                    ((VideoGame)entity).Console = model.Console;
                    ((VideoGame)entity).ESRBRating = model.ESRBRating;
                }

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteGame(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                    .Games
                    .Single(e => e.GameId == id);

                ctx.Games.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
