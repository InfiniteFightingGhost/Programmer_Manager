namespace Programmer_Manager.ViewModels.Program
{
    public class ProgramDetailsViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string? Description { get; set; }

        public string ProgrammingLanguage { get; set; } = string.Empty;

        public string? Version { get; set; }

        public string ProgrammerName { get; set; } = string.Empty;
    }
}
