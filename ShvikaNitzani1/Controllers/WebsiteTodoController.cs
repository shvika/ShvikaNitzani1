using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ShvikaNitzani1.Models;

namespace ShvikaNitzani1.Controllers
{
    [Authorize]
    public class WebsiteTodoController : Controller
    {
        private OurHomeContext db = new OurHomeContext();

        // GET: /WebsiteTodo/
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View(db.WebsiteTodos.ToList());
        }

        // GET: /WebsiteTodo/Details/5
        
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WebsiteTodo websitetodo = db.WebsiteTodos.Find(id);
            if (websitetodo == null)
            {
                return HttpNotFound();
            }
            return View(websitetodo);
        }

        // GET: /WebsiteTodo/Create
       
        public ActionResult Create()
        {
            return View();
        }

        // POST: /WebsiteTodo/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        
        public ActionResult Create([Bind(Include = "WebsiteTodoId,Subject,Details,SuggestedBy")] WebsiteTodo websitetodo)
        {
            if (ModelState.IsValid)
            {
                DateTime now = new DateTime();
                now = DateTime.Now;
                websitetodo.SuggestedBy = User.Identity.Name;
                websitetodo.Date = now.ToShortDateString();
                db.WebsiteTodos.Add(websitetodo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(websitetodo);
        }

        // GET: /WebsiteTodo/Edit/5
        
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WebsiteTodo websitetodo = db.WebsiteTodos.Find(id);
            if (websitetodo == null)
            {
                return HttpNotFound();
            }
            return View(websitetodo);
        }

        // POST: /WebsiteTodo/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
       
        public ActionResult Edit([Bind(Include="WebsiteTodoId,Subject,Details,SuggestedBy")] WebsiteTodo websitetodo)
        {
            if (ModelState.IsValid)
            {
                DateTime now = new DateTime();
                now = DateTime.Now;

                websitetodo.Date = now.ToShortDateString();
                websitetodo.SuggestedBy = User.Identity.Name;
                db.Entry(websitetodo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(websitetodo);
        }

        // GET: /WebsiteTodo/Delete/5
        
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WebsiteTodo websitetodo = db.WebsiteTodos.Find(id);
            if (websitetodo == null)
            {
                return HttpNotFound();
            }
            return View(websitetodo);
        }

        // POST: /WebsiteTodo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        
        public ActionResult DeleteConfirmed(int id)
        {
            WebsiteTodo websitetodo = db.WebsiteTodos.Find(id);
            db.WebsiteTodos.Remove(websitetodo);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
