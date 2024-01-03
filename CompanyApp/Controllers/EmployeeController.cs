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
            var employeeAddress = Console.ReadLine();
            Helpers.ChangeTextColor(ConsoleColor.DarkGreen, "Enter Employee Age:");
            var age = int.TryParse(Console.ReadLine(), out var employeeAge);
            if (age)
            {
                Employee employee = new();
                employee.Name = employeeName;
                employee.Surname = employeeSurname;
                employee.Address = employeeAddress;
                employee.Age = employeeAge;
                var result = _employeeService.Create(employee, departmentName);
                if (result != null)
                {
                    Helpers.ChangeTextColor(ConsoleColor.Green, $"Employee {employee.Name} Created\n");

                }
                else
                {
                    Helpers.ChangeTextColor(ConsoleColor.Red, "Something Went Wrong\n");

                }
            }
            else
            {
                Helpers.ChangeTextColor(ConsoleColor.Red, "Please Make Sure You've Entered Correct All Information\n");

            }
        }
        public void GetAllEmployees()
        {
            var result = _employeeService.GetAllEmployees();
            if (result.Count > 0)
            {
                foreach (var employee in result)
                {
                    Console.WriteLine($"ID : {employee.Id}, Name : {employee.Name}, Surname : {employee.Surname}, Address : {employee.Address}, Age : {employee.Age}, Department : {employee.Department.Name}, Registered Date : {employee.CreatedDate.ToString("dd/MM/yyyy")}\n");
                }
            }
            else
            {
                Helpers.ChangeTextColor(ConsoleColor.Red, "Empty List...\n");
            }
        }
        public void GetAllEmployeesByNameOrSurname()
        {
            Helpers.ChangeTextColor(ConsoleColor.Green, "Please Enter Name Or Surname:");
            var getUser = Console.ReadLine();
            var result = _employeeService.GetEmployeesByNameOrSurname(getUser);
            if (result.Count > 0 && result is not null)
            {
                foreach (var employee in result)
                {
                    Console.WriteLine($"ID : {employee.Id}, Name : {employee.Name}, Surname : {employee.Surname}, Address : {employee.Address}, Age : {employee.Age}, Department : {employee.Department.Name}, Registered Date : {employee.CreatedDate.ToString("dd/MM/yyyy")}\n");
                }
            }
            else
            {
                Helpers.ChangeTextColor(ConsoleColor.Red, "Not Found...\n");
            }
        }
        public void GetEmployeeById()
        {
            Helpers.ChangeTextColor(ConsoleColor.Green, "Please Enter ID:");
            var id = int.TryParse(Console.ReadLine(), out var employeeID);
            var employeeId = _employeeService.Get(employeeID);
            if (id && employeeId is not null)
            {
                Console.WriteLine($"ID : {employeeId.Id}, Name : {employeeId.Name}\n");
            }
            else
            {
                Helpers.ChangeTextColor(ConsoleColor.Red, "Not Found 404...\n");
            }
        }
        public void GetEmployeesByAge()
        {
            Helpers.ChangeTextColor(ConsoleColor.Green, "Please Enter Age:");
            var age = int.TryParse(Console.ReadLine(), out var employeeAge);
            if (age)
            {
                var employeesAge = _employeeService.GetEmployeesByAge(employeeAge);
                if (employeesAge.Count > 0)
                {
                    foreach (var employee in employeesAge)
                    {
                        Console.WriteLine($"ID : {employee.Id}, Name : {employee.Name}, Age : {employee.Age}, Department : {employee.Department.Name}\n");
                    }
                }
                else
                {
                    Helpers.ChangeTextColor(ConsoleColor.Red, "Not Found...\n");
                }
            }
            else
            {
                Helpers.ChangeTextColor(ConsoleColor.Red, "Something Went Wrong...");
            }
        }
        public void GetEmployeesByDepartmentName()
        {
            Helpers.ChangeTextColor(ConsoleColor.Green, "Please Enter Department Name:");
            var departmentName = Console.ReadLine();
            if (departmentName is not null)
            {
                var departmentEmployees = _employeeService.GetEmployeesByDepartmentName(departmentName);
                if (departmentEmployees.Count > 0)
                {
                    foreach (var employee in departmentEmployees)
                    {
                        Console.WriteLine($"ID : {employee.Id}, Name : {employee.Name}, Department : {employee.Department.Name}\n");
                    }
                }
                else
                {
                    Helpers.ChangeTextColor(ConsoleColor.Red, "Not Found...\n");
                }
            }
            else
            {
                Helpers.ChangeTextColor(ConsoleColor.Red, "Something Went Wrong...\n");
            }
        }
        public void GetEmployeesByDepartmentId()
        {
            Helpers.ChangeTextColor(ConsoleColor.Green, "Please Enter Department ID:");
            var departmentId = int.TryParse(Console.ReadLine(), out var departmentID);
            if (departmentId)
            {
                var departmentEmployees = _employeeService.GetEmployeesByDepartmentID(departmentID);
                if (departmentEmployees.Count > 0)
                {
                    foreach (var employee in departmentEmployees)
                    {
                        Console.WriteLine($"ID : {employee.Id}, Name : {employee.Name}, Department ID: {employee.Department.Id},Department Name: {employee.Department.Name}\n");
                    }
                }
                else
                {
                    Helpers.ChangeTextColor(ConsoleColor.Red, "Not Found...\n");
                }
            }
            else
            {
                Helpers.ChangeTextColor(ConsoleColor.Red, "Something Went Wrong...\n");
            }
        }
        public void GetAllEmployeesCount()
        {
            var result = _employeeService.GetAllEmployeesCount();
            Helpers.ChangeTextColor(ConsoleColor.Blue, $"Count : {result}\n");
        }
        public void UpdateEmployee()
        {
            Helpers.ChangeTextColor(ConsoleColor.DarkGreen, "Enter Employee ID:");
            var id = int.TryParse(Console.ReadLine(), out var employeeId);
            Helpers.ChangeTextColor(ConsoleColor.DarkGreen, "Enter Department Name:");
            var departmentName = Console.ReadLine();
            Helpers.ChangeTextColor(ConsoleColor.DarkGreen, "Enter New Employee Name:");
            var employeeName = Console.ReadLine();
            Helpers.ChangeTextColor(ConsoleColor.DarkGreen, "Enter New Employee Surname:");
            var employeeSurname = Console.ReadLine();
            Helpers.ChangeTextColor(ConsoleColor.DarkGreen, "Enter New Employee Address:");
            var employeeAddress = Console.ReadLine();
            Helpers.ChangeTextColor(ConsoleColor.DarkGreen, "Enter New Employee Age:");
            var age = int.TryParse(Console.ReadLine(), out var employeeAge);
            if (age)
            {
                Employee employee = new();
                employee.Name = employeeName;
                employee.Surname = employeeSurname;
                employee.Address = employeeAddress;
                employee.Age = employeeAge;
                var result = _employeeService.Update(employee, employeeId, departmentName);
                if (result != null)
                {
                    Helpers.ChangeTextColor(ConsoleColor.Green, $"Employee {employee.Name} Updated\n");

                }
                else
                {
                    Helpers.ChangeTextColor(ConsoleColor.Red, "Something Went Wrong\n");

                }
            }
            else
            {
                Helpers.ChangeTextColor(ConsoleColor.Red, "Please Make Sure You've Entered Correct All Information\n");

            }
        }
        public void DeleteEmployee()
        {
            Helpers.ChangeTextColor(ConsoleColor.Green, "Please Enter ID:");
            var id = int.TryParse(Console.ReadLine(), out var employeeID);
            if (id)
            {
                var employeeId = _employeeService.Delete(employeeID);
                if (employeeId is not null)
                {
                    Console.WriteLine($"ID : {employeeId.Id} Deleted...\n");
                }
                else
                {
                    Helpers.ChangeTextColor(ConsoleColor.Red, "Not Found 404...\n");
                }

            }
            else
            {
                Helpers.ChangeTextColor(ConsoleColor.Red, "Something Went Wrong...\n");
            }
        }
        public void DeleteAllEmployeesByDeparmentName()
        {
            Helpers.ChangeTextColor(ConsoleColor.Green, "Please Enter Department Name:");
            var departmentName = Console.ReadLine();
            if (departmentName is not null)
            {
                var departmentEmployees = _employeeService.DeleteAllEmployeesByDepartmentName(departmentName);
                if (departmentEmployees is not null)
                {
                    Helpers.ChangeTextColor(ConsoleColor.Green, $"Employees Deleted\n");
                }
                else
                {
                    Helpers.ChangeTextColor(ConsoleColor.Red, "Not Found...\n");
                }
            }
            else
            {
                Helpers.ChangeTextColor(ConsoleColor.Red, "Something Went Wrong!\n");
            }
        }
    }
}
