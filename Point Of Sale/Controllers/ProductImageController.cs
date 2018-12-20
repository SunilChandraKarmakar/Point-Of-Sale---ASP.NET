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
    public class ProductImageController : Controller
    {
        private POS_WebEntities db = new POS_WebEntities();

        // GET: ProductImage
        public ActionResult Index()
        {
            if (Session["type"] == null || Session["type"].ToString() == "")
            {
                Session["DefaultView"] = "Index";
                Session["DefaultControll"] = "ProductImage";
                return RedirectToAction("Login", "Employee");
            }

            ViewBag.ProductImageList = db.ProductImages.ToList();
            var productImages = db.ProductImages.Include(p => p.Product);
            return View();
        }

        // GET: ProductImage/Details/5
        public ActionResult Details(int? id)
        {
            if (Session["type"] == null || Session["type"].ToString() == "")
            {
                Session["DefaultView"] = "Details";
                Session["DefaultControll"] = "ProductImage";
                return RedirectToAction("Login", "Employee");
            }

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductImage productImage = db.ProductImages.Find(id);
            if (productImage == null)
            {
                return HttpNotFound();
            }
            return View(productImage);
        }

        // GET: ProductImage/Create
        public ActionResult Create()
        {
            if (Session["type"] == null || Session["type"].ToString() == "")
            {
                Session["DefaultView"] = "Create";
                Session["DefaultControll"] = "ProductImage";
                return RedirectToAction("Login", "Employee");
            }

            ViewBag.ProductID = new SelectList(db.Products, "ID", "ProductName");
            return View();
        }

        // POST: ProductImage/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProductImage productImage, HttpPostedFileBase PI)
        {
            if (Session["type"] == null || Session["type"].ToString() == "")
            {
                Session["DefaultView"] = "Create";
                Session["DefaultControll"] = "ProductImage";
                return RedirectToAction("Login", "Employee");
            }

            productImage.ProductImage1 = System.IO.Path.GetFileName(PI.FileName);

            if (ModelState.IsValid)
            {
                db.ProductImages.Add(productImage);
                db.SaveChanges();
                PI.SaveAs(Server.MapPath("../Images/ProductImage/" + productImage.ID.ToString() + "_" + productImage.ProductImage1));
                return RedirectToAction("Index");
            }

            ViewBag.ProductID = new SelectList(db.Products, "ID", "ProductName", productImage.ProductID);
            return View(productImage);
        }

        // GET: ProductImage/Edit/5
        public ActionResult Edit(int? id)
        {
            if (Session["type"] == null || Session["type"].ToString() == "")
            {
                Session["DefaultView"] = "Edit";
                Session["DefaultControll"] = "ProductImage";
                return RedirectToAction("Login", "Employee");
            }

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductImage productImage = db.ProductImages.Find(id);
            if (productImage == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProductID = new SelectList(db.Products, "ID", "ProductName", productImage.ProductID);
            return View(productImage);
        }

        // POST: ProductImage/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ProductImage productImage, HttpPostedFileBase PI)
        {
            if (Session["type"] == null || Session["type"].ToString() == "")
            {
                Session["DefaultView"] = "Edit";
                Session["DefaultControll"] = "ProductImage";
                return RedirectToAction("Login", "Employee");
            }

            productImage.ProductImage1 = System.IO.Path.GetFileName(PI.FileName);

            if (ModelState.IsValid)
            {
                db.Entry(productImage).State = EntityState.Modified;
                db.SaveChanges();
                PI.SaveAs(Server.MapPath("../Images/ProductImage/UpdateProductImage/" + productImage.ID.ToString() + "_" + productImage.ProductImage1));
                return RedirectToAction("Index");
            }

            ViewBag.ProductID = new SelectList(db.Products, "ID", "ProductName", productImage.ProductID);
            return View(productImage);
        }

        // GET: ProductImage/Delete/5
        public ActionResult Delete(int? id)
        {
            if (Session["type"] == null || Session["type"].ToString() == "")
            {
                Session["DefaultView"] = "Delete";
                Session["DefaultControll"] = "ProductImage";
                return RedirectToAction("Login", "Employee");
            }

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductImage productImage = db.ProductImages.Find(id);
            if (productImage == null)
            {
                return HttpNotFound();
            }
            return View(productImage);
        }

        // POST: ProductImage/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (Session["type"] == null || Session["type"].ToString() == "")
            {
                Session["DefaultView"] = "DeleteConfirmed";
                Session["DefaultControll"] = "ProductImage";
                return RedirectToAction("Login", "Employee");
            }

            ProductImage productImage = db.ProductImages.Find(id);
            db.ProductImages.Remove(productImage);
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
