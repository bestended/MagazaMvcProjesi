using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using MagazaMvcProjesi.Models;
namespace MagazaMvcProjesi.Controllers
{
    [Authorize(Roles ="A,U")]
    public class BayilerController : Controller
    {
        MagazaMvcProjemEntities db = new MagazaMvcProjemEntities();
        
       

        public ActionResult Liste(string x)
        {
            var sonuc = from a in db.Dealers
                        select a;

            if (x != null)
            {

                sonuc = sonuc.Where(i => i.dealerName.Contains(x));

            }

            return View(sonuc.ToList());




            //var result = db.Dealers.ToList();
            //return View(result);
        }

        public ActionResult Ekle()
        {

            return View();


        }

        [HttpPost]
        public ActionResult Ekle(Dealer dealer)
        {
            try
            {
                db.Dealers.Add(dealer);
                db.SaveChanges();
                return RedirectToAction("Liste");
            }
            catch
            {

                return View();
            }
            




        }


        public ActionResult Güncelle(int id)
        {
            var sonuc=db.Dealers.Find(id);
            return View(sonuc);
            

        }

        [HttpPost]
        public ActionResult Güncelle(int id,Dealer dealer)
        {
            try
            {
                db.Entry(dealer).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Liste");

            }
            catch 
            {

                return View();
            }
          
        }

        public ActionResult Sil(int id)
        {
            var sonuc = db.Dealers.Find(id);
            return View(sonuc);



        }

        [HttpPost]
        public ActionResult Sil(int id,Dealer dealer)
        {
            var sonuc = db.Dealers.Find(id);
            db.Dealers.Remove(sonuc);
            db.SaveChanges();
            return RedirectToAction("Liste");


        }


    }
}