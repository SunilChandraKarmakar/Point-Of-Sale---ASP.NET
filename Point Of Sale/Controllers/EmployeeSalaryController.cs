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
    public class EmployeeSalaryController : Controller
    {
        private POS_WebEntities db = new POS_WebEntities();

        // GET: EmployeeSalary
        public ActionResult Index()
        {
            if (Session["type"] == null || Session["type"].ToString() == "")
            {
                Session["DefaultView"] = "Index";
                Session["DefaultControll"] = "EmployeeSalary";
                return RedirectToAction("Login", "Employee");
            }

            var epmloyeeSalaries = db.EpmloyeeSalaries.Include(e => e.Employee);
            return View(epmloyeeSalaries.ToList());
        }

        // GET: EmployeeSalary/Details/5
        public ActionResult Details(int? id)
        {
            if (Session["type"] == null || Session["type"].ToString() == "")
            {
                Session["DefaultView"] = "Details";
                Session["DefaultControll"] = "EmployeeSalary";
                return RedirectToAction("Login", "Employee");
            }

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EpmloyeeSalary epmloyeeSalary = db.EpmloyeeSalaries.Find(id);
            if (epmloyeeSalary == null)
            {
                return HttpNotFound();
            }
            return View(epmloyeeSalary);
        }

        // GET: EmployeeSalary/Create
        public ActionResult Create()
        {
            if (Session["type"] == null || Session["type"].ToString() == "")
            {
                Session["DefaultView"] = "Create";
                Session["DefaultControll"] = "EmployeeSalary";
                return RedirectToAction("Login", "Employee");
            }

            ViewBag.EmployeeID = new SelectList(db.Employees, "ID", "EmployeeName");
            return View();
        }

        // POST: EmployeeSalary/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,EmployeeID,EmployeeSalary,SalaryMonth,SalaryReciveDate")] EpmloyeeSalary epmloyeeSalary)
        {
            if (Session["type"] == null || Session["type"].ToString() == "")
            {
                Session["DefaultView"] = "Create";
                Session["DefaultControll"] = "EmployeeSalary";
                return RedirectToAction("Login", "Employee");
            }

            if (ModelState.IsValid)
            {
                db.EpmloyeeSalaries.Add(epmloyeeSalary);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EmployeeID = new SelectList(db.Employees, "ID", "EmployeeName", epmloyeeSalary.EmployeeID);
            return View(epmloyeeSalary);
        }

        // GET: EmployeeSalary/Edit/5
        public ActionResult Edit(int? id)
        {
            if (Session["type"] == null || Session["type"].ToString() == "")
            {
                Session["DefaultView"] = "Edit";
                Session["DefaultControll"] = "EmployeeSalary";
                return RedirectToAction("Login", "Employee");
            }

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EpmloyeeSalary epmloyeeSalary = db.EpmloyeeSalaries.Find(id);
            if (epmloyeeSalary == null)
            {
                return HttpNotFound();
            }
            ViewBag.EmployeeID = new SelectList(db.Employees, "ID", "EmployeeName", epmloyeeSalary.EmployeeID);
            return View(epmloyeeSalary);
        }

        // POST: EmployeeSalary/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,EmployeeID,EmployeeSalary,SalaryMonth,SalaryReciveDate")] EpmloyeeSalary epmloyeeSalary)
        {
            if (Session["type"] == null || Session["type"].ToString() == "")
            {
                Session["DefaultView"] = "Edit";
                Session["DefaultControll"] = "EmployeeSalary";
                return RedirectToAction("Login", "Employee");
            }

            if (ModelState.IsValid)
            {
                db.Entry(epmloyeeSalary).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EmployeeID = new SelectList(db.Employees, "ID", "EmployeeName", epmloyeeSalary.EmployeeID);
            return View(epmloyeeSalary);
        }

        // GET: EmployeeSalary/Delete/5
        public ActionResult Delete(int? id)
        {
            if (Session["type"] == null || Session["type"].ToString() == "")
            {
                Session["DefaultView"] = "Delete";
                Session["DefaultControll"] = "EmployeeSalary";
                return RedirectToAction("Login", "Employee");
            }

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EpmloyeeSalary epmloyeeSalary = db.EpmloyeeSalaries.Find(id);
            if (epmloyeeSalary == null)
            {
                return HttpNotFound();
            }
            return View(epmloyeeSalary);
        }

        // POST: EmployeeSalary/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (Session["type"] == null || Session["type"].ToString() == "")
            {
                Session["DefaultView"] = "Delete";
                Session["DefaultControll"] = "EmployeeSalary";
                return RedirectToAction("Login", "Employee");
            }

            EpmloyeeSalary epmloyeeSalary = db.EpmloyeeSalaries.Find(id);
            db.EpmloyeeSalaries.Remove(epmloyeeSalary);
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
