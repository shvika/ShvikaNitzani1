using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace ShvikaNitzani1.Models
{
    public class OurHomeContext : DbContext
    {
        public DbSet<OrderStatus> OrderStatuses { get; set; }
        public DbSet<OnlineOrder> OnlineOrders {get; set;}
        public DbSet<TestModel>   DummyData { get; set; }
        public DbSet<WebsiteTodo> WebsiteTodos { get; set; }
       

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}