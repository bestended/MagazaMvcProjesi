using MagazaMvcProjesi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MagazaMvcProjesi.Controllers
{
    [Authorize(Roles ="A")]
    public class LaptopController : Controller
    {
        // GET: Laptop
        MagazaMvcProjemEntities db = new MagazaMvcProjemEntities();
        // GET: Televizyon
        public ActionResult Liste(string searchBy,string search)
        {

            if (searchBy== "color")
            {
                return View(db.Laptops.Where(i => i.color == search || search == null).ToList());
            }
            else
            {
                return View(db.Laptops.Where(i=>i.operatingSystem==search || search==null).ToList());
            }


           
        }

        public ActionResult Ekle()
        {


            List<SelectListItem> veriler = (from x in db.Dealers.ToList()
                                            select new SelectListItem
                                            {
                                                Text = x.dealerId.ToString(),
                                                Value = x.dealerId.ToString()

                                            }).ToList();

            ViewBag.veri = veriler;



            List<SelectListItem> datalar = (from i in db.Customers.ToList()
                                            select new SelectListItem
                                            {
                                                Text = i.customerId.ToString(),
                                                Value = i.customerId.ToString()

                                            }).ToList();

            ViewBag.data = datalar;


            return View();


        }

        [HttpPost]
        public ActionResult Ekle(Laptop laptop)
        {
            try
            {
                db.Laptops.Add(laptop);
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
            List<SelectListItem> veriler = (from x in db.Dealers.ToList()
                                            select new SelectListItem
                                            {
                                                Text = x.dealerId.ToString(),
                                                Value = x.dealerId.ToString()

                                            }).ToList();

            ViewBag.veri = veriler;



            List<SelectListItem> datalar = (from i in db.Customers.ToList()
                                            select new SelectListItem
                                            {
                                                Text = i.customerId.ToString(),
                                                Value = i.customerId.ToString()

                                            }).ToList();

            ViewBag.data = datalar;


            var result = db.Laptops.Find(id);
            return View(result);




        }
        [HttpPost]
        public ActionResult Güncelle(int id, Laptop laptop)
        {
            try
            {
                db.Entry(laptop).State = System.Data.Entity.EntityState.Modified;
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
            var result = db.Laptops.Find(id);
            return View(result);


        }
        [HttpPost]
        public ActionResult Sil(int id, Laptop laptop)
        {

            try
            {
                var result = db.Laptops.Find(id);
                db.Laptops.Remove(result);
                db.SaveChanges();
                return RedirectToAction("Liste");
            }
            catch
            {

                return View();
            }


        }

    }
}