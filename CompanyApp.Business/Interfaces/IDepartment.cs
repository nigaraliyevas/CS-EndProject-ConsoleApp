using CompanyApp.Domain.Models;

namespace CompanyApp.Business.Interfaces
{
    public interface IDepartment
    {
        Department Update(int id,Department department);
        List<Department> OldDatasOfUpdatedDepartments(string departmentName);
        Department Get(int id);
        Department Get(string name);
        List<Department> GetAllDepartments();
        List<Department> GetAllDepartmentsByCapacity(int capacity);
        IEnumerable<Department> GetAllDepartmentsWithSortedCapacity();
        Department Delete(int id);
        Department Create(Department department);
    }
}
