using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using webbanhang.Context;

namespace webbanhang.Controllers
{
    public class CategoryController : Controller
    {
        webbanhangEntities objwebbanhangEntities = new webbanhangEntities();
        // GET: Category
        public ActionResult Index()
        {
            var lstCategory = objwebbanhangEntities.Categories.ToList();
            return View(lstCategory);
        }
        public ActionResult ProductCategory(int id)
        {
            var listProduct = objwebbanhangEntities.Products.Where(n => n.Categoryid == id).ToList();
            return View(listProduct);
        }
    }
}