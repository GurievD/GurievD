using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication3
{
    public partial class Orders
    {
        public int Id { get; set; }
        public int BooksId { get; set; }
        public string BooksName { get; set; }

        public int UsersId { get; set; }
        public string UsersName { get; set; }

        public virtual Books book { get; set; }

        public virtual Users user { get; set; }
    }
}