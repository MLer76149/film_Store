using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FilmStore.Models;

namespace FilmStore.Controllers
{
    public class FilmesController : Controller
    {
        private FilmEntities db = new FilmEntities();

        // GET: Filmes
        public async Task<ActionResult> Index()
        {
            var filme_db = db.Filme_db.Include(f => f.Genre).Include(f => f.Regisseur);
            return View(await filme_db.ToListAsync());
        }

        // GET: Filmes/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Filme filme = await db.Filme_db.FindAsync(id);
            if (filme == null)
            {
                return HttpNotFound();
            }
            return View(filme);
        }

        // GET: Filmes/Create
        public ActionResult Create()
        {
            ViewBag.GenreId = new SelectList(db.Genres_db, "GenreId", "Name");
            ViewBag.RegisseurId = new SelectList(db.Regisseure_db, "RegisseurId", "Name");
            return View();
        }

        // POST: Filmes/Create
        // Aktivieren Sie zum Schutz vor Angriffen durch Overposting die jeweiligen Eigenschaften, mit denen eine Bindung erfolgen soll. 
        // Weitere Informationen finden Sie unter https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "FilmId,GenreId,RegisseurId,Title,FilmArtUrl")] Filme filme)
        {
            if (ModelState.IsValid)
            {
                db.Filme_db.Add(filme);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.GenreId = new SelectList(db.Genres_db, "GenreId", "Name", filme.GenreId);
            ViewBag.RegisseurId = new SelectList(db.Regisseure_db, "RegisseurId", "Name", filme.RegisseurId);
            return View(filme);
        }

        // GET: Filmes/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Filme filme = await db.Filme_db.FindAsync(id);
            if (filme == null)
            {
                return HttpNotFound();
            }
            ViewBag.GenreId = new SelectList(db.Genres_db, "GenreId", "Name", filme.GenreId);
            ViewBag.RegisseurId = new SelectList(db.Regisseure_db, "RegisseurId", "Name", filme.RegisseurId);
            return View(filme);
        }

        // POST: Filmes/Edit/5
        // Aktivieren Sie zum Schutz vor Angriffen durch Overposting die jeweiligen Eigenschaften, mit denen eine Bindung erfolgen soll. 
        // Weitere Informationen finden Sie unter https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "FilmId,GenreId,RegisseurId,Title,FilmArtUrl")] Filme filme)
        {
            if (ModelState.IsValid)
            {
                db.Entry(filme).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.GenreId = new SelectList(db.Genres_db, "GenreId", "Name", filme.GenreId);
            ViewBag.RegisseurId = new SelectList(db.Regisseure_db, "RegisseurId", "Name", filme.RegisseurId);
            return View(filme);
        }

        // GET: Filmes/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Filme filme = await db.Filme_db.FindAsync(id);
            if (filme == null)
            {
                return HttpNotFound();
            }
            return View(filme);
        }

        // POST: Filmes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Filme filme = await db.Filme_db.FindAsync(id);
            db.Filme_db.Remove(filme);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
