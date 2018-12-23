using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Point_Of_Sale.Models;

namespace Point_Of_Sale.Controllers
{
    public class CustomerAndPurchaseController : Controller
    {
        // GET: CustomerAndPurchase
        public ActionResult Index()
        {
            if (Session["type"] == null || Session["type"].ToString() == "")
            {
                Session["DefaultView"] = "Index";
                Session["DefaultControll"] = "CustomerAndPurchase";
                return RedirectToAction("Login", "Employee");
            }

            return View();
        }

        [HttpPost]
        public JsonResult AddCustomerPurchase(CustomerAndPurchaseViewModel customerAndPurchaseViewModel)
        {    
            bool status = false;

            var isValidModel = TryUpdateModel(customerAndPurchaseViewModel);
            if (isValidModel)
            {
                using (POS_WebEntities db = new POS_WebEntities())
                {
                    Customer customer = new Customer()
                    {
                        CustomerName = customerAndPurchaseViewModel.CustomerName,
                        OrderNumber = customerAndPurchaseViewModel.OrderNumber,
                        Date = customerAndPurchaseViewModel.Date,
                        Description = customerAndPurchaseViewModel.Description
                    };
                    db.Customers.Add(customer);

                    if (db.SaveChanges() > 0)
                    {
                        int customerID = db.Customers.Max(c => c.ID);

                        foreach (var item in customerAndPurchaseViewModel.Items)
                        {
                            Purchase purchase = new Purchase()
                            {
                                CustomerID = customerID,
                                ProductID = item.ProductID,
                                Price = item.Price,
                                Quantity = item.Quantity,
                                TotalPrice = item.TotalPrice
                            };
                            db.Purchases.Add(purchase);
                        }
                        if (db.SaveChanges() > 0)
                        {
                            return new JsonResult { Data = new { status = status, message = "Purchase added successfully" } };
                        }
                    }
                }
            }
            status = false;
            return new JsonResult { Data = new { status = status, message = "Error !!" } };
        }
    }
}