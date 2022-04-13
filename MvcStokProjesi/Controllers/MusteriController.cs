using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcStokProjesi.Models.Entity;

namespace MvcStokProjesi.Controllers
{
    public class MusteriController : Controller
    {
        // GET: Musteri
        MvcDbStokEntities db = new MvcDbStokEntities();
        public ActionResult Index()
        {
            var degerler = db.Musteriler.ToList();
            return View(degerler);
        }

        [HttpGet]
        public ActionResult YeniMusteri()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniMusteri(Musteriler musteri)
        {
            db.Musteriler.Add(musteri);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}