using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication3.Repositories;

namespace WebApplication3.Controllers
{
    public class GenreController : Controller
    {
        UnitOfWork unitOfWork;

        public GenreController()
        {
            unitOfWork = new UnitOfWork();
        }
        // GET: Genre
        public ActionResult Index()
        {
            var genres = unitOfWork.Genres.GetAll();

            return View(genres);
        }

        public ActionResult Create()
        {
            Model1 db = new Model1();

            SelectList genres = new SelectList(db.Genres, "Id", "Name");
            ViewBag.GenresList = genres;

            return View();
        }

        [HttpPost]
        public ActionResult Create(Genres genre)
        {
            unitOfWork.Genres.Create(genre);
            unitOfWork.Save();
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int? id)
        {
            Genres genres;


            genres = unitOfWork.Genres.Get(id);

            return View(genres);
        }

        [HttpPost]
        public ActionResult Edit(Genres genres)
        {

            var oldGenre = unitOfWork.Genres.Find(a => a.Id == genres.Id).FirstOrDefault();
            oldGenre.Name = genres.Name;

            unitOfWork.Save();

            return RedirectToActionPermanent("Index", "Genre");

        }

        public ActionResult Delete(int id)
        {
            unitOfWork.Genres.Delete(id);
            unitOfWork.Save();

            return RedirectToAction("Index", "Genre");
        }

        protected override void Dispose(bool disposing)
        {
            unitOfWork.Dispose();
            base.Dispose(disposing);
        }
    }
}