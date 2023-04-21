using webbanhang.Context;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace webbanhang.Areas.Admin.Controllers
{
    public class orderController : Controller
    {
        webbanhangEntities objwebbanhangEntities = new webbanhangEntities();
        // GET: Admin/order
        public ActionResult Index(string currenFiter, string SearchString, int? page)
        {
            var lstod = new List<Order>();
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
                lstod = objwebbanhangEntities.Orders.Where(n => n.Name.Contains(SearchString)).ToList();
            }
            else
            {
                lstod = objwebbanhangEntities.Orders.ToList();
            }
            ViewBag.currenFiter = SearchString;
            int pageSize = 4;
            int pageName = (page ?? 1);
            lstod = lstod.OrderByDescending(n => n.Id).ToList();
            return View(lstod.ToPagedList(pageName, pageSize));
        }
    }
}