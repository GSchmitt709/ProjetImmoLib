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
using PagedList;

namespace ProjetImmoLib.Controllers
{
    public class customersController : Controller
    {

        private agendaEntities db = new agendaEntities();

        public ActionResult ListCustomers(int? pageNumber)
        {
            var customList = db.customers.SqlQuery("SELECT * FROM Customers ORDER BY lastname").ToList();
            return View(customList.ToPagedList(pageNumber ?? 1, 5));
        }

        [HttpPost]
        public ActionResult ListCustomers(string search, int? pageNumber)
        {
            var searchList = db.customers.SqlQuery("SELECT * FROM Customers WHERE lastname LIKE '%" + search + "%' ORDER BY lastname").ToList();
            return View(searchList.ToPagedList(pageNumber ?? 1, 5));
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

        public ActionResult ProfilCustomer(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Error");
            }
            customers customers = db.customers.Find(id);
            if (customers == null)
            {
                return RedirectToAction("Error");
            }
            return View(customers);
        }

        // EDIT: customers
        [HttpPost]
        public ActionResult ProfilCustomer([Bind(Include = "idCustomer,lastname,firstname,mail,phonenumber,budget")] customers customers)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customers).State = EntityState.Modified;
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
            return View(customers);
        }

        public ActionResult DeleteCustomer(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Error");
            }
            customers customers = db.customers.Find(id);
            if (customers == null)
            {
                return HttpNotFound();
            }
            return View(customers);
        }

        [HttpPost, ActionName("DeleteCustomer")]
        public ActionResult DeleteConfirmed(int id)
        {
            customers customers = db.customers.Find(id);
            db.customers.Remove(customers);
            db.SaveChanges();
            return RedirectToAction("ListCustomers");
        }

    }
}