using HammerSpace.Data;
using HammerSpace.Data.Games;
using HammerSpace.Models.GamesModels;
using HammerSpace.Models.InventoryModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HammerSpace.Services.InventoryService
{
    public class InventoryService
    {
        private readonly Guid _userID;
        public InventoryService(Guid userId)
        {
            _userID = userId;
        }

        //public IEnumerable<InventoryListItem> GetInventory()
        //{
        //    using (var ctx = new ApplicationDbContext())
        //    {
        //        var query =
        //            ctx
        //            .Inventories
        //            .Where(model => model.OwnerId == _userID)
        //            .Select(e => new InventoryListItem
        //            //);

        //            //var userGames = new List<GameListItem>();
        //            //foreach(var game in userGames)
        //            {
        //                InventoryId = e.InventoryId,
        //                OwnerId = e.OwnerId,
        //                OwnedGames = (IEnumerable<Game>)e.OwnedGames
        //                .Select(r => new GameListItem
        //                {
        //                    GameId = r.Game.GameId,
        //                    GameTitle = r.Game.GameTitle,
        //                    GameDescription = r.Game.GameDescription,
        //                    AveragePlaytime = r.Game.AveragePlaytime,
        //                    PlayerCount = r.Game.PlayerCount(),
        //                    GameType = r.Game.GameType,
        //                    BoardGameGenre = r.Game.Genre.BoardGameGenre,
        //                })
        //            });

        //        return query.ToArray();
        //    }
        //}
    }
}
