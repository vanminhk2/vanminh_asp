using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using webbanhang.Context;
using webbanhang.Models;

namespace webbanhang.Controllers
{
    public class PaymentController : Controller
    {
        webbanhangEntities objwebbanhangEntities = new webbanhangEntities();

        public string intOrderId { get; private set; }

        // GET: Payment
        public ActionResult Index()
        {

            if (Session["idUser"] == null)
            {
                return RedirectToAction("Login", "Home");
            }
            else
            {
                var lstCart = (List<CartModel>)Session["cart"];
                Order objOrder = new Order();
                objOrder.Name = "DonHang" + DateTime.Now.ToString("yyyyMMddHHss");
                objOrder.Id = int.Parse(Session["idUser"].ToString());
                objOrder.CreatedOnUtc = DateTime.Now;
                objOrder.Status = 1;
                objwebbanhangEntities.Orders.Add(objOrder);
                objwebbanhangEntities.SaveChanges();

                int intOrder = objOrder.Id;
                List<OderDatail> lstOderDatail = new List<OderDatail>();
                foreach (var item in lstCart)
                {
                    OderDatail obj = new OderDatail();
                    obj.Quantity = item.Quantity;
                    obj.OrderId = intOrderId;
                    obj.ProductId = item.ProductId;
                    lstOderDatail.Add(obj);
                }
                objwebbanhangEntities.OderDatails.AddRange(lstOderDatail);
                objwebbanhangEntities.SaveChanges();

            }
            return View();
        }
    }
}