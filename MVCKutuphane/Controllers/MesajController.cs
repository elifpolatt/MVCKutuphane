using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCKutuphane.Models;

namespace MVCKutuphane.Controllers
{
    public class MesajController : Controller
    {
        // GET: Mesaj
        KutuphaneDBEntities2 db = new KutuphaneDBEntities2();
        //Üye paneli 
        //Gelen mesaj kutusu
        public ActionResult Index()
        {
            var kullaniciadi = (string)Session["KULLANICIADI"].ToString();
            var deger = db.tblmesajlar.Where(x=>x.ALICI == kullaniciadi.ToString()).ToList();
            return View(deger);
        }
        //Gönderilen mesajlar
        public ActionResult Giden()
        {
            var kullaniciadi = (string)Session["KULLANICIADI"].ToString();
            var giden = db.tblmesajlar.Where(x => x.GONDEREN == kullaniciadi.ToString()).ToList();
            return View(giden);
        }
        //Yeni mesaj oluştur
        [HttpGet]
        public ActionResult YeniMesaj()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniMesaj(tblmesajlar m)
        {
            var kullaniciadi = (string)Session["KULLANICIADI"].ToString();
            m.GONDEREN = kullaniciadi.ToString();
            m.TARIH = DateTime.Parse(DateTime.Now.ToShortDateString());
            db.tblmesajlar.Add(m);
            db.SaveChanges();
            return RedirectToAction("Giden","Mesaj");
        }
       //Mesaj bölümü partial
        public PartialViewResult MesajKutusu()
        {
            var kullaniciadi = (string)Session["KULLANICIADI"].ToString();
            var gelenmesaj = db.tblmesajlar.Where(x => x.ALICI == kullaniciadi).Count();
            ViewBag.gelenmsj = gelenmesaj;
            var gidenmesaj = db.tblmesajlar.Where(x => x.GONDEREN == kullaniciadi).Count();
            ViewBag.gidenmsj = gidenmesaj;
            return PartialView();
        }
    }
}