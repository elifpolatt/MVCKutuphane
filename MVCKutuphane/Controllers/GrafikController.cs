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
    public class GrafikController : Controller
    {

        // GET: Grafik
        //Admin paneli chartlar
        //Kitap - yayınevi oranlarını görmek için
        public ActionResult Index()
        {
            return View();
        }
        //Kitapları görüntelemek için
        public ActionResult KitapResult()
        {
            return Json(liste());

        }
        public List<istatistikler> liste()
        {
            List<istatistikler> nesne = new List<istatistikler>();
            nesne.Add(new istatistikler()
            {
                yayinevi = "Güneş",
                kitapsayisi = 4
            });
            nesne.Add(new istatistikler()
            {
                yayinevi = "dünya",
                kitapsayisi = 7
            });
            nesne.Add(new istatistikler()
            {
                yayinevi = "mars",
                kitapsayisi = 3
            });
            return nesne;
        }
    }
}