using System.ComponentModel.DataAnnotations;

namespace Coderz220.Models.viewData
{
    public class EmployeeViewData
    {
        [Display(Name = "Employee Id")]
        public int EmployeeId { get; set; }

        [Display(Name = "Employee Name")]
        public string? EmployeeName { get; set; }

        [Display(Name = "Birth of Date")]
        public DateTime BOD { get; set; }

        public decimal Salary { get; set; }

        public string? Address { get; set; }

        public string? City { get; set; }

        public string? Email { get; set; }

        public string? Mobile { get; set; }

        public bool Status { get; set; }

        public int DepartmentId { get; set; }

        public Department? Department { get; set; }
    }
}
