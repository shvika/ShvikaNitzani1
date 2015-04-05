using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShvikaNitzani1.Models;

namespace ShvikaNitzani1.Controllers
{
    [Authorize]
    public class TestsController : Controller
    {
        //
        // GET: /Tests/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult MultipleItemsPerformanceTest ()
        {
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult MultipleItemsPerformanceTest(MultipleItemsPerformanceTest test)
        {
            return View(test);
        }

	}
}