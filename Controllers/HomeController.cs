using ManagmentApplication.Models;
using Microsoft.AspNetCore.Mvc;

namespace ManagmentApplication.Controllers
{
    public class HomeController:Controller
    {
        private IEmployeeRepository _employeeRepository;

        // Inject IEmployeeRepository using Constructor Injection
        public HomeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        // return employee name and return
        public string Index()
        {
            return _employeeRepository.GetEmployee(1).Name;
        }
        // return employee details using employee id
        public ViewResult Details(int id)
        {
            Employee employee = _employeeRepository.GetEmployee(id);
            return View();
        }
        // return string content 
        public string Indexstirng()
        {
            return "Hello MVC";
        }

        // return employee details using Json return type
        public JsonResult IndexJson()
        {
            return Json(new { id = 1, Name = "mallikharjuna" });
        }
    }
}
