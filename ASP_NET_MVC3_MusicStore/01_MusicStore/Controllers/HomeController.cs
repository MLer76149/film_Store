using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _01_MusicStore.Controllers
{
    public class HomeController : Controller
    {
        // GET: /Home/
        public ActionResult Index()
        {
            List<_01_MusicStore.Models.MusicStoreEntities> albums = new List<Models.MusicStoreEntities>().ToList();
            return View();
        }
    }
}