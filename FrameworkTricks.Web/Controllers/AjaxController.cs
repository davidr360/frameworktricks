using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web.Mvc;

namespace FrameworkTricks.Web.Controllers
{
    public class AjaxController : Controller
    {
        private readonly EmployeeData db;

        public AjaxController(EmployeeData db)
        {
            this.db = db;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public PartialViewResult EmployeeList()
        {
            var model = db.GetEmployees();
            return PartialView("Index.EmployeeList", model);
        }

        [HttpGet]
        public PartialViewResult Create()
        {
            return PartialView("Index.Create");
        }

        [HttpPost]
        public PartialViewResult Create(Employee employee)
        {
            db.AddEmployee(employee);
            return EmployeeList();
        }

        [HttpGet]
        public PartialViewResult Edit(int id)
        {
            var employee = db.GetBy(id);
            return PartialView("Index.Edit", employee);
        }

        [HttpPost]
        public PartialViewResult Edit(Employee employee)
        {
            db.Update(employee);
            return EmployeeList();
        }

        [HttpPost]
        public PartialViewResult Delete(int id)
        {
            db.Delete(id);
            return EmployeeList();
        }
    }

    public class Employee
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [DisplayName("Date of Birth")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DateOfBirth { get; set; }
    }

    public class EmployeeData
    {
        private readonly List<Employee> _employees;

        public EmployeeData()
        {
            _employees = new List<Employee>
            {
                new Employee { Id = 1, Name = "Rosie", DateOfBirth = new DateTime(1991, 2, 8) },
                new Employee { Id = 2, Name = "David", DateOfBirth = new DateTime(1990, 4, 10) },
                new Employee { Id = 3, Name = "Xu", DateOfBirth = new DateTime(1986, 9, 22) }
            };
        }

        public IEnumerable<Employee> GetEmployees()
        {
            return _employees.OrderBy(x => x.Name);
        }

        public Employee GetBy(int id)
        {
            return _employees.Find(x => x.Id == id);
        }

        public void AddEmployee(Employee employee)
        {
            if (_employees.Any())
            {
                employee.Id = _employees.Max(x => x.Id) + 1;
            }
            else
            {
                employee.Id = 1;
            }            

            _employees.Add(employee);
        }

        public void Update(Employee employee)
        {
            _employees.RemoveAll(x => x.Id == employee.Id);
            _employees.Add(employee);
        }

        public void Delete(int id)
        {
            _employees.RemoveAll(x => x.Id == id);
        }
    }
}