using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApplication3.Interfaces;

namespace WebApplication3.Repositories
{
    public class UserRepository : IRepository<Users>
    {
        private Model1 db;

        public UserRepository(Model1 context)
        {
            this.db = context;
        }

        public IEnumerable<Users> GetAll()
        {
            return db.Users.ToList();
        }

        public Users Get(int? id)
        {
            return db.Users.Find(id);
        }

        public void Create(Users users)
        {
            db.Users.Add(users);
        }


        public void Update(Users users)
        {
            db.Entry(users).State = EntityState.Modified;
        }

        public IEnumerable<Users> Find(Func<Users, bool> find)
        {
            return db.Users.Where(find).ToList();
        }

        public void Delete(int id)
        {
            Users users = db.Users.Find(id);
            if (users != null)
                db.Users.Remove(users);
        }
    }
}