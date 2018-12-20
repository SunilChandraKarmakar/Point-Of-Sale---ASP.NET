using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Point_Of_Sale;

namespace Point_Of_Sale.Controllers
{
    public class ProductPriceController : Controller
    {
        private POS_WebEntities db = new POS_WebEntities();

        // GET: ProductPrice
        public ActionResult Index()
        {
            if (Session["type"] == null || Session["type"].ToString() == "")
            {
                Session["DefaultView"] = "Index";
                Session["DefaultControll"] = "ProductPrice";
                return RedirectToAction("Login", "Employee");
            }

            ViewBag.ProductPrice = db.ProductPrices.ToList();
            var productPrices = db.ProductPrices.Include(p => p.Product);
            return View();
        }

        // GET: ProductPrice/Details/5
        public ActionResult Details(int? id)
        {
            if (Session["type"] == null || Session["type"].ToString() == "")
            {
                Session["DefaultView"] = "Details";
                Session["DefaultControll"] = "ProductPrice";
                return RedirectToAction("Login", "Employee");
            }

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductPrice productPrice = db.ProductPrices.Find(id);
            if (productPrice == null)
            {
                return HttpNotFound();
            }
            return View(productPrice);
        }

        // GET: ProductPrice/Create
        public ActionResult Create()
        {
            if (Session["type"] == null || Session["type"].ToString() == "")
            {
                Session["DefaultView"] = "Create";
                Session["DefaultControll"] = "ProductPrice";
                return RedirectToAction("Login", "Employee");
            }

            ViewBag.ProductID = new SelectList(db.Products, "ID", "ProductName");
            return View();
        }

        // POST: ProductPrice/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,ProductID,ProductPrice1")] ProductPrice productPrice)
        {
            if (Session["type"] == null || Session["type"].ToString() == "")
            {
                Session["DefaultView"] = "Create";
                Session["DefaultControll"] = "ProductPrice";
                return RedirectToAction("Login", "Employee");
            }

            if (ModelState.IsValid)
            {
                db.ProductPrices.Add(productPrice);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProductID = new SelectList(db.Products, "ID", "ProductName", productPrice.ProductID);
            return View(productPrice);
        }

        // GET: ProductPrice/Edit/5
        public ActionResult Edit(int? id)
        {
            if (Session["type"] == null || Session["type"].ToString() == "")
            {
                Session["DefaultView"] = "Edit";
                Session["DefaultControll"] = "ProductPrice";
                return RedirectToAction("Login", "Employee");
            }

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductPrice productPrice = db.ProductPrices.Find(id);
            if (productPrice == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProductID = new SelectList(db.Products, "ID", "ProductName", productPrice.ProductID);
            return View(productPrice);
        }

        // POST: ProductPrice/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,ProductID,ProductPrice1")] ProductPrice productPrice)
        {
            if (Session["type"] == null || Session["type"].ToString() == "")
            {
                Session["DefaultView"] = "Edit";
                Session["DefaultControll"] = "ProductPrice";
                return RedirectToAction("Login", "Employee");
            }

            if (ModelState.IsValid)
            {
                db.Entry(productPrice).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProductID = new SelectList(db.Products, "ID", "ProductName", productPrice.ProductID);
            return View(productPrice);
        }

        // GET: ProductPrice/Delete/5
        public ActionResult Delete(int? id)
        {
            if (Session["type"] == null || Session["type"].ToString() == "")
            {
                Session["DefaultView"] = "Delete";
                Session["DefaultControll"] = "ProductPrice";
                return RedirectToAction("Login", "Employee");
            }

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductPrice productPrice = db.ProductPrices.Find(id);
            if (productPrice == null)
            {
                return HttpNotFound();
            }
            return View(productPrice);
        }

        // POST: ProductPrice/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (Session["type"] == null || Session["type"].ToString() == "")
            {
                Session["DefaultView"] = "DeleteConfirmed";
                Session["DefaultControll"] = "ProductPrice";
                return RedirectToAction("Login", "Employee");
            }

            ProductPrice productPrice = db.ProductPrices.Find(id);
            db.ProductPrices.Remove(productPrice);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
