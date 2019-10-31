using MvcSiteMapProvider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication3.Repositories;


namespace WebApplication3.Controllers
{

    public class OrdersController : Controller
    {

        UnitOfWork unitOfWork;

        public OrdersController()
        {
            unitOfWork = new UnitOfWork();
        }

        // GET: Orders
        public ActionResult Index()
        {
            var orders = unitOfWork.Orders.GetAll();
            return View(orders);
            

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
                //if (orders.DateOrder.Date <= DateTime.Now.Date)
                //{
                //    ViewBag.err = "This user is a critical debtor!";
                //    return RedirectToAction("Create");

                //}

                if (orders.DateOrder > DateTime.Now || orders.DateOrder == null)
                {
                    unitOfWork.Orders.Create(orders);
                    unitOfWork.Save();
                    return RedirectToAction("Index");

                }
                else
                {
                    return RedirectToAction("Create");

                }

         




                //try
                //{


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

        }
        public ActionResult Edit(int? id)
        {
            Orders orders;


            orders = unitOfWork.Orders.Get(id);

            return View(orders);
        }

        [HttpPost]
        public ActionResult Edit(Orders orders)
        {
            var oldOrder = unitOfWork.Orders.Find(a => a.Id == orders.Id).FirstOrDefault();
            oldOrder.BooksName = orders.BooksName;
            oldOrder.UsersName = orders.UsersName;
   

            unitOfWork.Save();

            return RedirectToActionPermanent("Index", "Orders");
        }

        public ActionResult Delete(int id)
        {
            unitOfWork.Orders.Delete(id);
            unitOfWork.Save();

            return RedirectToAction("Index", "Orders");

        }

        protected override void Dispose(bool disposing)
        {
            unitOfWork.Dispose();
            base.Dispose(disposing);
        }

        public ActionResult Partial()
        {
                Model1 db = new Model1();

                //ViewBag.Message = "Это частичное представление.";
                return View(unitOfWork.Orders.GetAll().Take(5).ToList());
        }


    }
}