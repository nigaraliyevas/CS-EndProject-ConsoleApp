using CompanyApp.Business.Services;
using CompanyApp.Domain.Models;
using CompanyApp.Helper;

namespace CompanyApp.Controllers
{

    public class DepartmentController
    {
        private readonly DepartmentService _departmentService;
        public DepartmentController()
        {
            _departmentService = new DepartmentService();
        }
        public void CreateDepartment()
        {
            Helpers.ChangeTextColor(ConsoleColor.White, "Enter Department Name:");
            var departmentName = Console.ReadLine();
            Helpers.ChangeTextColor(ConsoleColor.White, "Enter Department Capacity:");
            var capacity = byte.TryParse(Console.ReadLine(), out var departmentCapacity);
            if (capacity)
            {
                Department department = new Department();
                department.Name = departmentName;
                department.Capacity = departmentCapacity;
                var result = _departmentService.Create(department);
                if (result is not null)
                {
                    Helpers.ChangeTextColor(ConsoleColor.DarkGreen, $"{department.Name} Department Created");
                }
                else
                {
                    Helpers.ChangeTextColor(ConsoleColor.Red, "Something Went Wrong...");
                }
            }
            else
            {
                Helpers.ChangeTextColor(ConsoleColor.Red, "Please Enter Right Capacity...");
            }

        }
        public void GetAllDepartments()
        {
            var result = _departmentService.GetAllDepartments();
            if (result.Count > 0)
            {
                foreach (var department in result)
                {
                    Console.WriteLine($"ID : {department.Id}, Name : {department.Name}, Capacity : {department.Capacity}");
                }
            }
            else
            {
                Helpers.ChangeTextColor(ConsoleColor.Red, "Empty List...");
            }
        }
        public void GetAllDepartmentsByCapacity()
        {
            Helpers.ChangeTextColor(ConsoleColor.White, "Enter Department Capacity:");
            var capacity = byte.TryParse(Console.ReadLine(), out var departmentCapacity);
            var result = _departmentService.GetAllDepartmentsByCapacity(departmentCapacity);
            if (result.Count > 0)
            {
                foreach (var department in result)
                {
                    Console.WriteLine($"Name : {department.Name}, Capacity : {department.Capacity}");
                }
            }
            else
            {
                Helpers.ChangeTextColor(ConsoleColor.Red, "Something Went Wrong...");
            }

        }
        public void GetAllDepartmentsWithSortedCapacity()
        {
            var result = _departmentService.GetAllDepartmentsWithSortedCapacity();
            if (_departmentService.GetAllDepartments().Count> 0)
            {
                foreach (var department in result)
                {
                    Console.WriteLine($"Name : {department.Name}, Capacity : {department.Capacity}");
                }
            }
            else
            {
                Helpers.ChangeTextColor(ConsoleColor.Red, "Something Went Wrong...");
            }

        }
        public void GetDepartmentById()
        {
            Helpers.ChangeTextColor(ConsoleColor.White, "Enter Department ID:");
            var id = int.TryParse(Console.ReadLine(), out var departmentId);
            if (id)
            {
                var departmentWithId = _departmentService.Get(departmentId);
                if (departmentWithId != null)
                {
                    Console.WriteLine($"ID : {departmentWithId.Id}, Name : {departmentWithId.Name}");
                }
                else
                {
                    Helpers.ChangeTextColor(ConsoleColor.Red, "Not Found 404...");
                }
            }
            else
            {
                Helpers.ChangeTextColor(ConsoleColor.Red, "Something Went Wrong...");
            }
        }
        public void GetDepartmentByName()
        {
            Helpers.ChangeTextColor(ConsoleColor.White, "Enter Department Name:");
            var departmentName = Console.ReadLine();
            if (departmentName is not null)
            {
                var departmentWithName = _departmentService.Get(departmentName);
                if (departmentWithName != null)
                {
                    Console.WriteLine($"ID : {departmentWithName.Id}, Name : {departmentWithName.Name}");
                }
                else
                {
                    Helpers.ChangeTextColor(ConsoleColor.Red, "Not Found...");
                }
            }
            else
            {
                Helpers.ChangeTextColor(ConsoleColor.Red, "Something Went Wrong...");
            }
        }
        public void UpdateDepartment()
        {
            Helpers.ChangeTextColor(ConsoleColor.White, "Only Admin Can Update Department!\n\n");
            Helpers.ChangeTextColor(ConsoleColor.White, "Please Enter Username:");
            string username = Console.ReadLine();
            Helpers.ChangeTextColor(ConsoleColor.White, "Please Enter Password:");
            string password = Console.ReadLine();
            string authorAdmin = "Admin";
            string passwordAdmin = "Admin123";
            if (username == authorAdmin && password == passwordAdmin)
            {
                Console.WriteLine("Successfully entered as ~Admin~ \n\n");
                Helpers.ChangeTextColor(ConsoleColor.White, "Enter Department ID:");
                var id = int.TryParse(Console.ReadLine(), out var departmentId);
                Helpers.ChangeTextColor(ConsoleColor.White, "Enter Department Name:");
                var departmentName = Console.ReadLine();
                Helpers.ChangeTextColor(ConsoleColor.White, "Enter Department Capacity:");
                var capacity = byte.TryParse(Console.ReadLine(), out var departmentCapacity);
                if (id && capacity)
                {
                    Department newDepartment = new Department();
                    newDepartment.Name = departmentName;
                    newDepartment.Capacity = departmentCapacity;
                    var result = _departmentService.Update(departmentId, newDepartment);
                    if (result is not null)
                    {
                        Helpers.ChangeTextColor(ConsoleColor.Green, $"Name : {newDepartment.Name} Updated");
                    }
                    else
                    {
                        Helpers.ChangeTextColor(ConsoleColor.Red, "Not Found...");
                    }
                }
                else
                {
                    Helpers.ChangeTextColor(ConsoleColor.Red, "Please Enter Right...");
                }
            }
            else
            {
                Console.WriteLine("Username Or Password Is Incorrect");
            }
        }
        public void DeleteDepartment()
        {
            Helpers.ChangeTextColor(ConsoleColor.White, "Only Admin Can Delete Department!\n\n");
            Helpers.ChangeTextColor(ConsoleColor.White, "Please Enter Username:");
            string username = Console.ReadLine();
            Helpers.ChangeTextColor(ConsoleColor.White, "Please Enter Password:");
            string password = Console.ReadLine();
            string authorAdmin = "Admin";
            string passwordAdmin = "Admin123";
            if (username == authorAdmin && password == passwordAdmin)
            {
                Console.WriteLine("Successfully entered as ~Admin~ \n\n");
                Helpers.ChangeTextColor(ConsoleColor.White, "Enter Department ID:");
                var id = int.TryParse(Console.ReadLine(), out var departmentId);
                if (id)
                {
                    var result = _departmentService.Delete(departmentId);
                    if (result is not null)
                    {
                        Helpers.ChangeTextColor(ConsoleColor.Green, $"Name : {result.Name} Deleted");
                    }
                    else
                    {
                        Helpers.ChangeTextColor(ConsoleColor.Red, "Not Found...");
                    }
                }
                else
                {
                    Helpers.ChangeTextColor(ConsoleColor.Red, "Please Enter Right ID...");
                }
            }
            else
            {
                Console.WriteLine("Username Or Password Is Incorrect");
            }
        }
    }
}
