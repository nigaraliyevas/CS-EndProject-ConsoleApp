using CompanyApp.Domain.Models.Common;

namespace CompanyApp.Domain.Models
{
    public class Employee:BaseEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }
        public Department Department { get; set; }
    }
}
