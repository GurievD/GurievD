﻿using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication3.Controllers
{
    public class BooksController : Controller
    {
        // GET: Books

        public ActionResult Index()
        {
            List<Books> authors;

            using (Model1 db = new Model1())
            {
                authors = db.Books.ToList();
                //List<Users> books3 = db.Users.ToList();
                //ViewBag.data = books3;

            }
            return View(authors);




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
            using (Model1 db = new Model1())
            {

                db.Books.Add(books);
                //try
                //{
                
                    db.SaveChanges();

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
            }
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int? id)
        {
            Books books;

            using (Model1 db = new Model1())
            {
                books = db.Books.Where(a => a.Id == id).FirstOrDefault();
            }
            return View(books);
        }

        [HttpPost]
        public ActionResult Edit(Books books)
        {
            using (Model1 db = new Model1())
            {
                var oldBook = db.Books.Where(a => a.Id == books.Id).FirstOrDefault();
                oldBook.AuthorName = books.AuthorName;
                oldBook.Title = books.Title;
                oldBook.Pages = books.Pages;
                oldBook.Price = books.Price;

                db.SaveChanges();
            }
            return RedirectToActionPermanent("Index", "Books");
        }

        public ActionResult Delete(int id)
        {
            using (Model1 db = new Model1())
            {
                var books = db.Books.Where(a => a.Id == id).FirstOrDefault();
                db.Books.Remove(books);
                db.SaveChanges();
            }
            return RedirectToAction("Index", "Books");
            
        }
    }
}