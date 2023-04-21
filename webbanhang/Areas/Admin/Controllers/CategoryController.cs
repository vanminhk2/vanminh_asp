using webbanhang.Context;
using PagedList;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace webbanhang.Areas.Admin.Controllers
{
    public class CategoryController : Controller
    {
        webbanhangEntities objwebbanhangEntities = new webbanhangEntities();

        // GET: Admin/Brand
        public ActionResult Index(string currenFiter, string SearchString, int? page)
        {
            var lstca = new List<Category>();
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
                lstca = objwebbanhangEntities.Categories.Where(n => n.Name.Contains(SearchString)).ToList();
            }
            else
            {
                lstca = objwebbanhangEntities.Categories.ToList();
            }
            ViewBag.currenFiter = SearchString;
            int pageSize = 4;
            int pageName = (page ?? 1);
            lstca = lstca.OrderByDescending(n => n.Id).ToList();
            return View(lstca.ToPagedList(pageName, pageSize));
        }
        [HttpGet]
        public ActionResult Create()
        {
            //this.LoadData();

            return View();
        }
        [ValidateInput(false)]
        [HttpPost]
        public ActionResult Create(Category objca)
        {
            //this.LoadData();

            if (ModelState.IsValid)
            {
                try
                {

                    if (objca.ImageUpLoat != null)
                    {
                        string fileName = Path.GetFileNameWithoutExtension(objca.ImageUpLoat.FileName);
                        string extension = Path.GetExtension(objca.ImageUpLoat.FileName);
                        fileName = fileName + extension;
                        objca.Avatar = fileName;
                        objca.ImageUpLoat.SaveAs(Path.Combine(Server.MapPath("~/Content/images/items/"), fileName));
                    }
                    objwebbanhangEntities.Categories.Add(objca);
                    objwebbanhangEntities.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch (Exception)
                {
                    return RedirectToAction("Index");
                }

            }
            return View(objca);
        }
        [HttpGet]
        public ActionResult Details(int id)
        {
            var objca = objwebbanhangEntities.Categories.Where(n => n.Id == id).FirstOrDefault();
            return View(objca);
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var objca = objwebbanhangEntities.Categories.Where(n => n.Id == id).FirstOrDefault();
            return View(objca);
        }
        [HttpPost]
        public ActionResult Edit(int id, Category objca)
        {
            if (objca.ImageUpLoat != null)
            {
                string filename = Path.GetFileNameWithoutExtension(objca.ImageUpLoat.FileName);
                string extention = Path.GetExtension(objca.ImageUpLoat.FileName);
                filename = filename + "_" + long.Parse(DateTime.Now.ToString("yyyyMMddhhmmss")) + extention;
                objca.Avatar = filename;
                objca.ImageUpLoat.SaveAs(Path.Combine(Server.MapPath("~/Content/images/items"), filename));
            }
            objwebbanhangEntities.Entry(objca).State = System.Data.Entity.EntityState.Modified;
            objwebbanhangEntities.SaveChanges();
            return View(objca);
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var objca = objwebbanhangEntities.Categories.Where(n => n.Id == id).FirstOrDefault();
            return View(objca);
        }
        [HttpPost]
        public ActionResult Delete(Category objca)
        {
            var objcate = objwebbanhangEntities.Brands.Where(n => n.Id == objca.Id).FirstOrDefault();

            objwebbanhangEntities.Categories.Remove(objca);
            objwebbanhangEntities.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}