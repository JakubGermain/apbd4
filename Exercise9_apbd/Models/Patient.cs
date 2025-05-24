using System.ComponentModel.DataAnnotations;

namespace Exercise9_apbd.Models;

public class Patient
{
    [Key] public int IdPatient { get; set; }

    [Required, MaxLength(100)] public string FirstName { get; set; }

    [Required, MaxLength(100)] public string LastName { get; set; }

    [Required] public DateTime BirthDate { get; set; }

    public ICollection<Prescription> Prescriptions { get; set; }

    public Patient()
    {
        FirstName = string.Empty;
        LastName = string.Empty;
        Prescriptions = new List<Prescription>();
    }
}