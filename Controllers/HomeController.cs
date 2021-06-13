using ManagmentApplication.Models;
using Microsoft.AspNetCore.Mvc;

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
        public string Index()
        {
            return _employeeRepository.GetEmployee(1).Name;
        }
        // return string content 
        public string Indexstirng()
        {
            return "Hello MVC";
        }
        #endregion

        #region ReturnMvcActionResults


        // return employee details using employee id
        public ViewResult Details(int id)
        {
            Employee employee = _employeeRepository.GetEmployee(id);
            return View();
        }

        // return employee details using Json return type
        public JsonResult IndexJson()
        {
            return Json(new { id = 1, Name = "mallikharjuna" });
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

    }
}
