using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication3.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Users> Users { get; }
        IRepository<Orders> Orders { get; }
        IRepository<Authors> Authors { get; }
        IRepository<Books> Books { get; }
        void Save();
    }
}
