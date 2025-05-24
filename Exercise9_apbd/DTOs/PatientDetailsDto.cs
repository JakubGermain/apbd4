namespace Exercise9_apbd.DTOs
{
    public class PatientDetailsDto
    {
        public int IdPatient { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public List<PrescriptionDetailsDto> Prescriptions { get; set; }

        public PatientDetailsDto()
        {
            FirstName = string.Empty;
            LastName = string.Empty;
            Prescriptions = new List<PrescriptionDetailsDto>();
        }
    }

    public class PrescriptionDetailsDto
    {
        public int IdPrescription { get; set; }
        public DateTime Date { get; set; }
        public DateTime DueDate { get; set; }
        public List<MedicamentDetailsDto> Medicaments { get; set; }
        public DoctorDto Doctor { get; set; }

        public PrescriptionDetailsDto()
        {
            Medicaments = new List<MedicamentDetailsDto>();
            Doctor = new DoctorDto();
        }
    }

    public class DoctorDto
    {
        public int IdDoctor { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public DoctorDto()
        {
            FirstName = string.Empty;
            LastName = string.Empty;
            Email = string.Empty;
        }
    }

    public class MedicamentDetailsDto
    {
        public int IdMedicament { get; set; }
        public string Name { get; set; }
        public int? Dose { get; set; }
        public string Description { get; set; }

        public MedicamentDetailsDto()
        {
            Name = string.Empty;
            Description = string.Empty;
        }
    }
}