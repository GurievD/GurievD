using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApplication3.Interfaces;

namespace WebApplication3.Repositories
{
    public class BookRepository : IRepository<Books>
    {
        private Model1 db;

        public BookRepository(Model1 context)
        {
            this.db = context;
        }

        public IEnumerable<Books> GetAll()
        {
            return db.Books.ToList();
        }

        public Books Get(int? id)
        {
            return db.Books.Find(id);
        }

        public void Create(Books books)
        {
            db.Books.Add(books);
        }


        public void Update(Books books)
        {
            db.Entry(books).State = EntityState.Modified;
        }

        public IEnumerable<Books> Find(Func<Books, bool> find)
        {
            return db.Books.Where(find).ToList();
        }

        public void Delete(int id)
        {
            Books book = db.Books.Find(id);
            if (book != null)
                db.Books.Remove(book);
        }


    }
}