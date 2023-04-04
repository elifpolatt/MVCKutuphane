using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCKutuphane.Models;
namespace MVCKutuphane.Controllers
{
    public class islemController : Controller
    {
        // GET: islem
        KutuphaneDBEntities2 db = new KutuphaneDBEntities2();
        //Admin paneli
        //İadesi alınan kitapların listesi. (işlemdurumu = true)
        public ActionResult Index()
        {
            var kitaplar = db.tblhareketler.Where(x => x.ISLEMDURUM == true).ToList();
            return View(kitaplar);
        }
    }
}