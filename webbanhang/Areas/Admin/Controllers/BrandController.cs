using webbanhang.Context;
using PagedList;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static webbanhang.ListtoDataTableConverter;

namespace webbanhang.Areas.Admin.Controllers
{
    public class BrandController : Controller
    {
        webbanhangEntities objwebbanhangEntities = new webbanhangEntities();

        // GET: Admin/Brand
        public ActionResult Index(string currenFiter, string SearchString, int? page)
        {
            var lstBrand = new List<Brand>();
            if (SearchString != null)
            {
                page = 1;
            }
            else
            {
                SearchString = currenFiter;
            }
            if (!string.IsNullOrEmpty(SearchString))
            {
                lstBrand = objwebbanhangEntities.Brands.Where(n => n.Name.Contains(SearchString)).ToList();
            }
            else
            {
                lstBrand = objwebbanhangEntities.Brands.ToList();
            }
            ViewBag.currenFiter = SearchString;
            int pageSize = 4;
            int pageName = (page ?? 1);
            lstBrand = lstBrand.OrderByDescending(n => n.Id).ToList();
            return View(lstBrand.ToPagedList(pageName, pageSize));
        }
        [HttpGet]
        public ActionResult Create()
        {
            //this.LoadData();

            return View();
        }
        [ValidateInput(false)]
        [HttpPost]
        public ActionResult Create(Brand objBra)
        {
            //this.LoadData();

            if (ModelState.IsValid)
            {
                try
                {

                    if (objBra.ImageUpLoat != null)
                    {
                        string fileName = Path.GetFileNameWithoutExtension(objBra.ImageUpLoat.FileName);
                        string extension = Path.GetExtension(objBra.ImageUpLoat.FileName);
                        fileName = fileName + extension;
                        objBra.Avatar = fileName;
                        objBra.ImageUpLoat.SaveAs(Path.Combine(Server.MapPath("~/Content/images/items"), fileName));
                    }
                    objwebbanhangEntities.Brands.Add(objBra);
                    objwebbanhangEntities.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch (Exception)
                {
                    return RedirectToAction("Index");
                }

            }
            return View(objBra);
        }
        [HttpGet]
        public ActionResult Details(int id)
        {
            var objBrand = objwebbanhangEntities.Brands.Where(n => n.Id == id).FirstOrDefault();
            return View(objBrand);
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var objBrand = objwebbanhangEntities.Brands.Where(n => n.Id == id).FirstOrDefault();
            return View(objBrand);
        }
        [HttpPost]
        public ActionResult Edit(int id, Brand objBrand)
        {
            if (objBrand.ImageUpLoat != null)
            {
                string filename = Path.GetFileNameWithoutExtension(objBrand.ImageUpLoat.FileName);
                string extention = Path.GetExtension(objBrand.ImageUpLoat.FileName);
                filename = filename + "_" + long.Parse(DateTime.Now.ToString("yyyyMMddhhmmss")) + extention;
                objBrand.Avatar = filename;
                objBrand.ImageUpLoat.SaveAs(Path.Combine(Server.MapPath("~/Content/images/items"), filename));
            }
            objwebbanhangEntities.Entry(objBrand).State = System.Data.Entity.EntityState.Modified;
            objwebbanhangEntities.SaveChanges();
            return View(objBrand);
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var objBrand = objwebbanhangEntities.Brands.Where(n => n.Id == id).FirstOrDefault();
            return View(objBrand);
        }
        [HttpPost]
        public ActionResult Delete(Brand objBr)
        {
            var objBrand = objwebbanhangEntities.Brands.Where(n => n.Id == objBr.Id).FirstOrDefault();

            objwebbanhangEntities.Brands.Remove(objBr);
            objwebbanhangEntities.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}