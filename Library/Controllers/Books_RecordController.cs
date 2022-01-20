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
    public class Books_RecordController : Controller
    {
        private LoginEntities1 db = new LoginEntities1();

        // GET: Books_Record
        public ActionResult Index()
        {
            return View(db.Books_Record.ToList());
        }

        // GET: Books_Record/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Books_Record books_Record = db.Books_Record.Find(id);
            if (books_Record == null)
            {
                return HttpNotFound();
            }
            return View(books_Record);
        }

        // GET: Books_Record/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Books_Record/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SNO,Book_Name,Book_IssuedTo,Book_IssuedOn,Book_ReturnOn")] Books_Record books_Record)
        {
            if (ModelState.IsValid)
            {
                db.Books_Record.Add(books_Record);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(books_Record);
        }

        // GET: Books_Record/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Books_Record books_Record = db.Books_Record.Find(id);
            if (books_Record == null)
            {
                return HttpNotFound();
            }
            return View(books_Record);
        }

        // POST: Books_Record/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SNO,Book_Name,Book_IssuedTo,Book_IssuedOn,Book_ReturnOn")] Books_Record books_Record)
        {
            if (ModelState.IsValid)
            {
                db.Entry(books_Record).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(books_Record);
        }

        // GET: Books_Record/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Books_Record books_Record = db.Books_Record.Find(id);
            if (books_Record == null)
            {
                return HttpNotFound();
            }
            return View(books_Record);
        }

        // POST: Books_Record/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Books_Record books_Record = db.Books_Record.Find(id);
            db.Books_Record.Remove(books_Record);
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
