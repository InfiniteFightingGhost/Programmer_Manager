using System.ComponentModel.DataAnnotations;

namespace Programmer_Manager.ViewModels.Program
{
    public class ProgramEditViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        [MaxLength(80, ErrorMessage = "Name cannot be longer than 80 characters.")]
        public string Name { get; set; } = string.Empty;

        [MaxLength(500, ErrorMessage = "Description cannot be longer than 500 characters.")]
        public string? Description { get; set; }

        [Required(ErrorMessage = "Programming language is required.")]
        [MaxLength(30, ErrorMessage = "Programming language cannot be longer than 30 characters.")]
        public string ProgrammingLanguage { get; set; } = string.Empty;

        [MaxLength(20, ErrorMessage = "Version cannot be longer than 20 characters.")]
        public string? Version { get; set; }

        [Required(ErrorMessage = "Please select a programmer.")]
        public int ProgrammerId { get; set; }
    }
}
