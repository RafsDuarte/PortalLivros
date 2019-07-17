using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PortalLivros.Model;

namespace PortalLivros.Web.Views
{
    public class LIVROController : Controller
    {
        private PortalLivrosEntities db = new PortalLivrosEntities();

        // GET: LIVRO
        public ActionResult Index()
        {
            return View(db.LIVRO.ToList());
        }

        // GET: LIVRO/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LIVRO lIVRO = db.LIVRO.Find(id);
            if (lIVRO == null)
            {
                return HttpNotFound();
            }
            return View(lIVRO);
        }

        // GET: LIVRO/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LIVRO/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,ISBN,ImagemCapa,DataPublicacao,Titulo,Editora,Autor,Texto")] LIVRO lIVRO)
        {
            if (ModelState.IsValid)
            {
                db.LIVRO.Add(lIVRO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(lIVRO);
        }

        // GET: LIVRO/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LIVRO lIVRO = db.LIVRO.Find(id);
            if (lIVRO == null)
            {
                return HttpNotFound();
            }
            return View(lIVRO);
        }

        // POST: LIVRO/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,ISBN,ImagemCapa,DataPublicacao,Titulo,Editora,Autor,Texto")] LIVRO lIVRO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lIVRO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(lIVRO);
        }

        // GET: LIVRO/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LIVRO lIVRO = db.LIVRO.Find(id);
            if (lIVRO == null)
            {
                return HttpNotFound();
            }
            return View(lIVRO);
        }

        // POST: LIVRO/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LIVRO lIVRO = db.LIVRO.Find(id);
            db.LIVRO.Remove(lIVRO);
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
