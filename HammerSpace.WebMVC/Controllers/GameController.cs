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

        //Edit the Game details, hopefully only getting the specific game requested
        public ActionResult Edit(int id)
        {
            var service = CreateGameService();
            var deet = service.GetGameById(id);

            var model =
                new GameEdit
                {
                    GameId = deet.GameId,
                    GameType = deet.GameType,
                    GameTitle = deet.GameTitle,
                    GameDescription = deet.GameDescription,
                    AveragePlaytime = deet.AveragePlaytime,
                    MinGamePlayers = deet.MinGamePlayers,
                    MaxGamePlayers = deet.MaxGamePlayers,

                    //Try one = match everything?
                    //Matching Nulls should match in the background as the data table is filled with 
                    //them to store the blank items from the other kind of Game

                    //Board Game
                    BoardGameGenre = deet.BoardGameGenre,
                    Category = deet.Category,
                    BGPublisher = deet.BGPublisher,
                    IsCardGame = deet.IsCardGame,
                    IsDiceGame = deet.IsDiceGame,

                    //Video Game
                    VideoGameGenre = deet.VideoGameGenre,
                    ESRBRating = deet.ESRBRating,
                    LocalCoop = deet.LocalCoop,
                    VGPublisher = deet.VGPublisher,
                    Console = deet.Console
                };
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(int id, GameEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if(model.GameId != id)
            {
                ModelState.AddModelError("", "There is a mismatch with the Game Id");
                return View(model);
            }

            var service = CreateGameService();

            if (service.UpdateGame(model))
            {
                TempData["SaveResult"] = "Your Game was updated! Congratz!";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your game could not be updated. \n You have lost The Game");
            return View(model);
        }

        //[ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var service = CreateGameService();

            var model = service.GetGameById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteMovie(int id)
        {
            var service = CreateGameService();

            service.DeleteGame(id);

            TempData["SaveResult"] = "Your game was lost to the sands of time.";
            return RedirectToAction("Index");
        }
    }
}