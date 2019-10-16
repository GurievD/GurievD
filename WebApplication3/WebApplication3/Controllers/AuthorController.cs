using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication3.Repositories;

namespace WebApplication3.Controllers
{
    public class AuthorController : Controller
    {
        UnitOfWork unitOfWork;

        public AuthorController()
        {
            unitOfWork = new UnitOfWork();
        }
        // GET: Author
        public ActionResult Index()
        {

            var authors = unitOfWork.Authors.GetAll();


            return View(authors);
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Authors author)
        {
            unitOfWork.Authors.Create(author);
            //try
            //{

            unitOfWork.Save();

            //}
            //catch (DbEntityValidationException ex)
            //{
            //    foreach (DbEntityValidationResult validationError in ex.EntityValidationErrors)
            //    {
            //        Response.Write("Object: " + validationError.Entry.Entity.ToString());
            //        Response.Write("");
            //        foreach (DbValidationError err in validationError.ValidationErrors)
            //        {
            //            Response.Write(err.ErrorMessage + "");
            //        }
            //    }
            //}

            return RedirectToAction("Index");
        }

        public ActionResult Edit(int? id)
        {
            Authors authors;


            authors = unitOfWork.Authors.Get(id);

            return View(authors);
        }

        [HttpPost]
        public ActionResult Edit(Authors author)
        {
            var oldAuthor = unitOfWork.Authors.Find(a => a.Id == author.Id).FirstOrDefault();
            oldAuthor.FirstName = author.FirstName;
            oldAuthor.LastName = author.LastName;


            unitOfWork.Save();

            return RedirectToActionPermanent("Index", "Author");
        }

        public ActionResult Delete(int id)
        {
            unitOfWork.Authors.Delete(id);
            unitOfWork.Save();

            return RedirectToAction("Index", "Author");
        }

        protected override void Dispose(bool disposing)
        {
            unitOfWork.Dispose();
            base.Dispose(disposing);
        }
    }
}