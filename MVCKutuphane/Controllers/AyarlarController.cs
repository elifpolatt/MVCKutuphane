using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCKutuphane.Models;
namespace MVCKutuphane.Controllers
{
    [Authorize(Roles = "A")]
    public class AyarlarController : Controller
    {
        // GET: Ayarlar
        KutuphaneDBEntities2 db = new KutuphaneDBEntities2();
        
        //Admin paneli ayarlar sayfası
        public ActionResult Index()
        {
            var admin = db.tbladmin.ToList();
            return View(admin);
        }
      
       
        //Yeni admin ekleme işlemi (get)
        public ActionResult YeniAdmin()
        {
            return View();
        }
        //Yeni admin ekleme işlemi (post)
        //Sayfada bir işlem yapıldığında çalışacak
        [HttpPost]
        public ActionResult YeniAdmin(tbladmin t)
        {
            db.tbladmin.Add(t);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //Admin silme işlemi id değerinin bulunmasıyla yapılacak
        public ActionResult AdminSil(int id)
        {
            var adminsil = db.tbladmin.Find(id);
            db.tbladmin.Remove(adminsil);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //Admin getir ve güncelle 
        public ActionResult AdminGetir(int id)
        {
            var admin = db.tbladmin.Find(id);
            return View("AdminGetir",admin);
        }

        public ActionResult AdminGuncelle(tbladmin t)
        {
            var admin = db.tbladmin.Find(t.ID);
            admin.KULLANICI = t.KULLANICI;
            admin.SIFRE = t.SIFRE;
            admin.YETKI = t.YETKI;
            db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}