using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication3.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            List<Users> users;
            using (Model1 db = new Model1())
            {

                users = db.Users.ToList();

            }
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
            using (Model1 db = new Model1())
            {
                db.Users.Add(user);
                db.SaveChanges();
            }
            return Redirect("Index");
        }

        public ActionResult Edit(int? id)
        {
            Users user;
            using (Model1 db = new Model1())
            {
                user = db.Users.Where(a => a.Id == id).FirstOrDefault();
            }
            return View(user);
        }

        [HttpPost]
        public ActionResult Edit(Users user)
        {
            using (Model1 db = new Model1())
            {
                var oldUser = db.Users.Where(a => a.Id == user.Id).FirstOrDefault();
                oldUser.Name = user.Name;
                oldUser.Email = user.Email;

                db.SaveChanges();
            }
            return RedirectToActionPermanent("Index", "User");
        }

        public ActionResult Delete(int id)
        {
            using (Model1 db = new Model1())
            {
                var user = db.Users.Where(a => a.Id == id).FirstOrDefault();
                db.Users.Remove(user);
                db.SaveChanges();
            }
            return RedirectToAction("Index", "User");
        }
    }
}