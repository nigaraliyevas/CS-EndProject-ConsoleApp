using CompanyApp.Business.Interfaces;
using CompanyApp.DataContext.Repositories;
using CompanyApp.Domain.Models;

namespace CompanyApp.Business.Services
{
    public class DepartmentService : IDepartment
    {
        private readonly DepartmentRepository _departmentRepository;
        private readonly EmployeeRepository _employeeRepository;
        private static int Count = 1;
        public DepartmentService()
        {
            _departmentRepository = new();
            _employeeRepository = new();
        }
        public Department Create(Department department)
        {
            var existDepartment = _departmentRepository.Get(d => d.Name.Equals(department.Name, StringComparison.OrdinalIgnoreCase));
            if (existDepartment is not null) return null;
            department.Id = Count;
            if (!_departmentRepository.Create(department)) return null;
            if (!string.IsNullOrEmpty(department.Name))
            {
                if (department.Capacity == 0) return null;
                Count++;
                return department;
            }
            else
            {
                return null;
            }
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

        public List<Department> GetAllDepartmentsByCapacity(int capacity)
        {
            var existDepartment = _departmentRepository.GetAll(d => d.Capacity == capacity);
            if (existDepartment is null) return null;
            return existDepartment;
        }

        public Department Update(int id, Department department)
        {
            var existDepartment = _departmentRepository.Get(d => d.Id == id);
            if (existDepartment is null) return null;
            var existDepartmentWithName = _departmentRepository.Get(d => d.Name.Equals(department.Name, StringComparison.OrdinalIgnoreCase) && d.Id != id);
            if (existDepartmentWithName is not null) return null;
            var existDepartmentWithAllProp = _departmentRepository.Get(d => d.Name == department.Name && d.Capacity == department.Capacity && d.Id == department.Id);
            if (existDepartmentWithAllProp is not null) return null;
            var deparmentSizeComparison = existDepartment.Capacity > department.Capacity;
            if (deparmentSizeComparison) return null;
            if (!_departmentRepository.Update(department)) return null;
            if (!string.IsNullOrEmpty(department.Name))
            {
                if (department.Capacity == 0) return null;
                /*var res = _employeeRepository.GetAll(em => em.Department.Name.ToLower() == department.Name.ToLower());
                for (int i = res.Count; i <=department.Capacity ; i--)
                {
                    _employeeRepository.Delete(res[i]);
                }*/
                existDepartment.Name = department.Name;
                existDepartment.Capacity = department.Capacity;
                return existDepartment;
            }
            else
            {
                return null;
            }
        }

        public Department Get(string name)
        {
            var existDepartment = _departmentRepository.Get(d => d.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
            if (existDepartment is null) return null;
            return existDepartment;
        }

        public IEnumerable<Department> GetAllDepartmentsWithSortedCapacity()
        {
            return _departmentRepository.GetAll().OrderBy(d => d.Capacity);
        }
    }
}
