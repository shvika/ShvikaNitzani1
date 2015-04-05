using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace ShvikaNitzani1.Models
{
    public class OurHomeDevDbInitiator : DropCreateDatabaseIfModelChanges<OurHomeContext>
    {
        public OurHomeDevDbInitiator()
        {
            Debug.WriteLine("Dev Initiator constructor called");
        }
        
        protected override void Seed(OurHomeContext context)
        {
            
            DbBuilder dbBuilder = new DbBuilder();
            dbBuilder.BuildOrderStatusList(context);
            context.SaveChanges();

            dbBuilder.BuildDummyItems(context);
            context.SaveChanges();
        }

        private void AddItemDescription(OurHomeContext context)
        {
            string  seedItemDescription = "Dev env. seed db item";
            foreach (var order in context.OnlineOrders)
                order.ItemDescription = seedItemDescription;

        }
    }
}