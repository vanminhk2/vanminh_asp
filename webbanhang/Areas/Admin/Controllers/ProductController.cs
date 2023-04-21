using PagedList;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web.Mvc;
using webbanhang.Context;
using static webbanhang.Commom;
using static webbanhang.Commom.ListtoDataTableConverter;
using static webbanhang.ListtoDataTableConverter;

namespace webbanhang.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {
        webbanhangEntities objwebbanhangEntities = new webbanhangEntities();

        // GET: Admin/Product
        public ActionResult Index(string currenFiter, string SearchString, int? page)
        {
            var lstproduct = new List<Product>();
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
                lstproduct = objwebbanhangEntities.Products.Where(n => n.Name.Contains(SearchString)).ToList();
            }
            else
            {
                lstproduct = objwebbanhangEntities.Products.ToList();
            }
            ViewBag.currenFiter = SearchString;
            int pageSize = 4;
            int pageName = (page ?? 1);
            lstproduct = lstproduct.OrderByDescending(n => n.Id).ToList();
            return View(lstproduct.ToPagedList(pageName, pageSize));
        }
        [HttpGet]
        public ActionResult Create()
        {
            Commom objCommom = new Commom();
            var lstCat = objwebbanhangEntities.Categories.ToList();
            ListtoDataTableConverter converter = new ListtoDataTableConverter();
            DataTable dtCategory = converter.ToDataTable(lstCat);
            ViewBag.ListCategory = objCommom.ToSlectList(dtCategory, "id", "name");
            var lstBrand = objwebbanhangEntities.Brands.ToList();
            DataTable dtBrand = converter.ToDataTable(lstBrand);
            ViewBag.ListBrand = objCommom.ToSlectList(dtBrand, "id", "name");


            List<ProductType> lstproductType = new List<ProductType>();
            ProductType objProductType = new ProductType();
            objProductType.id = 1;
            objProductType.name = "Giảm Giá Sốc";
            lstproductType.Add(objProductType);

            objProductType = new ProductType();
            objProductType.id = 2;
            objProductType.name = "Đề Xuất";
            lstproductType.Add(objProductType);

            DataTable dtProductType = converter.ToDataTable(lstproductType);
            ViewBag.ProductType = objCommom.ToSlectList(dtProductType, "id", "name");
            return View();
        }
        [ValidateInput(false)]
        [HttpPost]
        public ActionResult Create(Product objProduct)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (objProduct.ImageUpLoat != null)
                    {
                        string filename = Path.GetFileNameWithoutExtension(objProduct.ImageUpLoat.FileName);
                        string extention = Path.GetExtension(objProduct.ImageUpLoat.FileName);
                        filename = filename + "_" + long.Parse(DateTime.Now.ToString("yyyyMMddhhmmss")) + extention;
                        objProduct.Avatar = filename;
                        objProduct.ImageUpLoat.SaveAs(Path.Combine(Server.MapPath("~/Content/images/items"), filename));

                    }
                    objwebbanhangEntities.Products.Add(objProduct);
                    objwebbanhangEntities.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch
                {
                    return View();
                }
            }
            return View(objProduct);
        }
        [HttpGet]
        public ActionResult Details(int id)
        {
            var objProduct = objwebbanhangEntities.Products.Where(n => n.Id == id).FirstOrDefault();
            return View(objProduct);
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var objProduct = objwebbanhangEntities.Products.Where(n => n.Id == id).FirstOrDefault();
            return View(objProduct);
        }
        [HttpPost]
        public ActionResult Delete(Product objPro)
        {
            var objProduct = objwebbanhangEntities.Products.Where(n => n.Id == objPro.Id).FirstOrDefault();

            objwebbanhangEntities.Products.Remove(objProduct);
            objwebbanhangEntities.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var objProduct = objwebbanhangEntities.Products.Where(n => n.Id == id).FirstOrDefault();
            return View(objProduct);
        }
        [HttpPost]
        public ActionResult Edit(int id, Product objProduct)
        {
            if (objProduct.ImageUpLoat != null)
            {
                string filename = Path.GetFileNameWithoutExtension(objProduct.ImageUpLoat.FileName);
                string extention = Path.GetExtension(objProduct.ImageUpLoat.FileName);
                filename = filename + "_" + long.Parse(DateTime.Now.ToString("yyyyMMddhhmmss")) + extention;
                objProduct.Avatar = filename;
                objProduct.ImageUpLoat.SaveAs(Path.Combine(Server.MapPath("~/Content/images/items"), filename));
            }
            objwebbanhangEntities.Entry(objProduct).State = System.Data.Entity.EntityState.Modified;
            objwebbanhangEntities.SaveChanges();
            return View(objProduct);
        }
    }
}