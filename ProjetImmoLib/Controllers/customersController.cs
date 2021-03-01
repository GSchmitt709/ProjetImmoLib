using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProjetImmoLib;

namespace ProjetImmoLib.Controllers
{
    public class customersController : Controller
    {

        private agendaEntities db = new agendaEntities();

        public ActionResult ListCustomers()
        {
            var customList = db.customers.SqlQuery("SELECT * FROM Customers ORDER BY lastname").ToList();
            return View(customList);
        }

        public ActionResult AddCustomer()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddCustomer([Bind(Include = "idCustomer,lastname,firstname,mail,phonenumber,budget")] customers customers)
        {
            if (ModelState.IsValid)
            {
                db.customers.Add(customers);

                try
                {
                    db.SaveChanges();
                }
                catch (DbEntityValidationException)
                {
                    return RedirectToAction("Error");
                }
                return RedirectToAction("Success");
            }
            return View();
        }

        public ActionResult Error()
        {
            return View();
        }

        public ActionResult Success()
        {
            return View();
        }
    }
}