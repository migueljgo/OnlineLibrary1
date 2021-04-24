using OnlineLibrary1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace OnlineLibrary1.Controllers
{
    public class BorrowController : Controller
    {

        private OnlineLibrary1Entities db = new OnlineLibrary1Entities();
        private OLVM olvm = new OLVM();
        public ActionResult BorrowIndex(int userid)
        {
            db.Borroweds.Where(x => x.UserID == userid).ToList();

            olvm.borrowedsList = db.Borroweds.Where(x => x.UserID == userid).ToList();
            return View(olvm);
        }

        [HttpPost]
        public ActionResult BorrowIndex(int bookid,int userid, Borrowed  borrowed)
        {
            borrowed.BookID = bookid;
            borrowed.UserID = userid;
            db.Borroweds.Add(borrowed);
         
            db.SaveChanges();
          
            olvm.borrowedsList= db.Borroweds.Where(x => x.UserID == userid).ToList();
            return View(olvm);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Borrowed borrowed = db.Borroweds.Find(id);
            if (borrowed == null)
            {
                return HttpNotFound();
            }
            return View();
        }

        // POST: Books/Delete/5
        [HttpPost, ActionName("Delete")]
     
        public ActionResult DeleteConfirmed(int id)
        {
            Borrowed borrowed = db.Borroweds.Find(id);
            db.Borroweds.Remove(borrowed);
            db.SaveChanges();
            return RedirectToAction("Index","Books");
        }


    }
}