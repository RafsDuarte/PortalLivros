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
        private RepositoryGenero _repositoryG = new RepositoryGenero();
        private RepositoryAutor _repositoryA = new RepositoryAutor();
        private RepositoryEditora _repositoryE = new RepositoryEditora();

        public ActionResult Estante(int GeneroLivros = 0, int AutorLivros = 0, int EditoraLivros = 0)
        {
            ViewBag.GeneroLivros = new SelectList(_repositoryG.ListarGeneros(), "ID", "NomeGenero");
            ViewBag.AutorLivros = new SelectList(_repositoryA.ListarAutores(), "ID", "NomeAutor");
            ViewBag.EditoraLivros = new SelectList(_repositoryE.ListarEditoras(), "ID", "Editora");
            List<vw_LIVRO> Livros = _repository.ListarLivros();

            if(GeneroLivros != 0)
            {
                Livros = Livros.Where(p => p.IDGenero.Equals(GeneroLivros)).ToList();
                return View(Livros);
            }


            if (AutorLivros != 0)
            {
                Livros = Livros.Where(p => p.IDAutor.Equals(AutorLivros)).ToList();
                return View(Livros);
            }


            if (EditoraLivros != 0)
            {
                Livros = Livros.Where(p => p.IDEditora.Equals(EditoraLivros)).ToList();
                return View(Livros);
            }

            return View(Livros);
        }

        public ActionResult CriarLivro()
        {
            return View();
        }

        public ActionResult FiltrarLivros()
        {
            return null;
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CriarLivro(vw_LIVRO oLivro, HttpPostedFileBase upload)
        {
            if (ModelState.IsValid)
            {
                List<EDITORA> Editoras = _repositoryE.ListarEditoras();
                List<AUTOR> Autores = _repositoryA.ListarAutores();
                List<GENERO> Generos = _repositoryG.ListarGeneros();
                LIVRO LivroGravar = new LIVRO();
                GENERO GeneroAtual = new GENERO();
                EDITORA EditoraAtual = new EDITORA();
                AUTOR AutorAtual = new AUTOR();

                #region UploadArquivo
                int ups = Request.Files.Count;
                if (ups > 0)
                {
                    upload = Request.Files[0];
                    if (upload.ContentLength > 0)
                    {
                        string path = Server.MapPath("~/Uploads/");
                        if (!Directory.Exists(path))
                        {
                            Directory.CreateDirectory(path);
                        }
                        LivroGravar.ImagemCaminho = "~/Uploads/" + upload.FileName;
                        upload.SaveAs(path + Path.GetFileName(upload.FileName));
                    }
                }
                #endregion


                LivroGravar.ISBN = oLivro.ISBN;
                LivroGravar.Sinopse = oLivro.Sinopse;
                LivroGravar.Titulo = oLivro.Titulo;
                LivroGravar.DataPublicacao = oLivro.DataPublicacao;
                #region GENERO
                GeneroAtual = Generos.Where(x => x.NomeGenero.ToLower() == oLivro.NomeGenero.ToLower()).Select(x => x).FirstOrDefault();
                if (GeneroAtual != null)
                {
                    LivroGravar.IDGenero = GeneroAtual.ID;
                }
                else
                {
                    GENERO novogenero = new GENERO() { NomeGenero = oLivro.NomeGenero };
                    _repositoryG.Incluir(novogenero);
                    GeneroAtual = novogenero;
                    LivroGravar.IDGenero = novogenero.ID;
                }
                
                #endregion
                #region Autor
                AutorAtual = Autores.Where(x => x.NomeAutor.ToLower() == oLivro.NomeAutor.ToLower()).Select(x => x).FirstOrDefault();
                if (AutorAtual != null)
                {
                    LivroGravar.IDAutor = AutorAtual.ID;
                }
                else
                {
                    AUTOR novoautor = new AUTOR() { NomeAutor = oLivro.NomeAutor };
                    _repositoryA.Incluir(novoautor);
                    AutorAtual = novoautor;
                    LivroGravar.IDAutor = novoautor.ID;
                }
                
                #endregion
                #region Editora
                EditoraAtual = Editoras.Where(x => x.Editora.ToLower() == oLivro.Editora.ToLower()).Select(x => x).FirstOrDefault();
                if (EditoraAtual != null)
                {
                    LivroGravar.IDEditora = EditoraAtual.ID;
                }
                else
                {
                    EDITORA novaeditora = new EDITORA() { Editora = oLivro.Editora };
                    _repositoryE.Incluir(novaeditora);
                    EditoraAtual = novaeditora;
                    LivroGravar.IDEditora = novaeditora.ID;
                }

                #endregion

                _repository.Incluir(LivroGravar);
                
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
