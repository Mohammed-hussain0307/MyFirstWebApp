using MyFirstWebApp.DataAccess;
using MyFirstWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyFirstWebApp.Controllers
{
    public class EmployeeController : Controller
    {
        EmployeeDataAccess employeeDataAccess = new EmployeeDataAccess();

        // GET: Employee
        public ActionResult Index()
        {
            var employeeDetails = employeeDataAccess.GetEmployee();
            return View(employeeDetails);
        }

        // GET: Employee/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Employee/Create
        public ActionResult Create()
        {
                return View();
        }

        // POST: Employee/Create
        [HttpPost]
        public ActionResult Create(EmployeeModel employeeModel)
        {
            bool isAdded = false;
            try
            {
                if (ModelState.IsValid)
                {
                    isAdded = employeeDataAccess.AddEmployee(employeeModel);

                    if (isAdded)
                    {
                        TempData["SuccessMessage"] = "Employee detail added successfully";
                    }
                    else
                    {
                        TempData["ErrorMessage"] = "Cant add the employee detail";
                    }
                    return RedirectToAction("Index");
                }
            }
            catch(Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return View();
            }
            return View();
        }

        // GET: Employee/Edit/5
        public ActionResult Edit(int id)
        {
            var employee = employeeDataAccess.EditEmployee(id);

            if (employee == null)
            {
                TempData["InfoMessage"] = "Product not available with ID " + id.ToString();
                return RedirectToAction("Index");
            }
            return View(employee);
        }

        // POST: Employee/Edit/5
        [HttpPost, ActionName("Edit")]
        public ActionResult Update(EmployeeModel employeeModel)
        {
            if (ModelState.IsValid)
            {
                bool isUpdate = employeeDataAccess.UpdateEmployee(employeeModel);

                if (isUpdate)
                {
                    TempData["Updated"] = "Employee detail updated successfully";
                }
                else
                {
                    TempData["Failed"] = "Cant update the employee detail";
                }
            }
                return View();
            
        }

        // GET: Employee/Delete/5
        public ActionResult Delete(int id)
        {
            employeeDataAccess.DeleteEmployee(id);
            return View();
        }

        // POST: Employee/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
