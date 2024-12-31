using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.IO.Pipes;
using System.Security.Cryptography;

namespace OrganisationProj1.Entity
{

  
    [Table("Employee")]
    public class Employee
    {
        [Key]
        public int EmpId { get; set; }
        [NotNull]
        public string EmpName { get; set; }
        [NotNull]
        public string Email { get; set; }
        [NotNull]
        public string Phone { get; set; }
        [NotNull]
        public string Designation { get; set; }
        [NotNull]
        public int DeptId { get; set; }
        
        public override string ToString()
        {
            return EmpId + " " + EmpName + " " + " " + Email + " " + Phone + " " + Designation + " " + DeptId;
        }
    }
}
