using CompanyApp.Business.Services;
using CompanyApp.Domain.Models;
using CompanyApp.Helper;

namespace CompanyApp.Controllers
{

    public class DepartmentController
    {
        public readonly DepartmentService _departmentService;
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
                    Helpers.ChangeTextColor(ConsoleColor.Green, $"{department.Name} Department Successfully Created✔️");
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
                Helpers.ChangeTextColor(ConsoleColor.Red, "Something Went Wrong...");
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
    }
}
