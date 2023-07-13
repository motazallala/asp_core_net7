// Ignore Spelling: Coderz

using Coderz220.Data;
using Coderz220.Models;
using Coderz220.Models.ModelViews;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

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
            var data = db.Employees.Include(x => x.Department)
                .OrderByDescending(emp => emp.EmployeeId);
            return View(data);
        }

        public IActionResult test()
        {
            var dataa = new EmployeesDepartments
            {
                Employees = db.Employees.Include(x => x.Department).OrderByDescending(emp => emp.EmployeeId).ToList(),
                Departments = db.Departments.ToList()
            };
            /*            var data = db.Employees.Include(x => x.Department)
                            .OrderByDescending(emp => emp.EmployeeId);*/
            return View(dataa);
        }
        public IActionResult AddEmployee()
        {
            ViewBag.departmentList = new SelectList(db.Departments, "DepartmentId", "DepartmentName");
            return View();
        }
        [HttpPost]
        public IActionResult AddEmployee(Employee newEmployee)
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
                    return RedirectToAction(nameof(test));
                }
                return View();
            }
            return View();

        }
        public IActionResult Details(int? id)
        {

            if (id == null)
            {
                return RedirectToAction(nameof(test));
            }
            var data = db.Employees.Find(id);
            if (data != null)
            {
                return View(data);
            }
            return RedirectToAction(nameof(test));

        }
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(test));
            }
            var data = db.Employees.Find(id);
            if (data != null)
            {
                ViewBag.departmentList = new SelectList(db.Departments, "DepartmentId", "DepartmentName");
                return View(data);
            }
            return RedirectToAction(nameof(test));

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
                    return RedirectToAction(nameof(test));
                }
                return View();
            }
            return View();

        }
        public IActionResult Remove(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(test));
            }
            var data = db.Employees.Find(id);
            if (data != null)
            {
                db.Employees.Remove(data);
                db.SaveChanges();
                return RedirectToAction(nameof(test));
            }
            return RedirectToAction(nameof(test));
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
                return RedirectToAction(nameof(test));
            }
            return View(newData);
        }

        public IActionResult DetailsDepartment(int? id)
        {

            if (id == null)
            {
                return RedirectToAction(nameof(test));
            }
            var data = db.Departments.Find(id);
            if (data != null)
            {
                return View(data);
            }
            return RedirectToAction(nameof(test));

        }
        public IActionResult EditDepartment(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(test));
            }
            var data = db.Departments.Find(id);
            if (data != null)
            {
                return View(data);
            }
            return RedirectToAction(nameof(test));

        }
        [HttpPost]
        public IActionResult EditDepartment(Department editedDepartment)
        {
            if (ModelState.IsValid)
            {
                if (editedDepartment != null)
                {
                    db.Departments.Update(editedDepartment);
                    db.SaveChanges();
                    return RedirectToAction(nameof(test));
                }
                return View();
            }
            return View();

        }
        public IActionResult RemoveDepartment(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(test));
            }
            var data = db.Departments.Find(id);
            if (data != null)
            {
                db.Departments.Remove(data);
                db.SaveChanges();
                return RedirectToAction(nameof(test));
            }
            return RedirectToAction(nameof(test));
        }

    }
}