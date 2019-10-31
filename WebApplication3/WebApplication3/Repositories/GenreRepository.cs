using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApplication3.Interfaces;

namespace WebApplication3.Repositories
{
    public class GenreRepository : IRepository<Genres>
    {
        private Model1 db;

        public GenreRepository(Model1 context)
        {
            this.db = context;
        }

        public IEnumerable<Genres> GetAll()
        {
            return db.Genres.ToList();
        }

        public Genres Get(int? id)
        {
            return db.Genres.Find(id);
        }

        public void Create(Genres genres)
        {
            db.Genres.Add(genres);
        }


        public void Update(Genres genres)
        {
            db.Entry(genres).State = EntityState.Modified;
        }

        public IEnumerable<Genres> Find(Func<Genres, bool> find)
        {
            return db.Genres.Where(find).ToList();
        }

        public void Delete(int id)
        {
            Genres genres = db.Genres.Find(id);
            if (genres != null)
                db.Genres.Remove(genres);
        }
    }
}