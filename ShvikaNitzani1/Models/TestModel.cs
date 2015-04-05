using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ShvikaNitzani1.Models
{
    public class TestModel
    {
        public int TestModelId { get; set; }
        public string Description { get; set; }
        public int DummyVal { get; set; }
        //public int Age { get; set; }
        //public string Address { get; set; }
        
    }

    public class MultipleItemsPerformanceTest 
    {
        //ulong maxValue = Math.Pow(10, 10);
        [Display(Name = "How many dummy items would you like to create?")]
        [Required(ErrorMessage = "Value must be set")]
        [Range(1, 1000000000, ErrorMessage = "Value must be between 1 and one billion")]
        public ulong NumberOfItems { get; set; }
    }
}