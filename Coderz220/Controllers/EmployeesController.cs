// Ignore Spelling: Coderz

using Coderz220.Data;
using Coderz220.Models;
using Coderz220.Models.viewData;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Coderz220.Controllers
{
    public class EmployeesController : Controller
    {
        private CoderzDbContext db;

        public EmployeesController(CoderzDbContext _db)
        {
            db = _db;
        }

        public IActionResult AllEmployees()
        {
            return View(db.Employees);
        }
        public IActionResult AddEmployee()
        {
            ViewBag.departmentList = new SelectList(db.Departments, "DepartmentId", "DepartmentName");
            return View();
        }
        [HttpPost]
        public IActionResult AddEmployee(EmployeeViewData newEmployee)
        {

            if (newEmployee != null)
            {
                if (ModelState.IsValid)
                {
                    Employee employee = new Employee
                    {
                        EmployeeName = newEmployee.EmployeeName,
                        BOD = newEmployee.BOD,
                        Salary = newEmployee.Salary,
                        Address = newEmployee.Address,
                        City = newEmployee.City,
                        Email = newEmployee.Email,
                        Mobile = newEmployee.Mobile,
                        Status = newEmployee.Status,
                        DepartmentId = newEmployee.DepartmentId,


                    };
                    db.Employees.Add(employee);
                    db.SaveChanges();
                    return RedirectToAction(nameof(AllEmployees));
                }
                return View();
            }
            return View();

        }
        public IActionResult Details(int? id)
        {

            if (id == null)
            {
                return RedirectToAction(nameof(AllEmployees));
            }
            var data = db.Employees.Find(id);
            if (data != null)
            {
                return View(data);
            }
            return RedirectToAction(nameof(AllEmployees));

        }
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return View();
            }
            var data = db.Employees.Find(id);
            if (data != null)
            {
                return View(data);
            }
            return View();

        }
        [HttpPost]
        public IActionResult Edit(Employee editedEmployee)
        {
            if (ModelState.IsValid)
            {
                if (editedEmployee != null)
                {
                    db.Employees.Update(editedEmployee);
                    db.SaveChanges();
                    return RedirectToAction(nameof(AllEmployees));
                }
                return View();
            }
            return View();

        }
        public IActionResult Remove(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(AllEmployees));
            }
            var data = db.Employees.Find(id);
            if (data != null)
            {
                db.Employees.Remove(data);
                db.SaveChanges();
                return RedirectToAction(nameof(AllEmployees));
            }
            return RedirectToAction(nameof(AllEmployees));
        }

        // Department 

        public IActionResult CreateDepartment()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateDepartment(Department newData)
        {
            if (ModelState.IsValid)
            {
                if (newData == null)
                {
                    return RedirectToAction(nameof(CreateDepartment));
                }
                db.Departments.Add(newData);
                db.SaveChanges();
                return RedirectToAction(nameof(AllEmployees));
            }
            return View(newData);
        }
    }
}