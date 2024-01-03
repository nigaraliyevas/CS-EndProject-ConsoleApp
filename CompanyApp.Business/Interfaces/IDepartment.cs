using CompanyApp.Domain.Models;

namespace CompanyApp.Business.Interfaces
{
    public interface IDepartment
    {
        Department Update(int id,Department department);
        Department Get(int id);
        Department Get(string name);
        List<Department> GetAllDepartments();
        List<Department> GetAllDepartmentsByCapacity(int capacity);
        Department Delete(int id);
        Department Create(Department department);
    }
}
