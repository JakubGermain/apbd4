using System.ComponentModel.DataAnnotations;

namespace Exercise9_apbd.Models
{
    public class Doctor
    {
        [Key] public int IdDoctor { get; set; }

        [Required, MaxLength(100)] public string FirstName { get; set; }

        [Required, MaxLength(100)] public string LastName { get; set; }

        [Required, MaxLength(100)] public string Email { get; set; }

        public ICollection<Prescription> Prescriptions { get; set; }

        public Doctor()
        {
            FirstName = string.Empty;
            LastName = string.Empty;
            Email = string.Empty;
            Prescriptions = new List<Prescription>();
        }
    }
}