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
    public class Online_OrderController : Controller
    {
        private LoginEntities5 db = new LoginEntities5();

        // GET: Online_Order



       
        public ActionResult Index()
        {
            


            return View();

        }





        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(Online_Order orders)
        {
            
          


            db.Online_Orders.Add(orders);
            db.SaveChanges();

           
            return View();

        }



        // public ActionResult Online_Cart()
        //{
        //    return View(db.Online_Books_Records.ToList());
        //}


        








        // GET: Online_Order/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Online_Order online_Order = db.Online_Orders.Find(id);
            if (online_Order == null)
            {
                return HttpNotFound();
            }
            return View(online_Order);
        }

        // GET: Online_Order/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Online_Order/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,First_Name,Last_Name,Area,City,Postal_Code,Phone_Number,Email")] Online_Order online_Order)
        {
            if (ModelState.IsValid)
            {
                db.Online_Orders.Add(online_Order);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(online_Order);
        }

        // GET: Online_Order/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Online_Order online_Order = db.Online_Orders.Find(id);
            if (online_Order == null)
            {
                return HttpNotFound();
            }
            return View(online_Order);
        }

        // POST: Online_Order/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,First_Name,Last_Name,Area,City,Postal_Code,Phone_Number,Email")] Online_Order online_Order)
        {
            if (ModelState.IsValid)
            {
               // db.Entry(online_Order).State = EntityState.Modified;
               // db.Entry(issuedBook).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(online_Order);
        }

        // GET: Online_Order/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Online_Order online_Order = db.Online_Orders.Find(id);
            if (online_Order == null)
            {
                return HttpNotFound();
            }
            return View(online_Order);
        }

        // POST: Online_Order/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Online_Order online_Order = db.Online_Orders.Find(id);
            db.Online_Orders.Remove(online_Order);
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
