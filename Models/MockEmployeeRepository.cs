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
            new Employee() { Id = 1, Name = "Mary", Department = Dept.HR, Email = "mary@pragimtech.com" },
            new Employee() { Id = 2, Name = "John", Department = Dept.IT, Email = "john@pragimtech.com" },
            new Employee() { Id = 3, Name = "Sam", Department = Dept.IT, Email = "sam@pragimtech.com" },
        };
        }

        public Employee Add(Employee employee)
        {
           employee.Id= _employeeList.Max(x => x.Id) + 1;
          _employeeList.Add(employee);
            return employee;
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
