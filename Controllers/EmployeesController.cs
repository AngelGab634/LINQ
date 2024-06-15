using EmployeeManaged.Entities;
using EmployeeManaged.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace EmployeeManagement.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EmployeeController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Employee/List
        public IActionResult List()
        {
            var employees = _context.Employees.ToList();
            return View(employees);
        }

        public IActionResult Details(Guid Id)
        {
            var employee = _context.Employees.FirstOrDefault(e => e.Id == Id);
            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }

        public IActionResult Create()
        {
            return View();
        }

        // POST: Employee/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                _context.Employees.Add(employee);
                _context.SaveChanges();
                return RedirectToAction(nameof(List));
            }
            return View(employee);
        }

        // GET: Employee/Edit/5
        public IActionResult Edit(Guid Id)
        {
            var employee = _context.Employees.SingleOrDefault(e => e.Id == Id);
            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Employee employee)
        {
            if (ModelState.IsValid)
            {
                _context.Employees.Update(employee);
                _context.SaveChanges();
                return RedirectToAction(nameof(List));
            }
            return View(employee);
        }

        public IActionResult Delete(Guid Id)
        {
            var employee = _context.Employees.LastOrDefault(e => e.Id == Id);
            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(Guid Id)
        {
            var employee = _context.Employees.Single(e => e.Id == Id);
            _context.Employees.Remove(employee);
            _context.SaveChanges();
            return RedirectToAction(nameof(List));
        }

        // GET: Employee/Search
        public IActionResult Search(string name)
        {
            var employees = _context.Employees.Where(e => e.Name.Contains(name)).ToList();
            return View("List", employees);
        }

        // GET: Employee/OrderByName
        public IActionResult OrderByName()
        {
            var employees = _context.Employees.OrderBy(e => e.Name).ToList();
            return View("List", employees);
        }

        // GET: Employee/OrderByAge
        public IActionResult OrderByAge()
        {
            var employees = _context.Employees.OrderByDescending(e => e.Age).ToList();
            return View("List", employees);
        }
    }
}