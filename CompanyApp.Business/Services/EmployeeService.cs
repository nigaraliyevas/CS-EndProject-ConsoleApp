using CompanyApp.Business.Interfaces;
using CompanyApp.DataContext.Repositories;
using CompanyApp.Domain.Models;

namespace CompanyApp.Business.Services
{
    public class EmployeeService : IEmployee
    {
        private static int Count = 1;
        private EmployeeRepository _employeeRepository;
        private DepartmentRepository _departmentRepository;
        public EmployeeService()
        {
            _employeeRepository = new EmployeeRepository();

        }
        public Employee Create(Employee employee)
        {
            var existDepartment=_departmentRepository.
                Get(d=>d.Name.Equals(employee.Department.Name,StringComparison.OrdinalIgnoreCase));
            if (existDepartment == null) return null;
            if (_employeeRepository.GetAll().Count>existDepartment.Capacity) return null;
            employee.Id = Count;
            employee.Department= existDepartment;
            if (!_employeeRepository.Create(employee)) return null;
            Count++;
            return employee;
        }

        public Employee Delete(int id)
        {
            var existEmployee=_employeeRepository.Get(em=>em.Id==id);
            if (existEmployee == null) return null;
            if (!_employeeRepository.Delete(existEmployee)) return null;
            return existEmployee;
        }

        public Employee Get(int id)
        {
            var existEmployee=_employeeRepository.Get(em=>em.Id == id);
            if (existEmployee == null) return null;
            return existEmployee;
        }

        public int GetAllEmployeesCount()
        {
            return _employeeRepository.GetAll().Count;
        }

        public List<Employee> GetEmployeesByAge(int age)
        {
            var existEmployees= _employeeRepository.GetAll(em=>em.Age==age);
            if (existEmployees is null) return null; 
            return existEmployees;
        }

        public List<Employee> GetEmployeesByDepartmentID(int departmentID)
        {
            var existDepartment = _employeeRepository.GetAll(em => em.Department.Id == departmentID);
            if (existDepartment is null) return null; 
            return existDepartment;

        }

        public List<Employee> GetEmployeesByDepartmentName(string departmentName)
        {
            var existDepartment = _employeeRepository.GetAll(em => em.Department.Name == departmentName);
            if (existDepartment is null) return null;
            return existDepartment;
        }

        public List<Employee> GetEmployeesByNameOrSurname(string name = null, string surname = null)
        {
            var existEmployeesWithName = _employeeRepository.GetAll(em => em.Name == name);
            var existEmployeesWithSurname = _employeeRepository.GetAll(em => em.Surname == surname);
            if (existEmployeesWithName==null && existEmployeesWithSurname==null) return null;
            if (existEmployeesWithName != null && existEmployeesWithSurname is null) 
                return existEmployeesWithName;
            if (existEmployeesWithName == null && existEmployeesWithSurname is not null)
                return existEmployeesWithSurname;
            return null;
        }

        public Employee Update(Employee employee, int id, string departmentName)
        {
            var existEmployee=_employeeRepository.Get(em=>em.Id == id);
            if (existEmployee == null) return null;
            var existDepartment=_departmentRepository.Get(d=>d.Name.Equals(departmentName,StringComparison.OrdinalIgnoreCase));
            if (existDepartment is null) return null;
            if (!string.IsNullOrEmpty(employee.Name))
            {
                existEmployee.Name = employee.Name;
            }
            if (!string.IsNullOrEmpty(employee.Surname))
            {
                existEmployee.Surname = employee.Surname;
            }
            existEmployee.Department = existDepartment; 
            if(!_employeeRepository.Update(existEmployee))return null; 
            return existEmployee;
        }
    }
}
