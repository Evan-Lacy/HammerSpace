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
        public bool CreateVideoGame(VideoGameCreate model)
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
