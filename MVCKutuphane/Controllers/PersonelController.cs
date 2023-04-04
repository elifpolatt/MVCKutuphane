using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCKutuphane.Models;

namespace MVCKutuphane.Controllers
{
    public class PersonelController : Controller
    {
        // GET: Personel
        KutuphaneDBEntities2 db = new KutuphaneDBEntities2();
        //Admin paneli personeller sayfası
        public ActionResult Index()
        {
            var degerler = db.tblpersoneller.ToList();
            return View(degerler);
        }

        //Personel ekleme işlemi
        [HttpGet]
        public ActionResult PersonelEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult PersonelEkle(tblpersoneller tp)
        {
            //modeldeki durumu sağlamadıysa personel ekleyi geri döndür
            if (!ModelState.IsValid)
            {
                return View("PersonelEkle");
            }
            db.tblpersoneller.Add(tp);
            db.SaveChanges();
            return View();
        }
        //Personel silme işlemi
        public ActionResult PersonelSil(int id)
        {
            var deger = db.tblpersoneller.Find(id);
            db.tblpersoneller.Remove(deger);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        //Personel getir ve güncelleme işlemleri
        public ActionResult PersonelGetir(int id)
        {
            var deger = db.tblpersoneller.Find(id);
            return View("PersonelGetir",deger);
        }
        public ActionResult PersonelGuncelle(tblpersoneller p)
        {
            var deger = db.tblpersoneller.Find(p.ID);
            deger.PERSONEL = p.PERSONEL;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}