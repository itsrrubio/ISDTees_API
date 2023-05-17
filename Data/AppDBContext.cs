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

        //This represents the tables in our database
        public DbSet<Product> Products { get; set; }
        public DbSet<Config> Configs { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<LineItem> LineItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Spec> Specs { get; set; }
        public DbSet<Style> Styles { get; set; }
    }
}