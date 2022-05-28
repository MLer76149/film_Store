using FilmStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace FilmStore.Controllers
{
    public class HomeController : Controller
    {
        FilmEntities fi = new FilmEntities();
        // GET: Home
        public ActionResult Index()
        {
            List<Filme> g = fi.Filme_db.ToList();
            return View(g);
        }
    }
}