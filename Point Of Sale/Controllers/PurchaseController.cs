using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Point_Of_Sale.Controllers
{
    public class PurchaseController : Controller
    {
        POS_WebEntities db = new POS_WebEntities();

        public ActionResult Index()
        {
            ViewBag.CategoryList = db.Categories.ToList();
            return View();
        }

        public JsonResult getProductCategories()
        {
            List<Category> categories = new List<Category>();
            using (POS_WebEntities dc = new POS_WebEntities())
            {
                categories = dc.Categories.OrderBy(ct => ct.CategoryName).ToList();
            }

            return new JsonResult { Data = categories, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        public JsonResult getProducts(int categoryId)
        {
            db.Configuration.ProxyCreationEnabled = false;
            var productList = db.Products.Where(p => p.ID == categoryId).ToList();
            return Json(productList, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult save(Customer customer)
        {
            bool status = false;
            DateTime dateOrg;
            var isValidDate = DateTime.TryParseExact(customer.OrderDateString, "mm-dd-yyyy", null, System.Globalization.DateTimeStyles.None, out dateOrg);
            if (isValidDate)
            {
                customer.OrderDate = dateOrg;
            }

            var isValidModel = TryUpdateModel(customer);
            if (isValidModel)
            {
                using (POS_WebEntities dc = new POS_WebEntities())
                {
                    dc.Customers.Add(customer);
                    dc.SaveChanges();
                    status = true;
                }
            }

            return new JsonResult { Data = new { status = status } };
        }
    }
}
   