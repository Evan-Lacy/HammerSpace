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
        private BoardGameService CreateBGService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var BGService = new BoardGameService(userId);
            return BGService;
        }

        // GET: Game
        public ActionResult Index()
        {
            var model = new GameListItem[0];
            return View(model);
            //var service = CreateBGService();
            //var model = service.GetGames();
            //return View(model);
        }

        //Create a Game via View and return it to the database
        //GET
        //public ActionResult Create()
        //{
        //    return View(); 
        //}

        public ActionResult Create()
        {
            var BGDefault = new GameCreate();

            return View(BGDefault);
        }

        //Create a Partial View for the VideoGame and return it to the database upon creation
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Create(GameCreate model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var service = CreateBGService();
            if (service.CreateBoardGame(model))
            {
                return RedirectToAction("Index");
            }
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