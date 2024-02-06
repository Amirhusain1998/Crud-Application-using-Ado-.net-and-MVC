using Crud_operation_Using_Ado.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Crud_operation_Using_Ado.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            EmployeeDbContext db = new EmployeeDbContext();
            List<Employee>obj=db.GetEmployees();

            return View(obj);
        }
        public ActionResult Create()
        {
            

            return View();
        }
        [HttpPost]
        public ActionResult Create(Employee emp)
        {
            try
            {

                if (ModelState.IsValid == true)
                {
                    EmployeeDbContext context = new EmployeeDbContext();
                    bool check = context.AddEmployee(emp);
                    if (check == true)
                    {
                        TempData["InsertMessage"] = "Data has been Inserted Successfully";
                        ModelState.Clear();
                        return RedirectToAction("Index");
                    }
                }
                return View();

            }
            catch
            {
                return View();
            }


            
        }
        public ActionResult Edit(int id)
        {

            
            EmployeeDbContext context = new EmployeeDbContext();

            var row = context.GetEmployees().Find(model => model.Emp_id == id);

            return View(row);


        }
        [HttpPost]
        public ActionResult Edit(int id,Employee emp)
        {

            if (ModelState.IsValid == true)
            {
                EmployeeDbContext context = new EmployeeDbContext();
                bool check = context.UpdateEmployee(emp);
                if (check == true)
                {
                    TempData["UpdateMessage"] = "Data has been Updated Successfully";
                    ModelState.Clear();
                    return RedirectToAction("Index");
                }
            }


            return View();


        }
        public ActionResult Details(int id)
        {


            EmployeeDbContext context = new EmployeeDbContext();

            var row = context.GetEmployees().Find(model => model.Emp_id == id);

            return View(row);


        }
        public ActionResult Delete(int id)
        {


            EmployeeDbContext context = new EmployeeDbContext();

            var row = context.GetEmployees().Find(model => model.Emp_id == id);

            return View(row);


        }
        [HttpPost]
        public ActionResult Delete(int id,Employee emp)
        {

            EmployeeDbContext context = new EmployeeDbContext();
            bool check = context.DeleteEmployee(id);
            if (check == true)
            {
                TempData["DeleteMessage"] = "Data has been Deleted Successfully";
              
                return RedirectToAction("Index");
            }

            return View();


        }


    }
}