using ISDTees_API.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ISDTees_API.Data
{

    public class AppDBContext : DbContext
    {
        public AppDBContext() : base("name=ISD_DBX")
        {

        }
        //This represents a table in our database
        public DbSet<Product> Products { get; set; }
    }
}