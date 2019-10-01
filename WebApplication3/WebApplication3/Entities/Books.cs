using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication3
{
    public partial class Books
    {

        public int Id { get; set; }

        public string AuthorName { get; set; }

        public int AuthorId { get; set; }

        [Required]
        [StringLength(150)]
        public string Title { get; set; }

        public int? Pages { get; set; }
        public int? Price { get; set; }

        public virtual Authors Authors { get; set; }


    }
}