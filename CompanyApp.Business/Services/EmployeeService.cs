using CompanyApp.Business.Interfaces;
using CompanyApp.DataContext.Repositories;
using CompanyApp.Domain.Models;
using System.Collections;
using System.Collections.Generic;

namespace CompanyApp.Business.Services
{
    public class EmployeeService : IEmployee
    {
        private static int Count = 1;
        private readonly EmployeeRepository _employeeRepository;
        private readonly DepartmentRepository _departmentRepository;
        private readonly List<Employee> _updatedEmployees;

        public EmployeeService()
        {
            _employeeRepository = new();
            _departmentRepository = new();
            _updatedEmployees = new();
        }
        public Employee Create(Employee employee, string departmentName)
        {
            var existDepartment = _departmentRepository.
                Get(d => d.Name.Equals(departmentName, StringComparison.OrdinalIgnoreCase));
            if (existDepartment == null) return null;
            bool checkCapacity = existDepartment.Capacity > _employeeRepository.GetAll(em => em.Department.Name.Equals(departmentName, StringComparison.OrdinalIgnoreCase)).Count;
            bool checkAge = employee.Age >= 18 && employee.Age < 65;
            if (!checkCapacity || !checkAge) return null;
            employee.Id = Count;
            employee.Department = existDepartment;
            if (!_employeeRepository.Create(employee)) return null;
            Count++;
            return employee;
        }

        public Employee Delete(int id)
        {
            var existEmployee = _employeeRepository.Get(em => em.Id == id);
            if (existEmployee == null) return null;
            if (!_employeeRepository.Delete(existEmployee)) return null;
            return existEmployee;
        }
        public List<Employee> DeleteAllEmployeesByDepartmentName(string departmentName)
        {
            var existEmployees = _employeeRepository.GetAll(em => em.Department.Name.Equals(departmentName, StringComparison.OrdinalIgnoreCase));
            if (existEmployees is null) return null;
            if (existEmployees.Count() > 0)
            {
                foreach (var employee in existEmployees)
                {
                    _employeeRepository.Delete(employee);
                }
                return existEmployees;
            }
            else
            {
                return null;
            }
        }
        public Employee Get(int id)
        {
            var existEmployee = _employeeRepository.Get(em => em.Id == id);
            if (existEmployee == null) return null;
            return existEmployee;
        }
        public List<Employee> GetAllEmployees()
        {
            return _employeeRepository.GetAll();
        }
        public int GetAllEmployeesCount()
        {
            return _employeeRepository.GetAll().Count;
        }
        public IEnumerable<Employee> GetAllEmployeesWithSortedAge()
        {
            return _employeeRepository.GetAll().OrderBy(e => e.Age);
        }
        public IEnumerable<Employee> GetAllEmployeesWithSortedSalary()
        {
            return _employeeRepository.GetAll().OrderBy(e => e.Salary);
        }
        public List<Employee> GetEmployeesByAge(int age)
        {
            var existEmployees = _employeeRepository.GetAll(em => em.Age == age);
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
            var existDepartment = _employeeRepository.GetAll(em => em.Department.Name.Equals(departmentName, StringComparison.OrdinalIgnoreCase));
            if (existDepartment is null) return null;
            return existDepartment;
        }
        public List<Employee> GetEmployeesByNameOrSurname(string nameOrSurname)
        {
            var existEmployeesWithName = _employeeRepository.GetAll(em => em.Name.Equals(nameOrSurname, StringComparison.OrdinalIgnoreCase) || em.Surname.Equals(nameOrSurname, StringComparison.OrdinalIgnoreCase));
            if (existEmployeesWithName is null) return null;
            return existEmployeesWithName;
        }

        public Employee Update(Employee employee, int id, string departmentName)
        {
            var existEmployee = _employeeRepository.Get(em => em.Id == id);
            if (existEmployee == null) return null;
            var existDepartment = _departmentRepository.Get(d => d.Name.Equals(departmentName, StringComparison.OrdinalIgnoreCase));
            if (existDepartment is null) return null;
            bool checkDepartmentSizeAvailable = existDepartment.Capacity <= _employeeRepository.GetAll(em => em.Department.Name.Equals(departmentName, StringComparison.OrdinalIgnoreCase)).Count && existEmployee.Department.Name.ToLower() != departmentName.ToLower();
            if (checkDepartmentSizeAvailable) return null;
            bool checkAge = employee.Age >= 18 && employee.Age < 65;
            if (checkAge == false) return null;
            Employee employee1 = new();
            employee1.Id = existEmployee.Id;
            employee1.Name = existEmployee.Name;
            employee1.Department = existDepartment;
            employee1.Surname = existEmployee.Surname;
            employee1.Salary = existEmployee.Salary;
            employee1.Age = existEmployee.Age;
            employee1.Address = existEmployee.Address;
            _updatedEmployees.Add(employee1);
            if (!string.IsNullOrEmpty(employee.Name))
            {
                existEmployee.Name = employee.Name;
            }
            if (!string.IsNullOrEmpty(employee.Surname))
            {
                existEmployee.Surname = employee.Surname;
            }
            if (!string.IsNullOrEmpty(employee.Address))
            {
                existEmployee.Address = employee.Address;
            }
            existEmployee.Age = employee.Age;
            existEmployee.Salary = employee.Salary;
            existEmployee.Department = existDepartment;
            if (!_employeeRepository.Update(existEmployee)) return null;
            return existEmployee;
        }

        public List<Employee> OldDatasOfUpdatedEmployees(string departmentName)
        {
            if(_updatedEmployees is null)return null;
            return _updatedEmployees.FindAll(em=>em.Department.Name.ToLower()==departmentName.ToLower());
        }
    }
}
