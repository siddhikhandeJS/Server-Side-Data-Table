using System.ComponentModel.DataAnnotations;

namespace EmpDept.Models.Entities
{
    public class Department
    {
        [Key]
        public int DeptId { get; set; }
        public string DeptName { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}
