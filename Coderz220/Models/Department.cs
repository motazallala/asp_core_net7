using System.ComponentModel.DataAnnotations;

namespace Coderz220.Models
{
    public class Department
    {

        public int DepartmentId { get; set; }
        [Required(ErrorMessage = "please Enter Department Name")]
        [Display(Name = "Department Name")]
        [MaxLength(10, ErrorMessage = "Max Length 10 Char")]
        [MinLength(4, ErrorMessage = "Main length 4 Char")]
        public string? DepartmentName { get; set; }
    }
}
