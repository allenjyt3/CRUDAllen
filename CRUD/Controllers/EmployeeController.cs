using CRUD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace CRUD.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        SchoolEntities dbContext = new SchoolEntities();
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(tbl_Employees emp)
        {
            if (ModelState.IsValid)
            {
               
                dbContext.tbl_Employees.Add(emp);
                dbContext.SaveChanges();

                return View();
            }
            else
            {
                return View(emp);
            }
        }

        public ActionResult List()
        {

            List<tbl_Employees> listuser = dbContext.tbl_Employees.ToList();
            // List<Employee> listuser = new List<Employee> { new Employee {email="", },new  };
            //Employee users = new Employee();
            return View(listuser);
        }

        public ActionResult Search()  //add a view
        {
            return View();
        }

        public ActionResult SearchResults(int id)                     // Add Partial View
        {
            tbl_Employees employee = dbContext.tbl_Employees.Where(c => c.EmpId == id).FirstOrDefault();

            return PartialView(employee);
        }
        public ActionResult DeleteItem(int id)
        {
            tbl_Employees emp = dbContext.tbl_Employees.Where(c => c.EmpId == id).FirstOrDefault();
            dbContext.tbl_Employees.Remove(emp);
            dbContext.SaveChanges();
            return RedirectToAction("List");
        }

        public ActionResult EditItem(int id)
        {
            tbl_Employees emp = dbContext.tbl_Employees.Where(c => c.EmpId == id).FirstOrDefault();
            return View(emp);
        }

        [HttpPost]
        public ActionResult EditItem(tbl_Employees emp)
        {

            tbl_Employees emp1 = dbContext.tbl_Employees.Where(c => c.EmpId == emp.EmpId).FirstOrDefault();
            // dbContext.Entry(emp1).CurrentValues.SetValues(emp);
            emp1.EmpId = emp.EmpId;
            emp1.EmpName = emp.EmpName;
            emp1.Address = emp.Address;
            emp1.Salary = emp.Salary;
            dbContext.SaveChanges();
            return RedirectToAction("List");

        }
    }
}