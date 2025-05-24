namespace Exercise9_apbd.DTOs;

public class PrescriptionResultDto
{
    public bool IsSuccess { get; set; }
    public string? ErrorMessage { get; set; }
    public int? PrescriptionId { get; set; }
}