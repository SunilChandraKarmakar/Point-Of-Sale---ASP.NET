using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Point_Of_Sale.Models;

namespace Point_Of_Sale.Controllers
{
    public class CustomerAndPurchaseController : Controller
    {
        private POS_WebEntities _db = new POS_WebEntities();

        // GET: CustomerAndPurchase
        public ActionResult Index()
        {
            if (Session["type"] == null || Session["type"].ToString() == "")
            {
                Session["DefaultView"] = "Index";
                Session["DefaultControll"] = "CustomerAndPurchase";
                return RedirectToAction("Login", "Employee");
            }

            ViewBag.CustomerList = _db.Customers.ToList();
            return View();
        }

        [HttpPost]
        public JsonResult AddCustomerPurchase(CustomerAndPurchaseViewModel customerAndPurchaseViewModel)
        {    
            bool status = false;
            int customerId = Convert.ToInt32(customerAndPurchaseViewModel.CustomerId);
            Customer existCustomer = _db.Customers.Find(customerId);

            var isValidModel = TryUpdateModel(customerAndPurchaseViewModel);
            if (isValidModel)
            {
                using (POS_WebEntities db = new POS_WebEntities())
                {
                    Customer updateExistCustomer = new Customer()
                    {
                        ID = existCustomer.ID,
                        CustomerName = existCustomer.CustomerName,
                        OrderNumber = customerAndPurchaseViewModel.OrderNumber,
                        Date = customerAndPurchaseViewModel.Date,
                        Description = customerAndPurchaseViewModel.Description
                    };

                    db.Entry(updateExistCustomer).State = System.Data.Entity.EntityState.Modified;
                    if (db.SaveChanges() > 0)
                    {                           
                        foreach (var item in customerAndPurchaseViewModel.Items)
                        {
                            Purchase purchase = new Purchase()
                            {
                                CustomerID = customerId,
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