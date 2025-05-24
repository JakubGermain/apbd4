using Exercise9_apbd.DTOs;

namespace Exercise9_apbd.Services;

public interface IPservice
{
    Task<PrescriptionResultDto> CreatePrescriptionAsync(PrescriptionDto request);
    Task<PatientDetailsDto?> GetPrescriptionByIdAsync(int id);
}