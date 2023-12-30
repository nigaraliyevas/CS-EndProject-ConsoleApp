using CompanyApp.DataContext.Interfaces;
using CompanyApp.Domain.Models;

namespace CompanyApp.DataContext.Repositories
{
    public class EmployeeRepository : IRepository<Employee>
    {
        public bool Create(Employee entity)
        {
            try
            {
                DbContext.Employees.Add(entity);
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Delete(Employee entity)
        {
            try
            {
                DbContext.Employees.Remove(entity);
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Employee Get(Predicate<Employee> filter)
        {
            return DbContext.Employees.Find(filter);
        }

        public List<Employee> GetAll(Predicate<Employee> entity = null)
        {
            return entity==null?DbContext.Employees:DbContext.Employees.FindAll(entity);
        }

        public bool Update(Employee entity)
        {
            try
            {
                var existEmployee = Get(e => e.Id == entity.Id);
                existEmployee = entity;
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
