using CompanyApp.Business.Interfaces;
using CompanyApp.DataContext.Repositories;
using CompanyApp.Domain.Models;

namespace CompanyApp.Business.Services
{
    public class DepartmentService : IDepartment
    {
        private readonly DepartmentRepository _departmentRepository;
        private readonly EmployeeRepository _employeeRepository;
        private static int Count;
        public DepartmentService()
        {
            _departmentRepository = new();
            _employeeRepository = new();
        }
        public Department Create(Department department)
        {
            throw new NotImplementedException();
        }

        public Department Delete(int id)
        {
            var existDepartment = _departmentRepository.Get(d => d.Id == id);
            if (existDepartment == null) return null;
            var existDepartmentEmployeesList = _employeeRepository.GetAll(em => em.Id == existDepartment.Id);
            if (_departmentRepository.Delete(existDepartment))
            {
                if (existDepartmentEmployeesList.Count > 0)
                {
                    foreach (var employee in existDepartmentEmployeesList)
                    {
                        _employeeRepository.Delete(employee);
                    }
                }
                return existDepartment;
            }
            else
            {
                return null;
            }
        }

        public Department Get(int id)
        {
            var existDepartment = _departmentRepository.Get(d => d.Id == id);
            if (existDepartment == null) return null;
            return existDepartment;
        }

        public List<Department> GetAllDepartments()
        {
            var existDepartment = _departmentRepository.GetAll();
            return existDepartment;
        }

        public List<Department> GetAllDepartmentsByName(string name)
        {
            var existDepartment = _departmentRepository.GetAll(d => d.Name == name);
            if (existDepartment is null) return null;
            return existDepartment;
        }

        public Department Update(int id, Department department)
        {
            throw new NotImplementedException();
        }

    }
}
