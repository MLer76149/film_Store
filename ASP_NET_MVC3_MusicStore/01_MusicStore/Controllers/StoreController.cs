using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _01_MusicStore.Models;

namespace _01_MusicStore.Controllers
{
    public class StoreController : Controller
    {
        MusicStoreEntities storeDB = new MusicStoreEntities();
        //
        // GET: /Store/
        public ActionResult Index()
        {
            var genres = storeDB.Genres.ToList();
            return View(genres);
        }
        //
        // GET: /Store/Browse?genre=Disco
        public ActionResult Browse(string genre)
        {
            // Retrieve Genre and its Associated Albums from database
            var genreModel = storeDB.Genres.Include("Albums")
                .Single(g => g.Name == genre);

            return View(genreModel);
        }
        //
        // GET: /Store/Details/5
        public ActionResult Details(int id)
        {
            var album = storeDB.Albums.Find(id);
            ViewBag.artist = storeDB.Artists;
            ViewBag.genre = storeDB.Genres;

            return View(album);
        }
    }
}