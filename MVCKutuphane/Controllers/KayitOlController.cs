using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCKutuphane.Models;

namespace MVCKutuphane.Controllers
{
    [AllowAnonymous]
    public class KayitOlController : Controller
    {
        // GET: KayitOl
        KutuphaneDBEntities2 db = new KutuphaneDBEntities2();

        //Kütüphane kayıt paneli
        [HttpGet]
        public ActionResult Kayit()
        {
            return View();
        }
        [HttpPost]

        public ActionResult Kayit(tbluyeler p)
        {
            if (!ModelState.IsValid)
            {
                return View("Kayit");

            }
            db.tbluyeler.Add(p);
            db.SaveChanges();
            return View();
        }
    }
}