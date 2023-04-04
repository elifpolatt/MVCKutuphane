using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using MVCKutuphane.Models;
namespace MVCKutuphane.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        // GET: Login
        KutuphaneDBEntities2 db = new KutuphaneDBEntities2();

        //Üye girişi
        [HttpGet]
        public ActionResult GirisYap()
        {
            return View();
        }
        [HttpPost]
        public ActionResult GirisYap(tbluyeler tu)
        {
            var deger = db.tbluyeler.FirstOrDefault(x => x.KULLANICIADI == tu.KULLANICIADI && x.SIFRE == tu.SIFRE);
            if(deger != null)
            {
                FormsAuthentication.SetAuthCookie(deger.KULLANICIADI, false);
                Session["KULLANICIADI"] = deger.KULLANICIADI.ToString();
                return RedirectToAction("Index", "Panel");
            }
            else { return View();  }
            
        }
    }
}