using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using FilmStore.Models;

namespace FilmStore.Controllers
{
    public class FilmBaseController : Controller
    {
        FilmEntities fi = new FilmEntities();

        //
        // GET: /Film/
        public ActionResult Index()
        {
            List<Genres> genre  = fi.Genres_db.ToList();
            List<Regisseure> regisseure = fi.Regisseure_db.ToList();
            ViewBag.menge = regisseure.Count();
            ViewBag.regisseures = regisseure;
            return View(genre);
        }
        //
        // GET: /Film/Browse
        public ActionResult Browse(string genre)
        {
            // Retrieve Genre and its Associated Films from database
            var genreModel = fi.Genres_db.Include("Films")
                .Single(g => g.Name == genre);
           
            return View(genreModel);
        }

        //
        // GET: /Film/Browse
        public ActionResult Browse2(string regisseures)
        {
            // Retrieve Directors and its Associated Films from database
            var regisseureModel = fi.Regisseure_db.Include("Films")
                .Single(g => g.Name == regisseures);

            return View(regisseureModel);
        }

        //
        // GET: /Film/Details
        public ActionResult Details(int id)
        {
            var films = fi.Filme_db.Find(id);
            ViewBag.genre = fi.Genres_db;
            ViewBag.regisseure = fi.Regisseure_db;
            return View(films);
        }

        public ActionResult LogIn()
        {
            return View();
        }

        public ActionResult Finish()
        {
            return View();
        }
    }
}