using MVC_CodeFirst.Models.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVC_CodeFirst.Models.ContextClasses
{
    public class MyContext : DbContext
    {
        public MyContext():base("MyConnection")
        {
            
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<HouseKeeper> HouseKeepers { get; set; }
    }
}