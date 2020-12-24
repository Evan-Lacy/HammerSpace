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
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new GameService(userId);
            return service;
        }


        //Create a Game via View and return it to the database
        //GET
        public ActionResult Create()
        {
            return View();
        }

        //Create a View for the VideoGame and return it to the database
        public ActionResult VideoGameCreate()
        {
            return View();
        }

        public ActionResult BoardGameCreate()
        {
            return View();
        }
    }
}