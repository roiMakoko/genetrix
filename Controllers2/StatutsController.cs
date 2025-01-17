﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using genetrix.Models;

namespace genetrix.Controllers
{
    public class StatutsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Statuts
        public ActionResult Index()
        {
            return View(db.GetStatuts.ToList());
        }

        // GET: Statuts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Statut statut = db.GetStatuts.Find(id);
            if (statut == null)
            {
                return HttpNotFound();
            }
            return View(statut);
        }

        // GET: Statuts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Statuts/Create
        // Pour vous protéger des attaques par survalidation, activez les propriétés spécifiques auxquelles vous souhaitez vous lier. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MessageCLient,MessageAgence,CouleurSt,Etape,StatusDossierClient,StatusDossierBanque,Argb")] Statut statut)
        {
            if (ModelState.IsValid)
            {
                db.GetStatuts.Add(statut);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(statut);
        }

        // GET: Statuts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Statut statut = db.GetStatuts.Find(id);
            if (statut == null)
            {
                return HttpNotFound();
            }
            return View(statut);
        }

        // POST: Statuts/Edit/5
        // Pour vous protéger des attaques par survalidation, activez les propriétés spécifiques auxquelles vous souhaitez vous lier. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,MessageCLient,MessageAgence,CouleurSt,Etape,StatusDossierClient,StatusDossierBanque,Argb")] Statut statut)
        {
            if (ModelState.IsValid)
            {
                db.Entry(statut).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(statut);
        }

        // GET: Statuts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Statut statut = db.GetStatuts.Find(id);
            if (statut == null)
            {
                return HttpNotFound();
            }
            return View(statut);
        }

        // POST: Statuts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Statut statut = db.GetStatuts.Find(id);
            db.GetStatuts.Remove(statut);
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
