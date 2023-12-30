using CompanyApp.Domain.Models;

namespace CompanyApp.Business.Interfaces
{
    public interface IDepartment
    {
        Department Update(int id,Department department);
        Department Get(int id);
        List<Department> GetAllDepartments();
        List<Department> GetAllDepartmentsByName(string name);
        Department Delete(int id);
        Department Create(Department department);
    }
}
