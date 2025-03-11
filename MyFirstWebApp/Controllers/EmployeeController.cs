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
            try
            {
                var employee = employeeDataAccess.EditEmployee(id).FirstOrDefault();

                if (employee == null)
                {
                    TempData["ErrorMessage"] = "Employee not available with ID " + id.ToString();
                    return RedirectToAction("Index");
                }
                return View(employee);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return View();
            }
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
            try {
                var employee = employeeDataAccess.EditEmployee(id).FirstOrDefault();

                if (employee == null)
                {
                    TempData["ErrorMessage"] = "Employee not available with ID " + id.ToString();
                    return RedirectToAction("Index");
                }
                return View(employee);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return View();
            }
        }

        // POST: Employee/Edit/5
        [HttpPost, ActionName("Edit")]
        public ActionResult Update(EmployeeModel employeeModel)
        {
            try
            {
                int id = 0;

                if (ModelState.IsValid)
                {
                    id = employeeDataAccess.UpdateEmployee(employeeModel);

                    if (id > 0)
                    {
                        TempData["SuccessMessage"] = "Employee details updated successfully.";
                    }
                    else
                    {
                        TempData["ErrorMessage"] = "Unable to update the Employee.";
                    }
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return View();
            }            
        }

        // GET: Employee/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                var employee = employeeDataAccess.EditEmployee(id).FirstOrDefault();

                if (employee == null)
                {
                    TempData["ErrorMessage"] = "Employee details not available with the employee Id : " + id;
                    return RedirectToAction("Index");
                }
                return View(employee);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return View();
            }
        }

        // POST: Employee/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                int employee = 0;

                if (ModelState.IsValid)
                {
                    employee = employeeDataAccess.DeleteEmployee(id);

                    if (employee > 0)
                    {
                        TempData["SuccessMessage"] = "Employee detail deleted successfully.";
                    }
                    else
                    {
                        TempData["ErrorMessage"] = "Unable to delete the employee detail.";
                    }
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return View();
            }
        }
    }
}
