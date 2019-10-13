using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication3.Controllers
{
    public class OrdersController : Controller
    {
        // GET: Orders
        public ActionResult Index()
        {
            List<Orders> orders;
            //ViewBag.Message = "Это вызов частичного представления из обычного";
            using (Model1 db = new Model1())
            {
                orders = db.Orders.ToList();
                //List<Users> books3 = db.Users.ToList();
                //ViewBag.data = books3;
                return View(db.Orders.OrderBy(x => x.Id).Take(5).ToList());

            }
        }

        [HttpGet]
        public ActionResult Create()
        {
            Model1 db = new Model1();

            SelectList orders = new SelectList(db.Users, "Id", "Id", db.Users.Select(model => model.Id));
            ViewBag.UsersId = orders;
            SelectList orders2 = new SelectList(db.Users, "Name", "Name", db.Users.Select(model => model.Name));
            ViewBag.UsersName = orders2;
            SelectList orders3 = new SelectList(db.Books, "Id", "Id", db.Books.Select(model => model.Id));
            ViewBag.BooksId = orders3;
            SelectList orders4 = new SelectList(db.Books, "Title", "Title", db.Books.Select(model => model.Title));
            ViewBag.BooksName = orders4;
            //SelectList books = new SelectList(db.Authors, "Id", "Id", db.Authors.Select(model => model.Id));
            //ViewBag.AuthorId = books;



            return View();
        }

        [HttpPost]
        public ActionResult Create(Orders orders)
        {
            using (Model1 db = new Model1())
            {

                db.Orders.Add(orders);
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
            Orders orders;

            using (Model1 db = new Model1())
            {
                orders = db.Orders.Where(a => a.Id == id).FirstOrDefault();
            }
            return View(orders);
        }

        [HttpPost]
        public ActionResult Edit(Orders orders)
        {
            using (Model1 db = new Model1())
            {
                var oldOrder = db.Orders.Where(a => a.Id == orders.Id).FirstOrDefault();
                oldOrder.BooksName = orders.BooksName;
                oldOrder.UsersName = orders.UsersName;

                db.SaveChanges();
            }
            return RedirectToActionPermanent("Index", "Orders");
        }

        public ActionResult Delete(int id)
        {
            using (Model1 db = new Model1())
            {
                var orders = db.Orders.Where(a => a.Id == id).FirstOrDefault();
                db.Orders.Remove(orders);
                db.SaveChanges();
            }
            return RedirectToAction("Index", "Orders");

        }

        public ActionResult Partial()
        {
                Model1 db = new Model1();

                //ViewBag.Message = "Это частичное представление.";
                return PartialView();
        }
    }
}