using CompanyApp.DataContext.Repositories;
using CompanyApp.Domain.Models;
using System.Text.RegularExpressions;

namespace CompanyApp.Business
{
    public class Class1
    {
        private readonly DepartmentRepository departmentRepository;
        public Class1()
        {
            DepartmentRepository departmentRepository = new();
        }
        public Department Update(Department depatment)
        {
            var existDepartment=departmentRepository.Get(d=>d.Id==depatment.Id);
            if (existDepartment == null) return null;
            var existDepartmentWithName=departmentRepository.Get(d=>d.Name==depatment.Name&&d.Id!=existDepartment.Id);
            if (existDepartmentWithName != null) return null;
            existDepartment.Name = depatment.Name;
            existDepartment.Capacity = depatment.Capacity;
            if (!departmentRepository.Update(depatment)) return null;
            return existDepartment;
        }
        
    }
    
}