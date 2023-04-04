using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCKutuphane.Models;

namespace MVCKutuphane.Controllers
{
    public class KitapController : Controller
    {
        // GET: Kitap
        KutuphaneDBEntities2 db = new KutuphaneDBEntities2();

        //Admin paneli kitaplar sayfası
        public ActionResult Index(string p)
        {
            //kitap arama işlemi için
            var kitaplar = from k in db.tblkitaplar select k;
            if (!string.IsNullOrEmpty(p))
            {
                kitaplar = kitaplar.Where(x => x.AD.Contains(p));
            }
            //var kitap = db.tblkitaplar.ToList();
            //return View(kitap);
            return View(kitaplar.ToList());
        }
        //Kitap Ekle
        //Kategori ve yazarlar için dropdown list oluşturdum
        [HttpGet]
        public ActionResult KitapEkle()
        {
            List<SelectListItem> kategori = (from i in db.tblkategoriler.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.AD,
                                               Value = i.ID.ToString()
                                           }).ToList();
            ViewBag.ktg = kategori;

            List<SelectListItem> yazar = (from i in db.tblyazarlar.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.AD + ' ' + i.SOYAD,
                                               Value = i.ID.ToString()
                                           }).ToList();
            ViewBag.yzr = yazar;
            return View();
        }
        [HttpPost]
        public ActionResult KitapEkle(tblkitaplar k)
        {
            var kategori = db.tblkategoriler.Where(m => m.ID == k.tblkategoriler.ID).FirstOrDefault();
            var yazar = db.tblyazarlar.Where(y => y.ID == k.tblyazarlar.ID).FirstOrDefault();
            k.tblkategoriler = kategori;
            k.tblyazarlar = yazar;
            db.tblkitaplar.Add(k);
            db.SaveChanges();
            return RedirectToAction("Index");

        }
        //Kitap Sil
        public ActionResult KitapSil(int id)
        {
            var deger = db.tblkitaplar.Find(id);
            db.tblkitaplar.Remove(deger);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        //Kitap getir - güncelleme işlemleri
        //Kategori ve yazarlar için dropdown list 
        public ActionResult KitapGetir(int id)
        {
            var deger = db.tblkitaplar.Find(id);
            List<SelectListItem> kategori = (from i in db.tblkategoriler.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.AD, //ön kısımda görünen
                                               Value = i.ID.ToString() //arka kısımda çalışacak

                                           }).ToList();
            ViewBag.ktg = kategori;

            List<SelectListItem> yazar = (from i in db.tblyazarlar.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.AD + ' ' + i.SOYAD,
                                               Value = i.ID.ToString()
                                           }).ToList();
            ViewBag.yzr = yazar;

            return View("KitapGetir", deger);
        }
        public ActionResult KitapGuncelle(tblkitaplar k)
        {
            var kitap = db.tblkitaplar.Find(k.ID);
            kitap.AD = k.AD;
            kitap.BASIMYIL = k.BASIMYIL;
            kitap.SAYFA = k.SAYFA;
            kitap.YAYINEVI = k.YAYINEVI;
            kitap.DURUM = k.DURUM;
            var ktg = db.tblkitaplar.Where(x => x.ID == k.tblkategoriler.ID).FirstOrDefault();
            var yaz = db.tblyazarlar.Where(y => y.ID == k.tblyazarlar.ID).FirstOrDefault();
            //kitap.KATEGORI = ktg.ID;
            kitap.YAZAR = yaz.ID;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}