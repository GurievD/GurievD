using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication3.Repositories;

namespace WebApplication3.Controllers
{
    public class UserController : Controller
    {
        //k
        UnitOfWork unitOfWork;

        public UserController()
        {
            unitOfWork = new UnitOfWork();
        }
        // GET: User
        public ActionResult Index()
        {
            var users = unitOfWork.Users.GetAll();

            return View(users);
        }

        public ActionResult Create()
        {
            Model1 db = new Model1();

            SelectList books = new SelectList(db.Books, "Id", "Title");
            ViewBag.BooksList = books;

            return View();
        }

        [HttpPost]
        public ActionResult Create(Users user)
        {
            unitOfWork.Users.Create(user);
            unitOfWork.Save();
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int? id)
        {
            Users users;


            users = unitOfWork.Users.Get(id);

            return View(users);
        }

        [HttpPost]
        public ActionResult Edit(Users user)
        {

                var oldUser = unitOfWork.Users.Find(a => a.Id == user.Id).FirstOrDefault();
                oldUser.Name = user.Name;
                oldUser.Email = user.Email;

                unitOfWork.Save();
            
            return RedirectToActionPermanent("Index", "User");

        }

        public ActionResult Delete(int id)
        {
            unitOfWork.Users.Delete(id);
            unitOfWork.Save();

            return RedirectToAction("Index", "User");
        }

        protected override void Dispose(bool disposing)
        {
            unitOfWork.Dispose();
            base.Dispose(disposing);
        }
    }
}