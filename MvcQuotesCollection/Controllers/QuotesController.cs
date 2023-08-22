using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MvcQuotesCollection.Models;

namespace MvcQuotesCollection.Controllers
{
    public class QuotesController : Controller
    {
        private QuoteDBContext db = new QuoteDBContext();

        // GET: Quotes
        public ActionResult Index(string userName, string searchString, string rating, string quote)
        {
            var UserNameLst = new List<string>();
            var UserNameQry = from d in db.Quotes
                           orderby d.UserName
                           select d.UserName;

            UserNameLst.AddRange(UserNameQry.Distinct());
            ViewBag.userName = new SelectList(UserNameQry);

            var quotes = from m in db.Quotes
                         select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                quotes = quotes.Where(s => s.UserName.Contains(searchString) || s.Rating.Contains(searchString) || s.UserQuote.StartsWith(searchString) );
            }

            if (!string.IsNullOrEmpty(userName))
            {
                quotes = quotes.Where(x => x.UserName == userName);
            }
            if (!string.IsNullOrEmpty(rating))
            {
                quotes = quotes.Where(x => x.Rating == rating);
            }
            if (!string.IsNullOrEmpty(quote))
            {
                quotes = quotes.Where(x => x.UserQuote == quote);
            }
            return View(quotes);
        }

        // GET: Quotes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Quote quote = db.Quotes.Find(id);
            if (quote == null)
            {
                return HttpNotFound();
            }
            return View(quote);
        }

        // GET: Quotes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Quotes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,UserName,UserAge,Rating,UserQuote,AddedDate")] Quote quote)
        {
            if (ModelState.IsValid)
            {
                db.Quotes.Add(quote);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(quote);
        }

        // GET: Quotes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Quote quote = db.Quotes.Find(id);
            if (quote == null)
            {
                return HttpNotFound();
            }
            return View(quote);
        }

        // POST: Quotes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,UserName,UserAge,Rating,UserQuote,AddedDate")] Quote quote)
        {
            if (ModelState.IsValid)
            {
                db.Entry(quote).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(quote);
        }

        // GET: Quotes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Quote quote = db.Quotes.Find(id);
            if (quote == null)
            {
                return HttpNotFound();
            }
            return View(quote);
        }

        // POST: Quotes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Quote quote = db.Quotes.Find(id);
            db.Quotes.Remove(quote);
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
