using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcStokProjesi.Models.Entity;

namespace MvcStokProjesi.Controllers
{
    public class UrunController : Controller
    {
        // GET: Urun
        MvcDbStokEntities db = new MvcDbStokEntities();
        public ActionResult Index()
        {
            var degerler = db.Urunler.ToList();
            return View(degerler);
        }

        [HttpGet]
        public ActionResult YeniUrun()
        {
            List<SelectListItem> degerler = (from i in db.Kategoriler.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.KategoriAdi,
                                                 Value = i.KategoriId.ToString()
                                             }).ToList();
            ViewBag.dgr = degerler;
            return View();
        }

        [HttpPost]
        public ActionResult YeniUrun(Urunler urun)
        {
            var ktg = db.Kategoriler.Where(x => x.KategoriId == urun.Kategoriler.KategoriId).FirstOrDefault();
            urun.Kategoriler = ktg;
            db.Urunler.Add(urun);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Sil(int id)
        {
            var urun = db.Urunler.Find(id);
            db.Urunler.Remove(urun);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult UrunGetir(int id)
        {
            var urun = db.Urunler.Find(id);
            List<SelectListItem> degerler = (from i in db.Kategoriler.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.KategoriAdi,
                                                 Value = i.KategoriId.ToString()
                                             }).ToList();
            ViewBag.dgr = degerler;
            return View("UrunGetir", urun);
        }

        public ActionResult Guncelle(Urunler urun)
        {
            var urn = db.Urunler.Find(urun.UrunId);
            urn.UrunAdi = urun.UrunAdi;
            urn.Marka = urun.Marka;
            var ktg = db.Kategoriler.Where(x => x.KategoriId == urun.Kategoriler.KategoriId).FirstOrDefault();
            urn.KategoriID = ktg.KategoriId;
            urn.Fiyat = urun.Fiyat;
            urn.Stok = urun.Stok;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}