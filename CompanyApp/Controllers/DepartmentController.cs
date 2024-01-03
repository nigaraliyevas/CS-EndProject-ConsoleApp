using CompanyApp.Business.Interfaces;
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
            Helpers.ChangeTextColor(ConsoleColor.DarkGreen, "Enter Department Name:");
            var departmentName = Console.ReadLine();
            Helpers.ChangeTextColor(ConsoleColor.DarkGreen, "Enter Department Capacity:");
            var capacity = int.TryParse(Console.ReadLine(), out var departmentCapacity);
            if (capacity)
            {
                Department department = new Department();
                department.Name = departmentName;
                department.Capacity = departmentCapacity;
                var result = _departmentService.Create(department);
                if (result is not null)
                {
                    Helpers.ChangeTextColor(ConsoleColor.Green, $"{department.Name} Department Created");
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
            Helpers.ChangeTextColor(ConsoleColor.DarkGreen, "Enter Department Capacity:");
            var capacity = int.TryParse(Console.ReadLine(), out var departmentCapacity);
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
        public void GetDepartmentById()
        {
            Helpers.ChangeTextColor(ConsoleColor.DarkGreen, "Enter Department ID:");
            var id = int.TryParse(Console.ReadLine(), out var departmentId);
            if (id)
            {
                var departmentWithId = _departmentService.Get(departmentId);
                Console.WriteLine($"ID : {departmentWithId.Id}, Name : {departmentWithId.Name}");

            }
            else
            {
                Helpers.ChangeTextColor(ConsoleColor.Red, "Something Went Wrong...");
            }
        }
        public void GetDepartmentByName()
        {
            Helpers.ChangeTextColor(ConsoleColor.DarkGreen, "Enter Department Name:");
            var departmentName=Console.ReadLine();
            if (departmentName is not null)
            {
                var departmentWithName = _departmentService.Get(departmentName);
                Console.WriteLine($"ID : {departmentWithName.Id}, Name : {departmentWithName.Name}");

            }
            else
            {
                Helpers.ChangeTextColor(ConsoleColor.Red, "Something Went Wrong...");
            }
        }
        public void UpdateDepartment()
        {
            Helpers.ChangeTextColor(ConsoleColor.DarkGreen, "Enter Department ID:");
            var id = int.TryParse(Console.ReadLine(), out var departmentId);
            Helpers.ChangeTextColor(ConsoleColor.DarkGreen, "Enter Department Name:");
            var departmentName = Console.ReadLine();
            Helpers.ChangeTextColor(ConsoleColor.DarkGreen, "Enter Department Capacity:");
            var capacity = int.TryParse(Console.ReadLine(), out var departmentCapacity);
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
                    Helpers.ChangeTextColor(ConsoleColor.Red, "Something Went Wrong...");
                }
            }
            else
            {
                Helpers.ChangeTextColor(ConsoleColor.Red, "Please Enter Right Capacity...");
            }
        }
        public void DeleteDepartment()
        {
            Helpers.ChangeTextColor(ConsoleColor.DarkGreen, "Enter Department ID:");
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
                    Helpers.ChangeTextColor(ConsoleColor.Red, "Something Went Wrong");
                }
            }
            else
            {
                Helpers.ChangeTextColor(ConsoleColor.Red, "Please Enter Right ID...");
            }
        }
    }
}
