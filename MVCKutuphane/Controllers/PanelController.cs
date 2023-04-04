using MVCKutuphane.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;

namespace MVCKutuphane.Controllers
{
    [Authorize]
    public class PanelController : Controller

    {
        // GET: Panel
        KutuphaneDBEntities2 db = new KutuphaneDBEntities2();
        //Üye Paneli
        [HttpGet]
        public ActionResult Index()
        {

            var uyeadi = (string)Session["KULLANICIADI"];
            var degerler = db.tblduyurular.ToList();
            //var degerler = db.tbluyeler.FirstOrDefault(x => x.KULLANICIADI == uyeadi);
            var uyead = db.tbluyeler.Where(x => x.KULLANICIADI == uyeadi).Select(y => y.AD).FirstOrDefault();
            var uyesoyad = db.tbluyeler.Where(x => x.KULLANICIADI == uyeadi).Select(y => y.SOYAD).FirstOrDefault();
            var uyemail = db.tbluyeler.Where(x => x.KULLANICIADI == uyeadi).Select(y => y.MAIL).FirstOrDefault();
            var uyeokul = db.tbluyeler.Where(x => x.KULLANICIADI == uyeadi).Select(y => y.OKUL).FirstOrDefault();
            var uyetelefon = db.tbluyeler.Where(x => x.KULLANICIADI == uyeadi).Select(y => y.TELEFON).FirstOrDefault();
            var uyeid = db.tbluyeler.Where(x => x.KULLANICIADI == uyeadi).Select(y => y.ID).FirstOrDefault();
            var okunankitap = db.tblhareketler.Where(x => x.UYE == uyeid).Count();
            var gelenmesaj = db.tblmesajlar.Where(x => x.ALICI == uyeadi).Count();
            var duyuru = db.tblduyurular.Count();

            ViewBag.uyeisim = uyead;
            ViewBag.uyesoyisim = uyesoyad;
            ViewBag.uyemaili = uyemail;
            ViewBag.uyeokulu = uyeokul;
            ViewBag.uyetelefonu = uyetelefon;
            ViewBag.okunankitapsayisi = okunankitap;
            ViewBag.gelenmsj = gelenmesaj;
            ViewBag.duyurular = duyuru;
            return View(degerler);
        }
        [HttpPost]
        public ActionResult Index(tbluyeler tu)
        {
            var kullanici = (string)Session["kullaniciadi"];
            var uye = db.tbluyeler.FirstOrDefault(m => m.KULLANICIADI == kullanici);
            uye.SIFRE = tu.SIFRE;
            uye.AD = tu.AD;
            uye.OKUL = tu.OKUL;
            uye.MAIL = tu.MAIL;
            uye.SOYAD = tu.SOYAD;
            uye.FOTOGRAF = tu.FOTOGRAF;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        //Üyenin okuduğu kitapların tarihleriyle verilmesi
        public ActionResult Kitaplarim()
        {
            var kullanici = (string)Session["kullaniciadi"];
            var id = db.tbluyeler.Where(x => x.KULLANICIADI == kullanici.ToString()).Select(z => z.ID).FirstOrDefault();
            var deger = db.tblhareketler.Where(x => x.UYE == id).ToList();
            return View(deger);
        }
        
       
        //public ActionResult Duyurular()
        //{
        //    var dlistesi = db.tblduyurular.ToList();
        //    return View(dlistesi);
        //}


        //Üye paneli çıkış yapma işlemi
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("GirisYap","Login"); 
        }
        //Üye paneli duyurular bölümü
        public PartialViewResult DuyurularPartial()
        {
            var degerler = db.tblduyurular.ToList();
            return PartialView(degerler);
          
        }
        //Üye paneli ayarlar bölümü
        public PartialViewResult AyarlarPartial()
        {
            var kullaniciadi = (string)Session["kullaniciadi"];
            var id = db.tbluyeler.Where(x => x.KULLANICIADI == kullaniciadi).Select(y => y.ID).FirstOrDefault();
            var uyebul = db.tbluyeler.Find(id);
            return PartialView("AyarlarPartial", uyebul);
           
        }
    }
}