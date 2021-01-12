﻿using HammerSpace.Data;
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
            if(enumNum == 1)
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
                if (entity.GameType == GameType.BoardGame)
                {
                    return new GameDetails
                    {
                        GameId = entity.GameId,
                        GameType = entity.GameType,
                        GameTypeString = GetEnumDescription(Convert.ToInt32(entity.GameType)),
                        GameTitle = entity.GameTitle,
                        GameDescription = entity.GameDescription,
                        AveragePlaytime = entity.AveragePlaytime,
                        PlayerCount = entity.PlayerCount(),
                        BoardGameGenre = ((BoardGame)entity).BoardGameGenre,
                        Category = ((BoardGame)entity).Category,
                        BGPublisher = ((BoardGame)entity).BGPublisher,
                        IsCardGame = ((BoardGame)entity).IsCardGame,
                        IsDiceGame = ((BoardGame)entity).IsDiceGame
                    };
                }
                else 
                {
                    return new GameDetails
                    {
                        GameId = entity.GameId,
                        GameType = entity.GameType,
                        GameTitle = entity.GameTitle,
                        GameDescription = entity.GameDescription,
                        AveragePlaytime = entity.AveragePlaytime,
                        PlayerCount = entity.PlayerCount(),
                        LocalCoop = ((VideoGame)entity).LocalCoop,
                        VideoGameGenre = ((VideoGame)entity).VideoGameGenre,
                        ESRBRating = ((VideoGame)entity).ESRBRating,
                        VGPublisher = ((VideoGame)entity).VGPublisher,
                        Console = ((VideoGame)entity).Console
                    };
                }
            }
        }
    }
}
