using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCKutuphane;
using MVCKutuphane.Models;

namespace MVCKutuphane.Controllers
{
    public class KategoriController : Controller
    {
        // GET: Kategori
        KutuphaneDBEntities2 db = new KutuphaneDBEntities2();


        //Admin paneli Kategoriler sayfası
        public ActionResult Index()
        {
            var degerler = db.tblkategoriler.Where(x=>x.DURUM == true).ToList();
            return View(degerler);
        }
        
        //Kategori Ekle
        //Sayfa yüklendiğinde 
        [HttpGet]
        public ActionResult KategoriEkle()
        {
            return View();
        }

        //Sayfada işlem yapıldığında
        [HttpPost]
        public ActionResult KategoriEkle(tblkategoriler p)
        {
            db.tblkategoriler.Add(p);
            db.SaveChanges();
            return View();
        }
        //Kategori Sil
        public ActionResult KategoriSil(int id)
        { 
            var kategoriler = db.tblkategoriler.Find(id);
            //db.tblkategoriler.Remove(kategoriler);
            //ilişkili tablolarda remove kullanılmaz
            kategoriler.DURUM = false;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        //Kategori Getir ve Güncelle
        public ActionResult KategoriGetir(int id)
        {
            var kategori = db.tblkategoriler.Find(id);
            return View("KategoriGetir", kategori);
        }
        public ActionResult KategoriGuncelle(tblkategoriler tbl)
        {
            var deger = db.tblkategoriler.Find(tbl.ID);
            deger.AD = tbl.AD;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}