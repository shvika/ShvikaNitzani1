using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.WebPages.Html;

namespace ShvikaNitzani1.Models
{
    public class OnlineOrder
    {
        public int OnlineOrderId { get; set; }
        [Display(Name = "Item Description")]
        public string ItemDescription { get; set; }
        [Display(Name = "Website Used")]
        public string WebSite { get; set; }
        [Display(Name = "Price")]
        public decimal Price { get; set; }
        [Display(Name = "Order Date and Time")]
        public DateTime OrderTime { get; set; }
        [Display(Name = "Delivery Time")]
        public DateTime? DeliveryTime { get; set; }
        [Display(Name = "Made By")]
        public string MadeByUser { get; set; }

        [ForeignKey("OrderStatus")]
        public int? OrderStatusId { get; set; }
        public virtual OrderStatus OrderStatus { get; set; }//navigation property
       
    }
    
    public class NewOrderInputViewModel
    {
        //[Required(ErrorMessage="This field is mandatory")]
        //[StringLength(10,  MinimumLength = 4, ErrorMessage="\"{0}\"  should include {2} to {1} character")]
        //[Display(Name = "Order submitted by")]
        //public string UserName { get; set; }



        [Required(ErrorMessage = "This field is mandatory")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "\"{0}\"  should include {2} to {1} character")]
        [Display(Name = "Item Description")]
        public string ItemDescription { get; set; }
    }

    
}