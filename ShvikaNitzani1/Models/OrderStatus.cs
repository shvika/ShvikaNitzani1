using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace ShvikaNitzani1.Models
{
    public class OrderStatus 
    {
        public int OrderStatusId { get; set; }
        public string name { get; set; }
    }

    public class OrderStatusValues
    {
        public static int WAITING_PAIMENT = 1;
        public static int WAITING_DELIVERY = 2;
        public static int DONE = 3;
        public static int WAITING_REFUND = 4;
        public static int REFUND_SENT = 5;
        public static int REFUND_DONE = 6;
        public static int CANCELLED = 7;

        public static string[] statusNames =  {"", "Waiting Payment", "Waiting Delivery", "Done", 
                                                "Waiting Refund", "Refund Sent", "Refund Done", "Cancelled"};
    }
    
    public class OrderStatusSelectionViewModel
    {
        public IEnumerable<OrderStatus> OrderStatusSelectionOptions =
        new List<OrderStatus>
        {
            new OrderStatus {OrderStatusId = OrderStatusValues.WAITING_PAIMENT, 
                             name = OrderStatusValues.statusNames[OrderStatusValues.WAITING_PAIMENT ] },

            new OrderStatus {OrderStatusId = OrderStatusValues.WAITING_DELIVERY, 
                             name = OrderStatusValues.statusNames[OrderStatusValues.WAITING_DELIVERY ]},

            new OrderStatus {OrderStatusId = OrderStatusValues.DONE, 
                             name = OrderStatusValues.statusNames[OrderStatusValues.DONE ]},

            new OrderStatus {OrderStatusId = OrderStatusValues.WAITING_REFUND, 
                             name = OrderStatusValues.statusNames[OrderStatusValues.WAITING_REFUND]},

            new OrderStatus {OrderStatusId = OrderStatusValues.REFUND_SENT, 
                             name = OrderStatusValues.statusNames[OrderStatusValues.REFUND_SENT]},
            
            new OrderStatus {OrderStatusId = OrderStatusValues.REFUND_DONE, 
                             name = OrderStatusValues.statusNames[OrderStatusValues.REFUND_DONE]},

            new OrderStatus {OrderStatusId = OrderStatusValues.CANCELLED, 
                             name = OrderStatusValues.statusNames[OrderStatusValues.CANCELLED ]},

        };

        [DisplayName("Please select order status:")]
        public string requestedStatus { get; set; }
    }
}