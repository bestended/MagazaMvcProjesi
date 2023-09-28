using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using MagazaMvcProjesi.Models;
namespace MagazaMvcProjesi.Controllers
{
    [AllowAnonymous]
    public class SecurityController : Controller
    {
        MagazaMvcProjemEntities db = new MagazaMvcProjemEntities();
        // GET: Security
        public ActionResult Login()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Login(Users user)
        {

            var sonuc = db.Userses.FirstOrDefault(i => i.kullaniciAdi == user.kullaniciAdi && i.sifre == user.sifre);
            if (sonuc != null)
            {
                FormsAuthentication.SetAuthCookie(sonuc.kullaniciAdi, true);
                return RedirectToAction("Index", "Admin");

            }
            else
            {
                ViewBag.Mesaj = "Kullanıcı adı veya şifre Hatalı";
                return View();
            }


        }

        public ActionResult Logout()
        {

            FormsAuthentication.SignOut();
            return View();
        }


    }
}