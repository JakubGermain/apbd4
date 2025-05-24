using System.ComponentModel.DataAnnotations;
using Exercise9_apbd.Models;

public class Medicament
{
    [Key]
    public int IdMedicament { get; set; }

    [Required, MaxLength(100)]
    public string Name { get; set; }

    [Required, MaxLength(100)]
    public string Description { get; set; }

    public ICollection<PrescriptionMedicament> PrescriptionMedicaments { get; set; }

    public Medicament()
    {
        Name = string.Empty;
        Description = string.Empty;
        PrescriptionMedicaments = new List<PrescriptionMedicament>();
    }
}