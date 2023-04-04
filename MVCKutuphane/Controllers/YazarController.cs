using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCKutuphane.Models;

namespace MVCKutuphane.Controllers
{
    public class YazarController : Controller
    {
        // GET: Yazar
        KutuphaneDBEntities2 db = new KutuphaneDBEntities2();
        //Admin paneli yazarlar sayfası
        public ActionResult Index()
        {
            var deger = db.tblyazarlar.ToList();
            return View(deger);
        }
        //Yazar Ekle
        [HttpGet]
        public ActionResult YazarEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YazarEkle(tblyazarlar y)
        {
            //Bilgileri girerken şart sağlanmadıysa aynı sayfada kal
            if (!ModelState.IsValid) 
            {
                return View("YazarEkle");
            }
            db.tblyazarlar.Add(y);
            db.SaveChanges();
            return View();
        }

        //Yazar Sil
        public ActionResult YazarSil(int id)
        {
            var yazarlar = db.tblyazarlar.Find(id);
            db.tblyazarlar.Remove(yazarlar);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        //Yazar getir ve güncelle
        public ActionResult YazarGetir(int id)
        {
            var yazar = db.tblyazarlar.Find(id);
            return View("YazarGetir", yazar);
        }
        public ActionResult YazarGuncelle(tblyazarlar y)
        {
            var yazar = db.tblyazarlar.Find(y.ID);
            yazar.AD = y.AD;
            yazar.SOYAD = y.SOYAD;
            yazar.DETAY = y.DETAY;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        //Admin paneli yazar index içinde yazar detayları
        public ActionResult YazarKitaplar(int id)
        {
            var deger = db.tblkitaplar.Where(x => x.YAZAR == id).ToList();
            var yazarad = db.tblyazarlar.Where(x => x.ID == id).Select(z => z.AD + " " + z.SOYAD).FirstOrDefault();
            ViewBag.kitapyazari = yazarad;
            return View(deger);
        }
    }
}