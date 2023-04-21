using System.Linq;
using System.Web.Mvc;
using webbanhang.Context;

namespace webbanhang.Controllers
{
    public class ProductController : Controller
    {
        webbanhangEntities objwebbanhangEntities = new webbanhangEntities();

        // GET: Product
        public ActionResult Detail(int Id)
        {
            var objProduct = objwebbanhangEntities.Products.Where(n => n.Id == Id).FirstOrDefault();
            return View(objProduct);
        }
    }
}