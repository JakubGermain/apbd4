namespace Exercise9_apbd.DTOs;

public class PrescriptionDto
{
    public PatientDto Patient { get; set; }
    public List<MedicamentDto> Medicaments { get; set; }
    public DateTime Date { get; set; }
    public DateTime DueDate { get; set; }

    public PrescriptionDto()
    {
        Patient = new PatientDto();
        Medicaments = new List<MedicamentDto>();
    }
}

public class PatientDto
{
    public int? IdPatient { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime BirthDate { get; set; }

    public PatientDto()
    {
        FirstName = string.Empty;
        LastName = string.Empty;
    }
}

public class MedicamentDto
{
    public int IdMedicament { get; set; }
    public int? Dose { get; set; }
    public string Description { get; set; }

    public MedicamentDto()
    {
        Description = string.Empty;
    }
}