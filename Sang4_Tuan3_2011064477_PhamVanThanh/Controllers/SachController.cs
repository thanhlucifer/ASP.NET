using Sang4_Tuan3_2011064477_PhamVanThanh.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sang4_Tuan3_2011064477_PhamVanThanh.Controllers
{
    public class SachController : Controller
    {
        MyDataDataContext data = new MyDataDataContext();
        // GET: Sach
        public ActionResult Index()
        {
            var all_Sach = from aa in data.Saches select aa;
            return View(all_Sach);
        }
        public ActionResult Detail(int id)
        {
            var D_sach = data.Saches.Where(m => m.masach == id).First();
            return View(D_sach);
        }
        //-------------Create-------------------
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(FormCollection collection, Sach s)
        {
            var ten = collection["tensach"];
            if (string.IsNullOrEmpty(ten))
            {
                ViewData["Error"] = "Don't empty!";
            }
            else
            {
                s.tensach = ten;
                data.Saches.InsertOnSubmit(s);
                data.SubmitChanges();
                return RedirectToAction("Index");
            }
            return this.Create();
        }
        public ActionResult Edit(int id)
        {
            var E_category = data.TheLoais.First(m => m.maloai == id);
            return View(E_category);
        }
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            var sach = data.Saches.First(m => m.masach == id);
            var E_tensach = collection["tensach"];
            sach.masach = id;
            if (string.IsNullOrEmpty(E_tensach))
            {
                ViewData["Error"] = "Don't empty!";
            }
            else
            {
                sach.tensach = E_tensach;
                UpdateModel(sach);
                data.SubmitChanges();
                return RedirectToAction("Index");
            }
            return this.Edit(id);
        }

        public ActionResult Delete(int id)
        {
            var D_sach = data.Saches.First(m => m.masach == id);
            return View(D_sach);
        }
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            var D_sach = data.Saches.Where(m => m.masach == id).First();
            data.Saches.DeleteOnSubmit(D_sach);
            data.SubmitChanges();
            return RedirectToAction("Index");
        }
    }
}