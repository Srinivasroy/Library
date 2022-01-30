using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Library.Models;
using EntityState = System.Data.Entity.EntityState;

namespace Library.Controllers
{
    public class Online_Books_RecordController : Controller
    {
        private LoginEntities8 db = new LoginEntities8();

        // GET: Online_Books_Record
        public ActionResult Index()
        {
            return View(db.Online_Books_Records.ToList());
        }

        public ActionResult Online_book_records()
        {
            return View(db.Online_Books_Records.ToList());
        }

        // GET: Online_Books_Record/Details/5
        public ActionResult Details()
        {
            
            return View();
        }

        // GET: Online_Books_Record/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Online_Books_Record/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SNO,Book_Name,Author_Name_,User_Email,Issued_ON,Return_ON")] Online_Books_Record online_Books_Record)
        {
            if (ModelState.IsValid)
            {
                db.Online_Books_Records.Add(online_Books_Record);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(online_Books_Record);
        }

        // GET: Online_Books_Record/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Online_Books_Record online_Books_Record = db.Online_Books_Records.Find(id);
            if (online_Books_Record == null)
            {
                return HttpNotFound();
            }
            return View(online_Books_Record);
        }

        // POST: Online_Books_Record/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SNO,Book_Name,Author_Name_,User_Email,Issued_ON,Return_ON")] Online_Books_Record online_Books_Record)
        {
            if (ModelState.IsValid)
            {
                db.Entry(online_Books_Record).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(online_Books_Record);
        }

        // GET: Online_Books_Record/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Online_Books_Record online_Books_Record = db.Online_Books_Records.Find(id);
            if (online_Books_Record == null)
            {
                return HttpNotFound();
            }
            return View(online_Books_Record);
        }

        // POST: Online_Books_Record/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            book book = new book();
            Online_Books_Record online_Books_Record = db.Online_Books_Records.Find(id);
            db.Online_Books_Records.Remove(online_Books_Record);
           book.Quantity = (book.Quantity - 1);
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
