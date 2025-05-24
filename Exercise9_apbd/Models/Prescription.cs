using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Exercise9_apbd.Models
{
    public class Prescription
    {
        [Key]
        public int IdPrescription { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public DateTime DueDate { get; set; }

        [ForeignKey("Patient")]
        public int IdPatient { get; set; }

       
        public Patient Patient { get; set; } = null!;

        [ForeignKey("Doctor")]
        public int IdDoctor { get; set; }

        
        public Doctor Doctor { get; set; } = null!;

        public ICollection<PrescriptionMedicament> PrescriptionMedicaments { get; set; }

        public Prescription()
        {
            PrescriptionMedicaments = new List<PrescriptionMedicament>();
        }
    }
}