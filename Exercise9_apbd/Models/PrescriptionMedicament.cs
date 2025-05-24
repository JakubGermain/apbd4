using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Exercise9_apbd.Models
{
    public class PrescriptionMedicament
    {
        [ForeignKey("Prescription")]
        public int IdPrescription { get; set; }

        
        public Prescription Prescription { get; set; } = null!;

        [ForeignKey("Medicament")]
        public int IdMedicament { get; set; }

        
        public Medicament Medicament { get; set; } = null!;

        public int? Dose { get; set; }

        [MaxLength(100)]
        public string Description { get; set; }

        public PrescriptionMedicament()
        {
            Description = string.Empty;
        }
    }
}