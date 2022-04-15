using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcStokProjesi.Models.Entity;
using PagedList;
using PagedList.Mvc;

namespace MvcStokProjesi.Controllers
{
    public class KategoriController : Controller
    {
        // GET: Kategori
        MvcDbStokEntities db = new MvcDbStokEntities();
        public ActionResult Index(int sayfa = 1)
        {
            var degerler = db.Kategoriler.ToList().ToPagedList(sayfa, 4);
            return View(degerler);
        }

        [HttpGet]
        public ActionResult YeniKategori()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniKategori(Kategoriler kategori)
        {
            if (!ModelState.IsValid)
            {
                return View("YeniKategori");
            }
            db.Kategoriler.Add(kategori);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Sil(int id)
        {
            var kategori = db.Kategoriler.Find(id);
            db.Kategoriler.Remove(kategori);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult KategoriGetir(int id)
        {
            var ktg = db.Kategoriler.Find(id);
            return View("KategoriGetir", ktg);
        }

        public ActionResult Guncelle(Kategoriler kategori)
        {
            var ktg = db.Kategoriler.Find(kategori.KategoriId);
            ktg.KategoriAdi = kategori.KategoriAdi;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}