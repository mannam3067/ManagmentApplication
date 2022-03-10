using ManagmentApplication.Models;
using ManagmentApplication.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ManagmentApplication.Controllers
{
    public class HomeController : Controller
    {
        private IEmployeeRepository _employeeRepository;

        // Inject IEmployeeRepository using Constructor Injection
        public HomeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        #region Return Generaldatatype        
        // return employee name and return
        //attribute routing
        //[Route("")]
        //[Route("Home")]
        //Tokens in Attribute Routing
        //[Route("[Controller]/[action]")]
        public ViewResult Index()
        {
            IEnumerable<Employee> employeeModel = _employeeRepository.GetAllEmployee();
            return View(employeeModel);
        }
        // return string content 
        public string Indexstirng()
        {
            return "Hello MVC";
        }
        #endregion

        #region ReturnMvcActionResults


        // return employee details using employee id
        // The ? makes id route parameter optional. To make it required remove ?
        //[Route("Home/Details/{id?}")]
        // ? makes id method parameter nullable       
        public ViewResult Details(int? id)
        {
            HomeDetailsViewModel homeDetailsViewModel = new HomeDetailsViewModel()
            {
                // If "id" is null use 1, else use the value passed from the route
                employeeDetails = _employeeRepository.GetEmployee(id ?? 1),
                PageTitle = "Employee Details"
            };
            return View(homeDetailsViewModel);
        }

        // return employee details using Json return type
        public JsonResult IndexJson()
        {
            return Json(new { id = 1, Name = "mallikharjuna" });
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Employee model)
        {
            if (ModelState.IsValid)
            {
                Employee newEmployee = _employeeRepository.Add(model);
                return RedirectToAction("Details", new { id = newEmployee.Id });
            }
            return View();
        }
        #endregion

        #region Customizeviewdiscovery
        //If we do not like this default convention, we can use the overloaded version of the View(string viewName) method, 
        //that takes viewName as a parameter, to look for a view file with your own custom name.
        public ViewResult TestDetailsOne()
        {
            return View("Test");
        }

        //Specifying view file path
        public ViewResult TestDetailsTwo()
        {
            return View("/MyViews/Test.cshtml");
        }

        //Relative View File Path (relative path we do not specify the file extension .cshtml.)
        public ViewResult Testdetailsthree()
        {
            return View("../Test/Update");
        }
        public ViewResult TestdetailsFour()
        {
            return View("../../MyViews/Test");
        }
        #endregion

        #region Passdatafromcontroller to view 
        public ViewResult SampleViewData()
        {
            // Pass PageTitle and Employee model to the View using ViewData
            Employee model = _employeeRepository.GetEmployee(1);

            ViewData["PageTitle"] = "pass data from controller to View using viewdata";
            ViewData["Employee"] = model;
            return View();
        }

        public ViewResult SampleViewBag()
        {

            // To store the page title and empoyee model object in the 
            // ViewBag we are using dynamic properties PageTitle and Employee

            Employee model = _employeeRepository.GetEmployee(1);

            ViewBag.PageTitle = "pass data from controller to View using viewBag";
            ViewBag.EmployeeModel = model;
            return View();
        }
        #endregion

        #region Strongly Typed View 

        public ViewResult StronglyTypedView()
        {
            Employee model = _employeeRepository.GetEmployee(1);

            ViewBag.PageTitle = "pass data from controller to View using StronglyTypedView";
            return View(model);
        }
        #endregion

    }
}
