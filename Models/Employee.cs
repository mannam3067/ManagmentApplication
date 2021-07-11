using System.ComponentModel.DataAnnotations;

namespace ManagmentApplication.Models
{
    public class Employee
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please provide a value for Name field")]
        public string Name { get; set; }
        [Display(Name = "Office Email")]
        [RegularExpression(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$",ErrorMessage = "Invalid email format")]
        [Required]
        public string Email { get; set; }
        [Required]
        public Dept? Department { get; set; }

    }
}
