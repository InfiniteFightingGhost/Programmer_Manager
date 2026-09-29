using System.ComponentModel.DataAnnotations;

namespace Programmer_Manager.ViewModels.Programmer
{
    public class ProgrammerEditViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(50, ErrorMessage = "Name cannot be more than 50 characters")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Address is required")]
        public string Address { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Phone is required")]
        [Phone(ErrorMessage = "Invalid phone")]
        public string PhoneNumber { get; set; } = string.Empty;

        [Range(0, 60, ErrorMessage = "Years of experience must be between 0 and 60")]
        public int YearsOfExperience { get; set; }
    }
}
