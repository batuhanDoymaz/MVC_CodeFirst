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
    public class HouseKeeperController : Controller
    {
        // GET: HouseKeeper

        MyContext db;
        public HouseKeeperController()
        {
            db = DbTool._DBInstance;
        }
        public ActionResult Index()
        {
            List<HouseKeeperVM> houseKeepers = db.HouseKeepers.Select(x => new HouseKeeperVM
            {
                id = x.Id,
                FirstName = x.FirstName,
                LastName = x.LastName,
            }).ToList();

            return View(houseKeepers);
        }
        public ActionResult AddHouseKeeper()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddHouseKeeper(HouseKeeperVM houseKeeperVM)
        {
            Customer houseKeeper = new Customer()
            {
                FirstName = houseKeeperVM.FirstName,
                LastName = houseKeeperVM.LastName,
            };

            db.Customers.Add(houseKeeper);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult UpdateHouseKeeper(int id)
        {
            HouseKeeperVM houseKeeperVM = db.HouseKeepers.Where(x => x.Id == id).Select(x => new HouseKeeperVM
            {
                id = x.Id,
                FirstName = x.FirstName,
                LastName = x.LastName,
            }).FirstOrDefault();

            return View(houseKeeperVM);
        }

        [HttpPost]
        public ActionResult UpdateHouseKeeper(HouseKeeperVM VM)
        {
            HouseKeeper veri = db.HouseKeepers.Find(VM.id);
            veri.FirstName = VM.FirstName;
            veri.LastName = VM.LastName;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteHouseKeeper(int id)
        {
            db.HouseKeepers.Remove(db.HouseKeepers.Find(id));
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}