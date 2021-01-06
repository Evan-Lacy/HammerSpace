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
        public bool CreateBoardGame(BoardGameCreate model)
        {
            var entity = new BoardGame()
            {
                //General Game Properties
                //General Game properties
                GameTitle = model.GameTitle,
                GameDescription = model.GameDescription,
                AveragePlaytime = model.AveragePlaytime,
                MinGamePlayers = model.MinGamePlayers,
                MaxGamePlayers = model.MaxGamePlayers,
                GameType = model.GameType,

                //Board Game specific properties
                BoardGameaGenre = model.BoardGameGenre,
                Category = model.Category,
                Publisher = model.Publisher,
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
