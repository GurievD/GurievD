using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApplication3.Interfaces;

namespace WebApplication3.Repositories
{
    public class AuthorRepository : IRepository<Authors>
    {
        private Model1 db;

        public AuthorRepository(Model1 context)
        {
            this.db = context;
        }

        public IEnumerable<Authors> GetAll()
        {
            return db.Authors.ToList();
        }

        public Authors Get(int? id)
        {
            return db.Authors.Find(id);
        }

        public void Create(Authors authors)
        {
            db.Authors.Add(authors);
        }


        public void Update(Authors authors)
        {
            db.Entry(authors).State = EntityState.Modified;
        }

        public IEnumerable<Authors> Find(Func<Authors, bool> find)
        {
            return db.Authors.Where(find).ToList();
        }

        public void Delete(int id)
        {
            Authors author = db.Authors.Find(id);
            if (author != null)
                db.Authors.Remove(author);
        }
    }
}