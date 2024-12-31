using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Numerics;

namespace OrganisationProj1.Entity
{
    [Table("Department")]

    public class Department
    {
        [Key]
        public int DeptId { get; set; }

        [NotNull]
        public string DeptName { get; set; }
       
        public override string ToString()
        {
            return DeptId + " " + " " +DeptName;
        }
    }
}
