using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCKutuphane.Models;
using MVCKutuphane.Models.Siniflarim;
namespace MVCKutuphane.Controllers
{
    [AllowAnonymous]
    public class VitrinController : Controller
    {
        KutuphaneDBEntities2 db = new KutuphaneDBEntities2();
        
        //Vitrin paneli 
        //Tek sayfada birden fazla tablodan veri çekme işlemi IEnumerable yapıldı.
        //Index sayfasında foreach döngüsünde hakkımızda kısmı ve kitap resimlerini çekmek için kullanıldı.
        [HttpGet]
        public ActionResult Index()
        {
            Vitrin cs = new Vitrin();
            cs.kitapresim = db.tblkitaplar.ToList();
            cs.hakkimizda = db.tblhakkimizda.ToList();
            //var deger = db.tblkitaplar.ToList();
            return View(cs);
        }
        [HttpPost]
        public ActionResult Index(tbliletisim i)
        {
            db.tbliletisim.Add(i);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}