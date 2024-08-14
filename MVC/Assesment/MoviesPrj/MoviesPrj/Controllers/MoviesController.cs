using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MoviesPrj.Models;
using MoviesPrj.Repository;

namespace MoviesPrj.Controllers
{
    public class MoviesController : Controller
    {
        private IMovieRepository<Movies> _movieRepo = null;

        public MoviesController()
        {
            _movieRepo = new MovieRepository<Movies>();
        }

        // : Movies
        public ActionResult Index()
        {
            var movies = _movieRepo.GetAll();
            return View(movies);
        }

        //2. Create a movie
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Movies movie)
        {
            if (ModelState.IsValid)
            {
                _movieRepo.Insert(movie);
                _movieRepo.Save();
                return RedirectToAction("Index");
            }
            return View(movie);
        }

        //3. Edit a movie
        public ActionResult Edit(int id)
        {
            var movie = _movieRepo.GetById(id);
            return View(movie);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Movies movie)
        {
            if (ModelState.IsValid)
            {
                _movieRepo.Update(movie);
                _movieRepo.Save();
                return RedirectToAction("Index");
            }
            return View(movie);
        }

        //4. Details of a movie
        public ActionResult Details(int id)
        {
            var movie = _movieRepo.GetById(id);
            return View(movie);
        }

        //5. Delete a movie
        public ActionResult Delete(int id)
        {
            var movie = _movieRepo.GetById(id);
            return View(movie);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var movie = _movieRepo.GetById(id);
            _movieRepo.Delete(id);
            _movieRepo.Save();
            return RedirectToAction("Index");
        }
    }
}

