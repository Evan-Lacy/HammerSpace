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
    public class BoardGameService
    {
        private readonly Guid _userId;
        //Assign the Users Guid to the variable to use throughout the service method
        public BoardGameService(Guid userId)
        {
            _userId = userId;
        }

        public IEnumerable<GameListItem> GetGames()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Games.Select(e => new GameListItem
                {
                    GameId = e.GameId,
                    GameTitle = e.GameTitle,
                    GameType = e.GameType,
                    GameDescription = e.GameDescription,
                    AveragePlaytime = e.AveragePlaytime,
                    PlayerCount = e.PlayerCount,
                    BGPublisher = (BoardGame)e.BGPublisher,
                    Category = e.Category,
                    BoardGameGenre = e.BoardGameGenre,
                    IsCardGame = e.IsCardGame,
                    IsDiceGame = e.IsDiceGame,
                });
                return query.ToArray();
            }
        }


        public bool CreateBoardGame(GameCreate model)
        {
            var entity = new BoardGame()
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

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Games.Add(entity);
                
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
