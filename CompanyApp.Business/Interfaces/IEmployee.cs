using CompanyApp.Domain.Models;

namespace CompanyApp.Business.Interfaces
{
    public interface IEmployee
    {
        Employee Create(Employee employee,string departmentName);
        Employee Get(int id);
        Employee Delete(int id);
        List<Employee> GetEmployeesByAge(int age);
        List<Employee> GetEmployeesByDepartmentID(int departmentID);
        List<Employee> GetEmployeesByDepartmentName(string departmentName);
        List<Employee> GetAllEmployees();
        List<Employee> GetEmployeesByNameOrSurname(string nameOrSurname);
        int GetAllEmployeesCount();
        Employee Update(Employee employee,int id,string departmentName);
        List<Employee> DeleteAllEmployeesByDepartmentName(string departmentName);

    }
}
