﻿using System;
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
    public class IssuedBooksController : Controller 
    {
        private LoginEntities3 db = new LoginEntities3();

      


        // GET: IssuedBooks
       
        public ActionResult Index()
        {

           

            return View(db.IssuedBooks.ToList());

           
        }

        // GET: IssuedBooks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IssuedBook issuedBook = db.IssuedBooks.Find(id);
            if (issuedBook == null)
            {
                return HttpNotFound();
            }
            return View(issuedBook);
        }

        // GET: IssuedBooks/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: IssuedBooks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SNO,Book_Name,Author_Name,category,UserEmail,IssuedON,ReturnON")] IssuedBook issuedBook)
        {
            if (ModelState.IsValid)
            {
                db.IssuedBooks.Add(issuedBook);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(issuedBook);
        }

        // GET: IssuedBooks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IssuedBook issuedBook = db.IssuedBooks.Find(id);
            if (issuedBook == null)
            {
                return HttpNotFound();
            }
            return View(issuedBook);
        }

        // POST: IssuedBooks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SNO,Book_Name,Author_Name,category,UserEmail,IssuedON,ReturnON")] IssuedBook issuedBook)
        {
            if (ModelState.IsValid)
            {
                db.Entry(issuedBook).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(issuedBook);
        }

        // GET: IssuedBooks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IssuedBook issuedBook = db.IssuedBooks.Find(id);
            if (issuedBook == null)
            {
                return HttpNotFound();
            }
            return View(issuedBook);
        }

        // POST: IssuedBooks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            IssuedBook issuedBook = db.IssuedBooks.Find(id);
            db.IssuedBooks.Remove(issuedBook);
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

        public ActionResult Return(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IssuedBook issuedBook = db.IssuedBooks.Find(id);
            if (issuedBook == null)
            {
                return HttpNotFound();
            }
            return View(issuedBook);
        }

        [HttpPost, ActionName("Return")]
        [ValidateAntiForgeryToken]
        public ActionResult ReturnConfirmed(int id)
        {
            IssuedBook issuedBook = db.IssuedBooks.Find(id);
            db.IssuedBooks.Remove(issuedBook);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
    