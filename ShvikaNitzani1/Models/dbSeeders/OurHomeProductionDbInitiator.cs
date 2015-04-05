using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Diagnostics;

namespace ShvikaNitzani1.Models
{
    public class OurHomeProductionDbInitiator : CreateDatabaseIfNotExists<OurHomeContext>
    {
        public OurHomeProductionDbInitiator()
        {
            Debug.WriteLine("Production Initiator constructor called");
        }
        
        
        protected override void Seed(OurHomeContext context)
        {
            Debug.WriteLine("Production Initiator Seed method called");
        }
    }
}