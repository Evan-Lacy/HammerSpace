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
    //DON'T TOUCH

    public class GameService
    {
        //private readonly Guid _userId;
        //Assign the Users Guid to the variable to use throughout the service method
        //public GameService(Guid userId)
        //{
        //    _userId = userId;
        //}
        //get all games
        // load up list of games
        //query context for video games = ctx.VideoGames
        //Set game type to video game

        //public bool CreateGameService(GameCreate model)
        //{
        //    var entity = new Game()
        //    {
        //        GameTitle = model.GameTitle,
        //        GameDescription = model.GameDescription,
        //        AveragePlaytime = model.AveragePlaytime,
        //        MinGamePlayers = model.MinGamePlayers,
        //        MaxGamePlayers = model.MaxGamePlayers,
        //        GameType = model.GameType,
        //    };

        //    //Make a comparison check on property value and then go to appropriate service creator
        //    if (entity.GameType == GameType.VideoGame)
        //    {
        //        //If gametype is videogame, go to videogameservice creation

        //    }

        //    using (var ctx = new ApplicationDbContext())
        //    {
        //        ctx.Games.Add(entity);
        //        return ctx.SaveChanges() == 1;
        //    }
        //}


    }
}