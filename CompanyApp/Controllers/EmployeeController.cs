using CompanyApp.Business.Interfaces;
using CompanyApp.Business.Services;
using CompanyApp.Domain.Models;
using CompanyApp.Helper;

namespace CompanyApp.Controllers
{
    public class EmployeeController
    {
        public readonly EmployeeService _employeeService;
        public readonly DepartmentService _departmentService;
        public EmployeeController()
        {
            _employeeService = new EmployeeService();
        }
        public void CreateEmployee()
        {
            Helpers.ChangeTextColor(ConsoleColor.DarkGreen, "Enter Department Name:");
            var departmentName = Console.ReadLine();
            Helpers.ChangeTextColor(ConsoleColor.DarkGreen, "Enter Employee Name:");
            var employeeName = Console.ReadLine();
            Helpers.ChangeTextColor(ConsoleColor.DarkGreen, "Enter Employee Surname:");
            var employeeSurname = Console.ReadLine();
            Helpers.ChangeTextColor(ConsoleColor.DarkGreen, "Enter Employee Address:");
            var employeeAdress = Console.ReadLine();
            Helpers.ChangeTextColor(ConsoleColor.DarkGreen, "Enter Employee Age:");
            var age = int.TryParse(Console.ReadLine(), out var employeeAge);
            if (age)
            {
                Employee employee = new();
                employee.Name = employeeName;
                employee.Surname = employeeSurname;
                employee.Address = employeeAdress;
                employee.Age = employeeAge;
                var result = _employeeService.Create(employee, departmentName);
                if (result != null)
                {
                    Helpers.ChangeTextColor(ConsoleColor.Green, $"Employee {employee.Name} Created");

                }
                else
                {
                    Helpers.ChangeTextColor(ConsoleColor.Red, "Something Went Wrong");

                }
            }
            else
            {
                Helpers.ChangeTextColor(ConsoleColor.Red, "Please Make Sure You've Entered Correct All Information");

            }
        }
        public void GetAllEmployees()
        {
            var result = _employeeService.GetAllEmployees();
            if (result.Count > 0)
            {
                foreach (var employee in result)
                {
                    Console.WriteLine($"ID : {employee.Id}, Name : {employee.Name}, Surname : {employee.Surname}, Address : {employee.Address}, Age : {employee.Age}, Department : {employee.Department.Name}, Registered Date : {employee.CreatedDate.ToString("dd/MM/yyyy")}");
                }
            }
            else
            {
                Helpers.ChangeTextColor(ConsoleColor.Red, "Empty List...");
            }
        }
        public void GetAllEmployeesByNameOrSurname() {
            Helpers.ChangeTextColor(ConsoleColor.Green, "Please Enter Name Or Surname");
            var getUser = Console.ReadLine();
            var result = _employeeService.GetEmployeesByNameOrSurname(getUser);
            if (result.Count > 0)
            {
                foreach (var employee in result)
                {
                    Console.WriteLine($"ID : {employee.Id}, Name : {employee.Name}, Surname : {employee.Surname}, Address : {employee.Address}, Age : {employee.Age}, Department : {employee.Department.Name}, Registered Date : {employee.CreatedDate.ToString("dd/MM/yyyy")}");
                }
            }
            else
            {
                Helpers.ChangeTextColor(ConsoleColor.Red, "Empty List...");
            }
        }
        public void GetEmployeeById() {
            Helpers.ChangeTextColor(ConsoleColor.Green, "Please Enter ID");
            var id = int.TryParse(Console.ReadLine(), out var employeeID);
            if (id)
            {
                var employeeId=_employeeService.Get(employeeID);
                Console.WriteLine($"ID : {employeeId.Id}, Name : {employeeId.Name}");
            }
            else
            {
                Helpers.ChangeTextColor(ConsoleColor.Red, "Something Went Wrong...");
            }
        }
        public void GetEmployeesByAge() { }
        public void GetEmployeesByDepartmentName() { }
        public void GetEmployeesByDepartmentId() { }
        public void GetAllEmployeesCount() { }
        public void UpdateEmployee() { }
        public void DeleteEmployee() { }
        public void DeleteAllEmployeesByDeparmentName() { }

    }
}
