using CompanyApp.Domain.Models;

namespace CompanyApp.Business.Interfaces
{
    public interface IEmployee
    {
        Employee Create(Employee employee);
        Employee Get(int id);
        Employee Delete(int id);
        List<Employee> GetEmployeesByAge(int age);
        List<Employee> GetEmployeesByDepartmentID(int departmentID);
        List<Employee> GetEmployeesByDepartmentName(string departmentName);
        List<Employee> GetEmployeesByNameOrSurname(string name = null, string surname = null);
        int GetAllEmployeesCount();
        Employee Update(Employee employee,int id,string departmentName);

    }
}
