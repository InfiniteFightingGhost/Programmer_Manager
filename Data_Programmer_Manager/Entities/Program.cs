using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Programmer_Manager.Entities
{
    // A software program / project owned by a Programmer.
    public class Program
    {
        [Key] 
        public int Id { get; set; }

        [Required]
        [StringLength(80)]
        public string Name { get; set; } = string.Empty;

        [StringLength(500)]
        public string? Description { get; set; }

        [Required]
        [StringLength(30)]
        public string ProgrammingLanguage { get; set; } = string.Empty;

        [StringLength(20)]
        public string? Version { get; set; }

        public int ProgrammerId { get; set; }

        [ForeignKey(nameof(ProgrammerId))]
        public Programmer Programmer { get; set; } = null!;
    }
}
