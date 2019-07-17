using PortalLivros.Model;
using PortalLivros.Model.Repositories;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace PortalLivros.Web.Controllers
{
    public class MuralLivrosController : Controller
    {
        private RepositoryLivro _repository = new RepositoryLivro();

        public ActionResult Estante()
        {
            List<LIVRO> Livros = _repository.ListarLivros();
            return View(Livros);
        }

        public ActionResult CriarLivro()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CriarLivro(LIVRO oLivro, HttpPostedFileBase upload)
        {
            if (ModelState.IsValid)
            {
                //try
                //{
                //    if (upload != null && upload.ContentLength > 0)
                //    {
                //        //String s_data = upload.ToString();
                //        //string converted = s_data.Replace('-', '+');
                //        //converted = converted.Replace('_', '/');
                //        //byte[] data = Convert.FromBase64String(s_data);
                //        //string decodedString = Encoding.UTF8.GetString(data);
                //        var arqImagem = new LIVRO();
                //        ////string converted = upload.Replace('-', '+');
                //        ////converted = converted.Replace('_', '/');
                //        ////byte[] data = Convert.FromBase64String(converted);
                //        ////string decodedString = Encoding.UTF8.GetString(data);
                //        using (var reader = new BinaryReader(upload.InputStream))
                //        {
                //            arqImagem.ImagemCapa = reader.ReadBytes(upload.ContentLength);
                //            //arqImagem.ImagemCapa = Convert.FromBase64String(arqImagem.ImagemCapa);
                //        }
                //        oLivro.ImagemCapa = arqImagem.ImagemCapa;
                //        oLivro.ImagemCapa = new byte[upload.ContentLength];
                //        upload.InputStream.Read(oLivro.ImagemCapa, 0, upload.ContentLength);
                //    }
                //}
                //catch(Exception ex)
                //{
                //    throw ex;
                //}
                _repository.Incluir(oLivro);
                return RedirectToAction("Estante");
            }

            return View(oLivro);
        }

    //    // GET: LIVROes/Edit/5
    //    public ActionResult Edit(int? id)
    //    {
    //        if (id == null)
    //        {
    //            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
    //        }
    //        LIVRO lIVRO = db.LIVRO.Find(id);
    //        if (lIVRO == null)
    //        {
    //            return HttpNotFound();
    //        }
    //        return View(lIVRO);
    //    }

    //    // POST: LIVROes/Edit/5
    //    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
    //    // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
    //    [HttpPost]
    //    [ValidateAntiForgeryToken]
    //    public ActionResult Edit([Bind(Include = "ID,ISBN,ImagemCapa,DataPublicacao,Titulo,Editora,Autor,Texto")] LIVRO lIVRO)
    //    {
    //        if (ModelState.IsValid)
    //        {
    //            db.Entry(lIVRO).State = EntityState.Modified;
    //            db.SaveChanges();
    //            return RedirectToAction("Index");
    //        }
    //        return View(lIVRO);
    //    }

    //    // GET: LIVROes/Delete/5
    //    public ActionResult Delete(int? id)
    //    {
    //        if (id == null)
    //        {
    //            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
    //        }
    //        LIVRO lIVRO = db.LIVRO.Find(id);
    //        if (lIVRO == null)
    //        {
    //            return HttpNotFound();
    //        }
    //        return View(lIVRO);

    //    [HttpPost, ActionName("Delete")]
    //    [ValidateAntiForgeryToken]
    //    public ActionResult DeleteConfirmed(int id)
    //    {
    //        LIVRO lIVRO = db.LIVRO.Find(id);
    //        db.LIVRO.Remove(lIVRO);
    //        db.SaveChanges();
    //        return RedirectToAction("Index");
    //    }

    //    protected override void Dispose(bool disposing)
    //    {
    //        if (disposing)
    //        {
    //            db.Dispose();
    //        }
    //        base.Dispose(disposing);
    //    }
    }
}
