using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Library.Models;

namespace Library.Controllers
{
    public class Online_Book_OrdersController : Controller
    {
        private LoginEntities9 db = new LoginEntities9();

        // GET: Online_Book_Orders
        public ActionResult Index()
        {
            //return View(db.Online_Book_Orders.ToList());
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(Online_Book_Orders orders)
        {

            db.Online_Book_Orders.Add(orders);
            db.SaveChanges();


            return View();

        }


        // GET: Online_Book_Orders/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Online_Book_Orders online_Book_Orders = db.Online_Book_Orders.Find(id);
            if (online_Book_Orders == null)
            {
                return HttpNotFound();
            }
            return View(online_Book_Orders);
        }

        // GET: Online_Book_Orders/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Online_Book_Orders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,First_Name,Last_Name,Area,City,Postal_Code,Phone_Number,Email")] Online_Book_Orders online_Book_Orders)
        {
            if (ModelState.IsValid)
            {
                db.Online_Book_Orders.Add(online_Book_Orders);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(online_Book_Orders);
        }

        // GET: Online_Book_Orders/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Online_Book_Orders online_Book_Orders = db.Online_Book_Orders.Find(id);
            if (online_Book_Orders == null)
            {
                return HttpNotFound();
            }
            return View(online_Book_Orders);
        }

        // POST: Online_Book_Orders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,First_Name,Last_Name,Area,City,Postal_Code,Phone_Number,Email")] Online_Book_Orders online_Book_Orders)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(online_Book_Orders).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(online_Book_Orders);
        }

        // GET: Online_Book_Orders/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Online_Book_Orders online_Book_Orders = db.Online_Book_Orders.Find(id);
            if (online_Book_Orders == null)
            {
                return HttpNotFound();
            }
            return View(online_Book_Orders);
        }

        // POST: Online_Book_Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Online_Book_Orders online_Book_Orders = db.Online_Book_Orders.Find(id);
            db.Online_Book_Orders.Remove(online_Book_Orders);
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
