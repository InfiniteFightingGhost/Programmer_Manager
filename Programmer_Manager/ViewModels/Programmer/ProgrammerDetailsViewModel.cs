using System.ComponentModel.DataAnnotations;

namespace Programmer_Manager.ViewModels.Programmer
{
    public class ProgrammerDetailsViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Address { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string PhoneNumber { get; set; } = string.Empty;

        public int YearsOfExperience { get; set; }
        [Display(Name = "Created on")]
        public DateTime CreatedOn { get; set; }
    }
}
