using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RESTAPI.Models
{
    public class Department
    {
        [Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Specifies auto-increment
        public int DeptId { get; set; }

        [Required]
        public string DeptName { get; set; }

        public virtual List<Employee> Employee { get; set; }
    }
}
