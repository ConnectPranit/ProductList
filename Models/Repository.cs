using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Crud_opreation.Models
{
    public class Repository:DbContext
    {
        public Repository() :base("ConnectionContext")
        {

        }
        public DbSet<Product> Products { get; set; } 
        public DbSet<Category> categories { get; set; }

       
    }
}