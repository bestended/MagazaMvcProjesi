using MagazaMvcProjesi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MagazaMvcProjesi.Controllers
{
    [Authorize(Roles ="A,U")]
    public class MüsterilerController : Controller
    {
        MagazaMvcProjemEntities db = new MagazaMvcProjemEntities();
       
        public ActionResult Liste(string x)
        {

            var satir = from a in db.Customers
                        select a;

            if (x!=null)
            {

                satir=satir.Where(i => i.Name.Contains(x));

            }
            return View(satir.ToList());

            //var result = db.Customers.ToList();
            //return View(result);
        }

        public ActionResult Ekle()
        {

            return View();


        }

        [HttpPost]
        public ActionResult Ekle(Customer customer)
        {
            try
            {
                db.Customers.Add(customer);
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
            var sonuc = db.Customers.Find(id);
            return View(sonuc);


        }

        [HttpPost]
        public ActionResult Güncelle(int id, Customer customer)
        {
            try
            {
                db.Entry(customer).State = System.Data.Entity.EntityState.Modified;
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
            var sonuc = db.Customers.Find(id);
            return View(sonuc);



        }

        [HttpPost]
        public ActionResult Sil(int id, Customer customer)
        {
            var sonuc = db.Customers.Find(id);
            db.Customers.Remove(sonuc);
            db.SaveChanges();
            return RedirectToAction("Liste");


        }

    }
}