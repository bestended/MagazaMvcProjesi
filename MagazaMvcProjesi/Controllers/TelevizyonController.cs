using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MagazaMvcProjesi.Models;
namespace MagazaMvcProjesi.Controllers
{
    [Authorize(Roles ="A")]
    public class TelevizyonController : Controller
    {
        MagazaMvcProjemEntities db = new MagazaMvcProjemEntities();
        // GET: Televizyon
        public ActionResult Liste(string searchBy,string search)
        {
            if (searchBy== "energyClass")
            {
                return View(db.Televisions.Where(i=>i.energyClass==search || search==null).ToList());
            }
            else
            {
                return View(db.Televisions.Where(i=>i.color==search || search==null).ToList());
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
        public ActionResult Ekle(Television televizyon)
        {
            try
            {
                db.Televisions.Add(televizyon);
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

            var result = db.Televisions.Find(id);
            return View(result);




        }
        [HttpPost]
        public ActionResult Güncelle(int id,Television televizyon)
        {
            try
            {
                db.Entry(televizyon).State = System.Data.Entity.EntityState.Modified;
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
            var result = db.Televisions.Find(id);
            return View(result);


        }
        [HttpPost]
        public ActionResult Sil(int id,Television televizyon)
        {

            try
            {
                var result = db.Televisions.Find(id);
                db.Televisions.Remove(result);
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




