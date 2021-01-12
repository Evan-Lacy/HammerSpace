using HammerSpace.Models.GamesModels;
using HammerSpace.Services.GameServices;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HammerSpace.WebMVC.Controllers
{
    [Authorize]
    public class GameController : Controller
    {
        private GameService CreateGameService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new GameService(userId);
            return service;
        }

        // GET: Game
        public ActionResult Index()
        {
            //var model = new GameListItem[0];
            //return View(model);
            var service = CreateGameService();
            var model = service.GetGames();
            return View(model);
        }

        public ActionResult Create(int id)
        {
            if (id == 1)
            {
                var gameObj = new GameCreate
                {
                    GameType = Data.Games.GameType.BoardGame
                };
                return View(gameObj);
            }
            else if (id == 2)
            {
                var gameObj = new GameCreate
                {
                    GameType = Data.Games.GameType.VideoGame
                };
                return View(gameObj);
            }
            else
            {
                return View();
            }
        }

        //Create a Partial View for the VideoGame and return it to the database upon creation
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Create(GameCreate model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var service = CreateGameService();
            if (service.CreateGame(model))
            {
                return RedirectToAction("Index");
            }
            return View(model);
        }

        //Get all Details for a Game
        public ActionResult Details(int id)
        {
            var service = CreateGameService();
            var model = service.GetGameById(id);

            return View(model);
        }

        //Create a Partial view for the Board game and return it to the database upon creation
        //[HttpPost]
        ////[ValidateAntiForgeryToken]
        //public ActionResult Create(GameCreate model)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return View(model);
        //    }

        //    if (model.GameType == Data.Games.GameType.VideoGame)
        //    {
        //        var service = new VideoGameService();

        //        if (service.CreateVideoGame((VideoGameCreate)model))
        //        {
        //            return RedirectToAction("Index");
        //        }
        //    }
        //    else if (model.GameType == Data.Games.GameType.BoardGame)
        //    {
        //        var service = CreateBGService();
        //        //var cretin = new BoardGameCreate()
        //        //{
        //        //    //General Game properties
        //        //    GameTitle = model.GameTitle,
        //        //    GameDescription = model.GameDescription,
        //        //    AveragePlaytime = model.AveragePlaytime,
        //        //    MinGamePlayers = model.MinGamePlayers,
        //        //    MaxGamePlayers = model.MaxGamePlayers,
        //        //    GameType = model.GameType,

        //        //    //Board Game specific properties
        //        //    BoardGameGenre = model.BoardGameGenre,
        //        //    Category = model.Category,
        //        //    Publisher = model.Publisher,
        //        //    IsDiceGame = model.IsDiceGame,
        //        //    IsCardGame = model.IsCardGame
        //        //};

        //        if (service.CreateBoardGame((BoardGameCreate)model))
        //        {
        //            return RedirectToAction("Index");
        //        }
        //    }

        //    return View(model);
        //}


    }
}