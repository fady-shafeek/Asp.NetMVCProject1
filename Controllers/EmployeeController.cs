using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TaskDay5.Models;

namespace TaskDay5.Controllers
{
    public class EmployeeController : Controller
    {
        CompanyContext db = new CompanyContext();

        [HttpGet]
        public ActionResult Index()
        {
            var emps = db.Employees.Include(WW => WW.Department);
            return View(emps);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var emp = db.Employees.SingleOrDefault(ww => ww.Id == id);
            return View(emp);
        }

        [HttpPost]
        public ActionResult Edit(Employee emp)
        {
            //var oldemp = db.Employees.Find(emp.Id);
            //oldemp.Name = emp.Name;
            db.Entry(emp).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var emp = db.Employees.SingleOrDefault(ww => ww.Id == id);
            return View(emp);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ActionName("Create")] //Same name of action with different Verb
        public ActionResult CreateConfirmed(Employee emp)
        {
            db.Employees.Add(emp);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        [HttpGet]
        public ActionResult Delete(int id)
        {
            var emp = db.Employees.Find(id);
            db.Employees.Remove(emp);
            db.SaveChanges();    ///search async ,await ,Task

            return RedirectToAction("Index");
        }
    }
}
