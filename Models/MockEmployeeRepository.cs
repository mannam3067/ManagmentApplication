using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManagmentApplication.Models
{
    //must be inherit the IEmployeeRepository otherwise we will get error in ConfigureServices.cs(services.AddSingleton<)
    public class MockEmployeeRepository:IEmployeeRepository
    {
        private List<Employee> _employeeList;

        public MockEmployeeRepository()
        {
            _employeeList = new List<Employee>()
        {
            new Employee() { Id = 1, Name = "Mary", Department = "HR", Email = "mary@pragimtech.com" },
            new Employee() { Id = 2, Name = "John", Department = "IT", Email = "john@pragimtech.com" },
            new Employee() { Id = 3, Name = "Sam", Department = "IT", Email = "sam@pragimtech.com" },
        };
        }

        public IEnumerable<Employee> GetAllEmployee()
        {
            return this._employeeList;
        }

        public Employee GetEmployee(int Id)
        {
            return this._employeeList.Where(e => e.Id == Id).FirstOrDefault();
        }

    }
}
