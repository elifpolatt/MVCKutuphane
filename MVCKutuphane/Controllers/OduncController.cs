using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCKutuphane.Models;

namespace MVCKutuphane.Controllers
{
    public class OduncController : Controller
    {
        // GET: Odunc
        KutuphaneDBEntities2 db = new KutuphaneDBEntities2();
        //Ödünç verilen kitaplar listelenmesi 
        public ActionResult Index()
        {
            var deger = db.tblhareketler.Where(x=>x.ISLEMDURUM == false).ToList();
            //Ödünç olarak verilen kitabın durumu false olur. False olanları listeledik.
            return View(deger);
        }
        //Ödünç verilecek kitabın hangi üyeye hangi kitabın hangi personel tarafından verileceğinin dropdown listten çekilmesi
        [HttpGet]
        public ActionResult OduncVer()
        {
            List<SelectListItem> uyeler = (from i in db.tbluyeler.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.AD + " " + i.SOYAD,
                                               Value = i.ID.ToString(),
                                           }).ToList();
            ViewBag.uyesec = uyeler;

            //Kitaplardan sadece kimse tarafından alınmayanların çekilmesi (durum == true )
            List<SelectListItem> kitaplar = (from i in db.tblkitaplar.Where(x=>x.DURUM == true).ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.AD,
                                               Value = i.ID.ToString(),
                                           }).ToList();
            ViewBag.kitapsec = kitaplar;

            List<SelectListItem> personeller = (from i in db.tblpersoneller.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.PERSONEL,
                                               Value = i.ID.ToString()
                                           }).ToList();
            ViewBag.personelsec = personeller;
            return View();
        }
        [HttpPost]
        public ActionResult OduncVer(tblhareketler h)
        {
            var uye = db.tbluyeler.Where(x => x.ID == h.tbluyeler.ID).FirstOrDefault();
            var kitap = db.tblkitaplar.Where(x => x.ID == h.tblkitaplar.ID).FirstOrDefault();
            var personel = db.tblpersoneller.Where(x => x.ID == h.tblpersoneller.ID).FirstOrDefault();
            h.tbluyeler = uye;
            h.tblkitaplar = kitap;
            h.tblpersoneller = personel;
            db.tblhareketler.Add(h);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        //Geç gelen gün sayısının hesaplanması
        public ActionResult Odunciade(tblhareketler h)
        {
            var deger = db.tblhareketler.Find(h.ID);
            DateTime iadetarihi = DateTime.Parse(deger.IADETARIH.ToString());
            DateTime bugununtarihi = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            TimeSpan gecgelengun = bugununtarihi - iadetarihi;
            ViewBag.gecgun = gecgelengun.TotalDays;
            return View("Odunciade",deger);
        }

        public ActionResult OduncGuncelle(tblhareketler h)
        {
            var deger = db.tblhareketler.Find(h.ID);
            //deger.PERSONEL = th.PERSONEL;
            deger.ISLEMDURUM = true;
            //deger.ALISTARIH = th.ALISTARIH;
            //deger.IADETARIH = th.IADETARIH;
            deger.UYEGETIRTARIH = h.UYEGETIRTARIH;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}