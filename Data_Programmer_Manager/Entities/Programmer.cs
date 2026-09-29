using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Programmer_Manager.Entities
{
    public class Programmer
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; } = string.Empty;

        [Required]
        public string Address { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        [Phone]
        public string PhoneNumber { get; set; } = string.Empty;

        [Range(0, 60)]
        public int YearsOfExperience { get; set; }

       public DateTime CreatedOn { get; set; }
        public bool IsDeleted { get; set; }

        public ICollection<Program> Programs { get; set; }= new List<Program>();
    }
}
