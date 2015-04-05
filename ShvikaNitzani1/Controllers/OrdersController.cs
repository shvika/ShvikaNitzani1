using ShvikaNitzani1.Models;
//using ShvikaNitzani1.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace ShvikaNitzani1.Controllers
{
    [Authorize]
    public class OrdersController : Controller
    {
        //private static int id=1;
        private OurHomeContext db;// = new OurHomeContext();
   
        public OrdersController()
        {
            db = new OurHomeContext();
            db.Database.Log = delegate(string text) { System.Diagnostics.Debug.WriteLine(text); };
        }
        
        public ActionResult Index()
        {
            return View();
        }
        
        public ActionResult InputNewOrder()
        {
            return View();
        }
        
        public ActionResult  SumbitNewOrder (NewOrderInputViewModel newOrderInputViewModel)
        {
            Debug.WriteLine("SubmitNewOrder: Item [" + newOrderInputViewModel.ItemDescription +
                            "], User [" + User.Identity.Name + "]");

            OnlineOrder newOrder = CreateNewOrder(newOrderInputViewModel);
            
            db.OnlineOrders.Add(newOrder);
            db.SaveChanges();
            
            return View();
            
        }

        private OnlineOrder CreateNewOrder (NewOrderInputViewModel newOrderInputViewModel)
        {
            OnlineOrder newOrder = new OnlineOrder();
            newOrder.ItemDescription = newOrderInputViewModel.ItemDescription;
            newOrder.MadeByUser = User.Identity.Name;
            newOrder.OrderTime = new DateTime();
            newOrder.OrderTime = DateTime.Now;

            newOrder.Price = new decimal(0);
            newOrder.OrderStatusId = OrderStatusValues.WAITING_PAIMENT;
            return newOrder;
        }
        
        public ActionResult GetHistoricOrders()
        {
            
           
            OrderStatusSelectionViewModel selectionList = new OrderStatusSelectionViewModel();
            return View(selectionList);

        }
        
        [HttpPost]
        public ActionResult DisplayOrdersByStatus(OrderStatusSelectionViewModel requestedOrderStatus)
        {

            
            var orders = db.OnlineOrders.ToList();
            List<OnlineOrder> displayList = new List<OnlineOrder>();
            foreach (OnlineOrder order in orders)
            {
                if ( (order.OrderStatus != null) &&
                     (order.OrderStatus.OrderStatusId.ToString() == requestedOrderStatus.requestedStatus) )
                {
                   
                    displayList.Add(order);
                }
            }
            DebugWriteItemsList();
            return View(displayList);
        }
       
        public ActionResult DeleteOrder(OnlineOrder order)
        {
            db.OnlineOrders.RemoveRange(db.OnlineOrders.Where(o => o.OnlineOrderId == order.OnlineOrderId));
            db.SaveChanges();
            return View(); 
        }

        private void DebugWriteItemsList()
        {
            foreach (var item in db.OnlineOrders)
            {
                Debug.WriteLine("Item: id = " + item.OnlineOrderId, ", Description = " + item.ItemDescription);
            }
        }
        
	}
}