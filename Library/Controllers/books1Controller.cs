using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Library.Models;


namespace Library.Controllers
{
    public class books1Controller : Controller
    {
        private LoginEntities db = new LoginEntities();

        // GET: books1

        [HttpGet]
        public ActionResult Index()
        {
            
            return View(db.books.ToList());
        }
        [HttpGet]
        public ActionResult Index1()
        {

            return View(db.books.ToList());
        }



        // GET: books1/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            book book = db.books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            
            return View(book);
        }

        public ActionResult UserDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            book book = db.books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            
            return View(book);
        }

        // GET: books1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: books1/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SNO,Book_Name,Author_Name,category,Quantity")] book book)
        {
            if (ModelState.IsValid)
            {
                db.books.Add(book);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(book);
        }

        // GET: books1/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            book book = db.books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        // POST: books1/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SNO,Book_Name,Author_Name,category,Quantity")] book book)
        {
            if (ModelState.IsValid)
            {
                db.Entry(book).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(book);
        }

        // GET: books1/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            book book = db.books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        // POST: books1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            book book = db.books.Find(id);
            db.books.Remove(book);
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
        
        public ActionResult Cart(int? id)
        {
            LoginEntities3 db1 = new LoginEntities3();
           
            book book = db.books.Find(id);
            IssuedBook IssueDetails = new IssuedBook();
            Login L = new Login();
            IssueDetails.SNO = book.SNO;
            IssueDetails.Book_Name = book.Book_Name;
            IssueDetails.Author_Name = book.Author_Name;
            IssueDetails.category = book.category;
            IssueDetails.UserEmail = Session["email"].ToString();
            IssueDetails.IssuedON = DateTime.Now;
            IssueDetails.ReturnON = IssueDetails.IssuedON.AddDays(15);

            book.Quantity = (book.Quantity - 1);
            db.SaveChanges();

            db1.IssuedBooks.Add(IssueDetails);

                db1.SaveChanges();
             return RedirectToAction("Index", "IssuedBooks");
}



    }
}
