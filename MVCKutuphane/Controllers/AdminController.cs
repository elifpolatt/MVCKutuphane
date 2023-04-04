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
    public class AdminController : Controller
    {
        // GET: Admin
        KutuphaneDBEntities2 db = new KutuphaneDBEntities2();
       
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        //Admin Login işlemi
        public ActionResult Index(tbladmin a)
        {
            
            var bilgiler = db.tbladmin.FirstOrDefault(x => x.KULLANICI == a.KULLANICI && x.SIFRE == a.SIFRE); 
            if(bilgiler != null)  //Adminin kullanıcı adı ve şifresi veri tabanındakiyle aynıysa (boş değilse)
            {
                FormsAuthentication.SetAuthCookie(bilgiler.KULLANICI, false);
                Session["Kullanici"] = bilgiler.KULLANICI.ToString();
                return RedirectToAction("Index", "istatistik");
            }
            else
            {

                return View();
            }
            
        }
        //admin logout işlemi
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("Index");
        }
    }
}