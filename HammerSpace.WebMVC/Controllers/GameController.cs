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
        // GET: Game
        public ActionResult Index()
        {
            var model = new GameListItem[0];
            return View(model);
        }



        public GameService CreateGameService()
        {
            //Create Service object to be used throughout the controller - DRY principle
            var service = new GameService();
            return service;
        }


        //Create a Game via View and return it to the database
        //GET
        public ActionResult Create()
        {
            var BGDefault = new BoardGameCreate();
            
            return View(BGDefault);
        }

        //Create a Partial View for the VideoGame and return it to the database upon creation
        public ActionResult VideoGameCreate(VideoGameCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var service = new VideoGameService();

            if (service.CreateVideoGame(model))
            {
                return RedirectToAction("Index");
            }

            return View(model);
        }

        //Create a Partial view for the Board game and return it to the database upon creation
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult BoardGameCreate(BoardGameCreate model)
        {

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var service = new BoardGameService();

            if (service.CreateBoardGame(model))
            {
                return RedirectToAction("Index");
            }

            return View(model);
        }
    }
}