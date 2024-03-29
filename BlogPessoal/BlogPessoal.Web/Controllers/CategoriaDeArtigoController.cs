﻿using BlogPessoal.Web.Data.Contexto;
using BlogPessoal.Web.Models;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace BlogPessoal.Web.Controllers
{
    public class CategoriaDeArtigoController : Controller
    {
        private const int TotalPorPagina = 5;
        private BlogPessoalContexto db = new BlogPessoalContexto();

        //[CompressFilter]
        //[WhitespaceFilter]
        //[OutputCache(Duration = 1000, VaryByParam = "none")]
        public ActionResult Index()
        {
            var lista = db.CategoriaDeArtigo
                .OrderBy(t => t.Nome)
                .ToList();
            return View(lista);
        }

        public ActionResult IndexPagedList(int? pagina)
        {
            var paginaAtual = pagina ?? 1;

            var lista = db.CategoriaDeArtigo
                .OrderBy(t => t.Nome);
                //.ToPagedList(paginaAtual, TotalPorPagina);
            return View(lista);
        }

        public ActionResult Create()
        {
            return View();
        }

        //[RequireHttps]
        //[ValidateInput(false)]
        [HttpPost]
        public ActionResult Create(CategoriaDeArtigo categoria)
        {
            if (ModelState.IsValid)
            {
                db.CategoriaDeArtigo.Add(categoria);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(categoria);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var categoria = db.CategoriaDeArtigo.Find(id);
            if (categoria == null)
                return HttpNotFound();
            return View(categoria);
        }

        [HttpPost]
        public ActionResult Edit(CategoriaDeArtigo categoria)
        {
            if (ModelState.IsValid)
            {
                db.Entry(categoria).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(categoria);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var categoria = db.CategoriaDeArtigo.Find(id);
            if (categoria == null)
                return HttpNotFound();
            return View(categoria);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var categoria = db.CategoriaDeArtigo.Find(id);
            db.CategoriaDeArtigo.Remove(categoria);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}