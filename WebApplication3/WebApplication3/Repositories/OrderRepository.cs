using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApplication3.Interfaces;

namespace WebApplication3.Repositories
{
    public class OrderRepository : IRepository<Orders>
    {
        private Model1 db;

        public OrderRepository(Model1 context)
        {
            this.db = context;
        }

        public IEnumerable<Orders> GetAll()
        {
            return db.Orders.ToList();
        }

        public Orders Get(int? id)
        {
            return db.Orders.Find(id);
        }

        public void Create(Orders orders)
        {
            db.Orders.Add(orders);
        }


        public void Update(Orders orders)
        {
            db.Entry(orders).State = EntityState.Modified;
        }

        public IEnumerable<Orders> Find(Func<Orders, bool> find)
        {
            return db.Orders.Where(find).ToList();
        }

        public void Delete(int id)
        {
            Orders orders = db.Orders.Find(id);
            if (orders != null)
                db.Orders.Remove(orders);
        }
    }
}