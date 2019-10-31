using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebApplication3
{
    public partial class Users
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }


    }
}