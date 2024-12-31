using System.ComponentModel.DataAnnotations;

namespace EmpDept.Models.Entities
{
    public class Employee
    {
        [Key]
        public int EmpId { get; set; }
        public string EmpName { get; set; }
        public string Email { get; set; }   
        public string Phone { get; set; }
        public string Designation { get; set; }
        public int DeptId { get; set; }
        public virtual Department Department { get; set; }


    }
}
