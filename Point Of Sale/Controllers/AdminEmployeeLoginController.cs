using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Point_Of_Sale.Controllers
{
    public class AdminEmployeeLoginController : Controller
    {
        POS_WebEntities db = new POS_WebEntities();

        // GET: AdminEmployeeLogin
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult CheckValidEmployee(Employee model)
        {
            string result = "Fail";
            var DataItem = db.Employees.Where(e => e.EmployeeEmail == model.EmployeeEmail && e.EmployeePassword == model.EmployeePassword).SingleOrDefault();
            if (DataItem != null)
            {
                Session["ID"] = DataItem.ID.ToString();
                Session["EmployeeName"] = DataItem.EmployeeName.ToString();
                result = "Success";
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult AfterLogin()
        {
            if (Session["ID"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        public ActionResult Logout()
        {
            Session.Clear();
            Session.Abandon();
            return RedirectToAction("Index");
        }
    }
}