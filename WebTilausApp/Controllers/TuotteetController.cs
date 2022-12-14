using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebTilausApp.Models;

namespace WebTilausApp.Controllers
{
    public class TuotteetController : Controller
    {
        TilausDbEntities1 db = new TilausDbEntities1();
        // GET: Tuotteet
        public ActionResult Index()
        {
            if (Session["UserName"] == null)
            {
                return RedirectToAction("Login", "Home");
            }
            else
            {
                var tuotteet = db.Tuotteet;
                ViewBag.LoggedStatus = Session["UserName"];
                return View(tuotteet.ToList());
            }
        }
    

public ActionResult Index2()
        {
            if (Session["UserName"] == null)
            {
                return RedirectToAction("Login", "Home");
            }
            else
            {
                var tuotteet = db.Tuotteet;
                ViewBag.LoggedStatus = Session["UserName"];
                return View(tuotteet.ToList());
            }
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TuoteID, Nimi, Ahinta, Kuvalinkki")] Tuotteet tuote)
        {
            if (ModelState.IsValid)
            {
                db.Tuotteet.Add(tuote);
                db.SaveChanges();
                return RedirectToAction("Index2");
            }
            return View(tuote);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            Tuotteet tuote = db.Tuotteet.Find(id);
            if (tuote == null) return HttpNotFound();
            return View(tuote);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TuoteID,Nimi,Ahinta,Kuvalinkki")] Tuotteet tuote)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tuote).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index2");
            }
            return View(tuote);
        }
        public ActionResult Delete(int? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            Tuotteet tuote = db.Tuotteet.Find(id);
            if (tuote == null) return HttpNotFound();
            return View(tuote);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tuotteet tuote = db.Tuotteet.Find(id);
            db.Tuotteet.Remove(tuote);
            db.SaveChanges();
            return RedirectToAction("Index2");
        }
    }
}