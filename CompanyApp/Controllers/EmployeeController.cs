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
            Helpers.ChangeTextColor(ConsoleColor.White, "Enter Department Name:");
            var departmentName = Console.ReadLine();
            Helpers.ChangeTextColor(ConsoleColor.White, "Enter Employee Name:");
            var employeeName = Console.ReadLine();
            Helpers.ChangeTextColor(ConsoleColor.White, "Enter Employee Surname:");
            var employeeSurname = Console.ReadLine();
            Helpers.ChangeTextColor(ConsoleColor.White, "Enter Employee Address:");
            var employeeAddress = Console.ReadLine();
            Helpers.ChangeTextColor(ConsoleColor.White, "Enter Employee Age:");
            var age = byte.TryParse(Console.ReadLine(), out var employeeAge);
            Helpers.ChangeTextColor(ConsoleColor.White, "Enter Employee Salary:");
            var salary = int.TryParse(Console.ReadLine(), out var employeeSalary);
            if (age && salary)
            {
                Employee employee = new();
                employee.Name = employeeName;
                employee.Surname = employeeSurname;
                employee.Address = employeeAddress;
                employee.Age = employeeAge;
                employee.Salary = employeeSalary;
                var result = _employeeService.Create(employee, departmentName);
                if (result != null)
                {
                    Helpers.ChangeTextColor(ConsoleColor.DarkGreen, $"Employee {employee.Name} Created\n");

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
                    Console.WriteLine($"ID : {employee.Id}, Name : {employee.Name}, Surname : {employee.Surname}, Address : {employee.Address}, Age : {employee.Age}, Salary : {employee.Salary}, Department : {employee.Department.Name}, Registered Date : {employee.CreatedDate.ToString("dd/MM/yyyy")}\n");
                }
            }
            else
            {
                Helpers.ChangeTextColor(ConsoleColor.Red, "Empty List...\n");
            }
        }
        public void GetAllEmployeesWithSortedAge()
        {
            var result = _employeeService.GetAllEmployeesWithSortedAge();
            if (_employeeService.GetAllEmployees().Count > 0)
            {
                foreach (var employee in result)
                {
                    Console.WriteLine($"ID : {employee.Id}, Name : {employee.Name}, Surname : {employee.Surname}, Address : {employee.Address}, Age : {employee.Age}, Salary : {employee.Salary}, Department : {employee.Department.Name}, Registered Date : {employee.CreatedDate.ToString("dd/MM/yyyy")}\n");
                }
            }
            else
            {
                Helpers.ChangeTextColor(ConsoleColor.Red, "Empty List...\n");
            }
        }
        public void GetAllEmployeesWithSortedSalary()
        {
            var result = _employeeService.GetAllEmployeesWithSortedSalary();
            if (_employeeService.GetAllEmployees().Count > 0)
            {
                foreach (var employee in result)
                {
                    Console.WriteLine($"ID : {employee.Id}, Name : {employee.Name}, Surname : {employee.Surname}, Address : {employee.Address}, Age : {employee.Age}, Salary : {employee.Salary},Department : {employee.Department.Name}, Registered Date : {employee.CreatedDate.ToString("dd/MM/yyyy")}\n");
                }
            }
            else
            {
                Helpers.ChangeTextColor(ConsoleColor.Red, "Empty List...\n");
            }
        }
        public void GetAllEmployeesByNameOrSurname()
        {
            Helpers.ChangeTextColor(ConsoleColor.White, "Please Enter Name Or Surname:");
            var getUser = Console.ReadLine();
            var result = _employeeService.GetEmployeesByNameOrSurname(getUser);
            if (result.Count > 0 && result is not null)
            {
                foreach (var employee in result)
                {
                    Console.WriteLine($"ID : {employee.Id}, Name : {employee.Name}, Surname : {employee.Surname}, Address : {employee.Address}, Age : {employee.Age}, Salary : {employee.Salary}, Department : {employee.Department.Name}, Registered Date : {employee.CreatedDate.ToString("dd/MM/yyyy")}\n");
                }
            }
            else
            {
                Helpers.ChangeTextColor(ConsoleColor.Red, "Not Found...\n");
            }
        }
        public void GetEmployeeById()
        {
            Helpers.ChangeTextColor(ConsoleColor.White, "Please Enter ID:");
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
            Helpers.ChangeTextColor(ConsoleColor.White, "Please Enter Age:");
            var age = byte.TryParse(Console.ReadLine(), out var employeeAge);
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
            Helpers.ChangeTextColor(ConsoleColor.White, "Please Enter Department Name:");
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
            Helpers.ChangeTextColor(ConsoleColor.White, "Please Enter Department ID:");
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
            Helpers.ChangeTextColor(ConsoleColor.DarkYellow, $"Count : {result}\n");
        }
        public void UpdateEmployee()
        {
            Helpers.ChangeTextColor(ConsoleColor.White, "Only Admin Can Update Employee!\n\n");
            Helpers.ChangeTextColor(ConsoleColor.White, "Please Enter Username:");
            string username = Console.ReadLine();
            Helpers.ChangeTextColor(ConsoleColor.White, "Please Enter Password:");
            string password = Console.ReadLine();
            string authorAdmin = "Admin";
            string passwordAdmin = "Admin123";
            if (username == authorAdmin && password == passwordAdmin)
            {
                Console.WriteLine("Successfully entered as ~Admin~ \n\n");
                Helpers.ChangeTextColor(ConsoleColor.White, "Enter Employee ID:");
                var id = int.TryParse(Console.ReadLine(), out var employeeId);
                Helpers.ChangeTextColor(ConsoleColor.White, "Enter Department Name:");
                var departmentName = Console.ReadLine();
                Helpers.ChangeTextColor(ConsoleColor.White, "Enter New Employee Name:");
                var employeeName = Console.ReadLine();
                Helpers.ChangeTextColor(ConsoleColor.White, "Enter New Employee Surname:");
                var employeeSurname = Console.ReadLine();
                Helpers.ChangeTextColor(ConsoleColor.White, "Enter New Employee Address:");
                var employeeAddress = Console.ReadLine();
                Helpers.ChangeTextColor(ConsoleColor.White, "Enter New Employee Age:");
                var age = byte.TryParse(Console.ReadLine(), out var employeeAge);
                Helpers.ChangeTextColor(ConsoleColor.White, "Enter New Employee Salary:");
                var salary = int.TryParse(Console.ReadLine(), out var employeeSalary);
                if (age && salary)
                {
                    Employee employee = new();
                    employee.Name = employeeName;
                    employee.Surname = employeeSurname;
                    employee.Address = employeeAddress;
                    employee.Age = employeeAge;
                    employee.Salary = employeeSalary;
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
            else
            {
                Console.WriteLine("username or password is incorrect");
            }
        }
        public void OldDatasOfUpdatedEmployees()
        {
            Helpers.ChangeTextColor(ConsoleColor.White, "Please Enter Department Name:");
            var departmentName = Console.ReadLine();
            if (departmentName is not null)
            {
                var result = _employeeService.OldDatasOfUpdatedEmployees(departmentName);
                if (result.Count > 0)
                {
                    foreach (var employee in result)
                    {
                        Console.WriteLine($"ID : {employee.Id}, Name : {employee.Name}, Surname : {employee.Surname}, Address : {employee.Address}, Age : {employee.Age}, Salary : {employee.Salary}, Department : {employee.Department.Name}, Registered Date : {employee.CreatedDate.ToString("dd/MM/yyyy")}\n");
                    }
                }
                else
                {
                    Helpers.ChangeTextColor(ConsoleColor.Red, "Empty List...\n");
                }
            }
        }
        public void DeleteEmployee()
        {
            Helpers.ChangeTextColor(ConsoleColor.White, "Only Admin Can Delete Employee!\n\n");
            Helpers.ChangeTextColor(ConsoleColor.White, "Please Enter Username:");
            string username = Console.ReadLine();
            Helpers.ChangeTextColor(ConsoleColor.White, "Please Enter Password:");
            string password = Console.ReadLine();
            string authorAdmin = "Admin";
            string passwordAdmin = "Admin123";
            if (username == authorAdmin && password == passwordAdmin)
            {
                Console.WriteLine("Successfully entered as ~Admin~ \n\n");
                Helpers.ChangeTextColor(ConsoleColor.White, "Please Enter ID:");
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
            else
            {
                Console.WriteLine("Username Or Password Is Incorrect");
            }
        }
        public void DeleteAllEmployeesByDeparmentName()
        {
            Helpers.ChangeTextColor(ConsoleColor.White, "Please Enter Department Name:");
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