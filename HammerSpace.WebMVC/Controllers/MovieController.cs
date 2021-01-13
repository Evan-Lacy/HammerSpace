using HammerSpace.Models.MovieModels;
using HammerSpace.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HammerSpace.WebMVC.Controllers
{
    [Authorize]
    public class MovieController : Controller
    {
        // GET: Movie
        public ActionResult Index()
        {
            //var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new MovieService();
            var model = service.GetMovies();

            return View(model);
            //return View();
        }

        //GET
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MovieCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            //var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new MovieService();
            if (service.CreateMovie(model))
            {
                TempData["SaveResult"] = "Your Movie was Created";
                return RedirectToAction("Index");
            }

            return View(model);
        }

        public ActionResult Details(int id)
        {
            var service = new MovieService();
            var model = service.GetMovieById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = new MovieService();
            var deet = service.GetMovieById(id);

            var model =
                new MovieEdit
                {
                    MovieTitle = deet.MovieTitle,
                    MovieDescription = deet.MovieDescription,
                    MovieRunTime = deet.MovieRunTime,
                    Director = deet.Director,
                    MovieRating = deet.MovieRating,
                    MovieGenre = deet.MovieGenre,
                    ReleaseYear = deet.ReleaseYear,
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, MovieEdit model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (model.Id != id)
            {
                ModelState.AddModelError("", "You have a mismatched Id");
                return View(model);
            }

            var service = new MovieService();

            if (service.UpdateMovie(model))
            {
                TempData["SaveResult"] = "Your Movie was Updated";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your movie could not be updated.");
            return View(model);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var service = new MovieService();
            var model = service.GetMovieById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteMovie(int id)
        {
            var service = new MovieService();

            service.DeleteMovie(id);

            TempData["SaveResult"] = "Your movie was yote out the database.";

            return RedirectToAction("Index");
        }
    }
}