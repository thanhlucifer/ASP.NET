﻿using Sang4_Tuan3_2011064477_PhamVanThanh.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace Sang4_Tuan3_2011064477_PhamVanThanh.Controllers
{
    public class TheLoaiController : Controller
    {
        //khai bao bien data de thuc hien cac thao tac
        MyDataDataContext data = new MyDataDataContext();
        // GET: TheLoai
        //Dung de lay the loai cua sach
        public ActionResult Index()
        {
            var all_TheLoai = from tt in data.TheLoais select tt;
            return View(all_TheLoai);
        }

        public ActionResult Detail(int id)
        {
            var D_theloai = data.TheLoais.Where(m => m.maloai == id).First();
            return View(D_theloai);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(FormCollection collection, TheLoai tl)
        {
            var ten = collection["tenloai"];
            if (string.IsNullOrEmpty(ten))
            {
                ViewData["Error"] = "Don't empty!";
            }
            else
            {
                tl.tenloai = ten;
                data.TheLoais.InsertOnSubmit(tl);
                data.SubmitChanges();
                return RedirectToAction("Index");
            }
            return this.Create();
        }
        //-------------Edit-------------------
        public ActionResult Edit(int id)
        {
            var E_category = data.TheLoais.First(m => m.maloai == id);
            return View(E_category);
        }
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            var theloai = data.TheLoais.First(m => m.maloai == id);
            var E_tenloai = collection["tenloai"];
            theloai.maloai = id;
            if (string.IsNullOrEmpty(E_tenloai))
            {
                ViewData["Error"] = "Don't empty!";
            }
            else
            {
                theloai.tenloai = E_tenloai;
                UpdateModel(theloai);
                data.SubmitChanges();
                return RedirectToAction("Index");
            }
            return this.Edit(id);
        }
        public ActionResult Delete(int id)
        {
            var D_theloai = data.TheLoais.First(m => m.maloai == id);
            return View(D_theloai);
        }
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            var D_theloai = data.TheLoais.Where(m => m.maloai == id).First();
            data.TheLoais.DeleteOnSubmit(D_theloai);
            data.SubmitChanges();
            return RedirectToAction("Index");
        }
    }
 }