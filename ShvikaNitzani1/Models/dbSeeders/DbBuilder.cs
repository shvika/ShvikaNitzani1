using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShvikaNitzani1.Models
{
    public class DbBuilder
    {
        private static int NUMBER_OF_DUMMY_ITEMS = 10;

        public void BuildOrderStatusList(OurHomeContext context)
        {
            Dictionary<string, OrderStatus> orderStatusDictionary = BuildOrderStatusDictionary();
            foreach (var dictionaryValue in orderStatusDictionary)
            {
                context.OrderStatuses.Add(dictionaryValue.Value);
            }
        }
        private  Dictionary<string, OrderStatus> BuildOrderStatusDictionary()
        {
            int index = 0;
            Dictionary<string, OrderStatus> statuses = new Dictionary<string, OrderStatus>();
            
            foreach (string name in OrderStatusValues.statusNames)
            {
                OrderStatus orderstatus = new OrderStatus();
                orderstatus.OrderStatusId = ++index;
                orderstatus.name = name;
                statuses.Add(name, orderstatus);
            }           
            return statuses;
        }

        public void BuildDummyItems(OurHomeContext context)
        {
            var orders = new List<OnlineOrder>();

            for (int i = 1; i <= NUMBER_OF_DUMMY_ITEMS; i++)
            {
                OnlineOrder order = new OnlineOrder
                {
                    DeliveryTime = new DateTime(1900 + i, 08, 25),
                    ItemDescription = "Dev db seeded item ." + i,
                    OrderStatusId = OrderStatusValues.DONE,
                    OrderTime = new DateTime(2014, 07, 28),
                    Price = 100 + i,
                    OnlineOrderId = i,
                    WebSite = i % 2 == 0 ? "Taobao" : "e-bay",
                    MadeByUser ="Dummy User"
                };
                orders.Add(order);
            }
            foreach (var order in orders)
                context.OnlineOrders.Add(order);
        }
    }
}