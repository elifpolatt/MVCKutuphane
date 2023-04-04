using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCKutuphane.Models;
using PagedList;
using PagedList.Mvc;
namespace MVCKutuphane.Controllers
{
    public class UyeController : Controller
    {
        // GET: Uye
        KutuphaneDBEntities2 db = new KutuphaneDBEntities2();
        //Admin paneli üyeler sayfası
        public ActionResult Index(int sayfa = 1) //default olarak hangi sayfadan başlayacagını ayarlar
        {
            //var deger = db.tbluyeler.ToList();
            var deger = db.tbluyeler.ToList().ToPagedList(sayfa,3); 
            //Sayfalama işlemi yapıldı. Her sayfada üç veri var.
            return View(deger);
        }
        //Üye ekleme işlemi
        [HttpGet]
        public ActionResult UyeEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult UyeEkle(tbluyeler tu)
        {
            //Bilgileri girerken şart sağlanmadıysa aynı sayfada kal
            if (!ModelState.IsValid)
            {
                return View("UyeEkle");
            }
            db.tbluyeler.Add(tu);
            db.SaveChanges();
            return View();
        }
        //Üye silme işlemi
        public ActionResult UyeSil(int id)
        {
            var deger = db.tbluyeler.Find(id);
            db.tbluyeler.Remove(deger);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        //Üye getir ve güncelle işlemi
        public ActionResult UyeGetir(int id)
        {
            var deger = db.tbluyeler.Find(id);
            return View("UyeGetir", deger);
        }
        public ActionResult UyeGuncelle(tbluyeler tu)
        {
            var deger = db.tbluyeler.Find(tu.ID);
            deger.AD = tu.AD;
            deger.SOYAD = tu.SOYAD;
            deger.FOTOGRAF = tu.FOTOGRAF;
            deger.MAIL = tu.MAIL;
            deger.KULLANICIADI = tu.KULLANICIADI;
            deger.SIFRE= tu.SIFRE;
            deger.TELEFON = tu.TELEFON;
            deger.OKUL = tu.OKUL;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        //Üyelerin kitap geçmişleri, hangi personelin verdiği, kitapları alış ve iade tarihlerinin listelenmesi
        public ActionResult KitapGecmisi(int id)
        {
            var deger = db.tblhareketler.Where(x => x.UYE == id).ToList();
            var uye = db.tbluyeler.Where(x => x.ID == id).Select(z => z.AD + " " + z.SOYAD).FirstOrDefault(); //seçilen üyenin 
            ViewBag.uyeadi = uye;
            return View(deger);
        }
    }
}