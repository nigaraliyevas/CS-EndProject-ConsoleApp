using CompanyApp.Domain.Models.Common;

namespace CompanyApp.Domain.Models
{
    public class Department:BaseEntity
    {
        public string Name { get; set; }
        public int Capacity { get; set; }
    }
}
