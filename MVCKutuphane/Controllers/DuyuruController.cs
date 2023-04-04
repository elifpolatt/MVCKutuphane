using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCKutuphane.Models;
namespace MVCKutuphane.Controllers
{
    public class DuyuruController : Controller
    {
        // GET: Duyuru
        KutuphaneDBEntities2 db = new KutuphaneDBEntities2();
        
        //Üye paneli duyurular index sayfası 
        public ActionResult Index()
        {
            var deger = db.tblduyurular.ToList();
            return View(deger);
        }
        //Admin paneli yeni duyuru ekleme işlemi:
        [HttpGet]
        public ActionResult YeniDuyuru()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniDuyuru(tblduyurular td)
        {
            db.tblduyurular.Add(td);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        //Admin paneli duyuru silme işlemi için:
        public ActionResult DuyuruSil(int id)
        {
            var deger = db.tblduyurular.Find(id);
            db.tblduyurular.Remove(deger);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        //Admin paneli duyuruların içerik sayfası için:
        public ActionResult DuyuruDetay(tblduyurular p)
        {
            var deger = db.tblduyurular.Find(p.ID);
            return View("DuyuruDetay", deger);
        }
        //Admin paneli duyuru güncelleme işlemi
        public ActionResult DuyuruGuncelle(tblduyurular td)
        {
            var deger = db.tblduyurular.Find(td.ID);
            deger.KATEGORI = td.KATEGORI;
            deger.ICERIK = td.ICERIK;
            deger.TARIH = td.TARIH;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}