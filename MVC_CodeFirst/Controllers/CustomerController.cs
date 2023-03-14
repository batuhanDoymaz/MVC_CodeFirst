using MVC_CodeFirst.DesignPatterns.SingletonPattern;
using MVC_CodeFirst.Models.ContextClasses;
using MVC_CodeFirst.Models.Entities;
using MVC_CodeFirst.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_CodeFirst.Controllers
{
    public class CustomerController : Controller
    {

        MyContext db;

        public CustomerController()
        {
            db = DbTool._DBInstance;
        }
        // GET: Customer
        public ActionResult Index()
        {
            List<CustomerVM> customers = db.Customers.Select(x => new CustomerVM
            {
                id = x.Id,
                FirstName = x.FirstName,
                LastName = x.LastName,
            }).ToList();

            return View(customers);
        }

        public ActionResult AddCustomer()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddCustomer(CustomerVM customerVM)
        {
            Customer customer = new Customer()
            {
                FirstName = customerVM.FirstName,
                LastName = customerVM.LastName,
            };

            db.Customers.Add(customer);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult UpdateCustomer(int id)
        {
            CustomerVM customerVM = db.Customers.Where(x => x.Id == id).Select(x => new CustomerVM
            {
                id = x.Id,
                FirstName = x.FirstName,
                LastName = x.LastName,
            }).FirstOrDefault();

            return View(customerVM);
        }

        [HttpPost]
        public ActionResult UpdateCustomer(CustomerVM VM)
        {
            Customer veri = db.Customers.Find(VM.id);
            veri.FirstName = VM.FirstName;
            veri.LastName = VM.LastName;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteCustomer(int id)
        {
            db.Customers.Remove(db.Customers.Find(id));
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}