using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication3.Interfaces;
using WebApplication3.Repositories;

namespace WebApplication3.Controllers
{
    public class BooksController : Controller
    {
        // GET: Books
        UnitOfWork unitOfWork;

        public BooksController()
        {
            unitOfWork = new UnitOfWork();
        }

        public ActionResult Index()
        {
            var books = unitOfWork.Books.GetAll();

            return View(books);
            //kk



        }

        [HttpGet]
        public ActionResult Create()
        {
                Model1 db = new Model1();
            
                SelectList books = new SelectList(db.Authors, "Id", "Id", db.Authors.Select(model => model.Id));
                ViewBag.AuthorId = books;
                SelectList books2 = new SelectList(db.Authors, "FirstName", "FirstName", db.Authors.Select(model => model.FirstName));
                ViewBag.AuthorName = books2;
                //SelectList books3 = new SelectList(db.Users, "Name", "Name", db.Users.Select(model => model.Name));
                //ViewBag.data = books3;


            return View();
        }

        [HttpPost]
        public ActionResult Create(Books books)
        {

              
                    unitOfWork.Books.Create(books);
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
            Books books;


            books = unitOfWork.Books.Get(id);
          
            return View(books);
        }

        [HttpPost]
        public ActionResult Edit(Books books)
        {
         
                
                var oldBook = unitOfWork.Books.Find(a => a.Id == books.Id).FirstOrDefault();
                oldBook.AuthorName = books.AuthorName;
                oldBook.Title = books.Title;
                oldBook.Pages = books.Pages;
                oldBook.Price = books.Price;

                unitOfWork.Save();
            
            return RedirectToActionPermanent("Index", "Books");
        }

        public ActionResult Delete(int id)
        {

                unitOfWork.Books.Delete(id);
                unitOfWork.Save();
            
            return RedirectToAction("Index", "Books");
            
        }

        protected override void Dispose(bool disposing)
        {
            unitOfWork.Dispose();
            base.Dispose(disposing);
        }


    }
}