using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using MVCKutuphane.Models;


namespace MVCKutuphane.Controllers
{
    public class istatistikController : Controller
    {
        // GET: istatistik
        KutuphaneDBEntities2 db = new KutuphaneDBEntities2();
        //Admin paneli işlemler sayfası
        public ActionResult Index()
        {
            var uyesayisi = db.tbluyeler.Count();
            var kitapsayisi = db.tblkitaplar.Count();
            var emanetkitaplar = db.tblkitaplar.Where(x => x.DURUM == false).Count(); //durumu false olanlar sayılıyor.
            var toplamtutar = db.tblcezalar.Sum(x => x.PARA); //kasada biriken tutar
            ViewBag.toplamuye = uyesayisi;
            ViewBag.toplamkitap = kitapsayisi;
            ViewBag.emanetkitap = emanetkitaplar;
            ViewBag.tutar = toplamtutar;
            return View();
        }
        //Admin paneli kütüphane hava durumu
        public ActionResult Hava() 
        { 
            return View(); 
        }
        //Admin paneli hava durumu kartları
        public ActionResult HavaKart()
        {
            return View();
        }
        //Admin paneli resim yukleme işlemi için galeri (get)
        //Galeri sayfası
        public ActionResult Galeri()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ResimYukle(HttpPostedFileBase dosya)
        {
            if (dosya.ContentLength > 0) //dosya nulldan farklıysa
            {
                string dosyayolu=Path.Combine(Server.MapPath("/web2/resimler/"),Path.GetFileName(dosya.FileName));
                dosya.SaveAs(dosyayolu); //dosya yolundan gelen dosyayı farklı bir şekilde kaydet
            }
            return RedirectToAction("Galeri");
        }
        //Linq kartlar sayfası
        public ActionResult LinqKart()
        {
            var kitapsayisi = db.tblkitaplar.Count();
            var uyesayisi = db.tbluyeler.Count();
            var toplamtutar = db.tblcezalar.Sum(x=>x.PARA);
            var emanetkitaplar = db.tblkitaplar.Where(x => x.DURUM == false).Count();
            var kategorisayisi = db.tblkategoriler.Count();
            var enaktifuye = db.EnAktifUye1().FirstOrDefault();
            var encokokunankitap = db.EnFazlaOkunanKitap1().FirstOrDefault();
            var encokkitabiolanyazar = db.EnFazlaKitabiOlanYazar1().FirstOrDefault();
             var eniyiyayinevi = db.tblkitaplar.GroupBy(x => x.YAYINEVI).OrderByDescending
                (z => z.Count()).Select(y => y.Key).FirstOrDefault();
            var enbasarilipersonel = db.EnBasariliPersonel().FirstOrDefault();
            var mesajsayisi = db.tbliletisim.Count();
            var bugunverilenkitaplar = db.tblhareketler.Where(x => x.ALISTARIH == DateTime.Today).Select(y => y.KITAP).Count();
            ViewBag.toplamkitap = kitapsayisi;
            ViewBag.toplamuye = uyesayisi;
            ViewBag.tutar = toplamtutar;
            ViewBag.emanetkitap = emanetkitaplar;
            ViewBag.toplamkategori = kategorisayisi;
            ViewBag.aktifuye = enaktifuye;
            ViewBag.enfazlaokunankitap = encokokunankitap;
            ViewBag.enfazlakitabiolanyazar = encokkitabiolanyazar;
            ViewBag.enbasariliyayinevi = eniyiyayinevi;
            ViewBag.enbasarilipers = enbasarilipersonel;
            ViewBag.toplammesajsayisi = mesajsayisi;
            ViewBag.bugunkuemanetler = bugunverilenkitaplar;

            return View();
        }
    }
}
