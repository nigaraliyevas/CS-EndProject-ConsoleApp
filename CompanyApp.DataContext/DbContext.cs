using CompanyApp.Domain.Models;
using System.Text.Json;
using System;

namespace CompanyApp.DataContext
{
    public static class DbContext
    {
        public static List<Employee> Employees { get; set; }
        public static List<Department> Departments { get; set; }
        static DbContext()
        {
            Employees = new ();
            Departments = new ();
        }
    }
}
