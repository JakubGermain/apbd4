using System;
using System.Linq;
using System.Threading.Tasks;
using Exercise9_apbd.DAL;
using Exercise9_apbd.DTOs;
using Exercise9_apbd.Models;
using Microsoft.EntityFrameworkCore;

namespace Exercise9_apbd.Services
{
    public class Pservice : IPservice
    {
        private readonly ex9DbContext _context;

        public Pservice(ex9DbContext context)
        {
            _context = context;
        }

        public async Task<PrescriptionResultDto> CreatePrescriptionAsync(PrescriptionDto request)
        {
            if (request.DueDate < request.Date)
                return new PrescriptionResultDto { IsSuccess = false, ErrorMessage = "DueDate musi być większa lub równa Date." };

            if (request.Medicaments.Count > 10)
                return new PrescriptionResultDto { IsSuccess = false, ErrorMessage = "Recepta może zawierać maksymalnie 10 leków." };

            var medicamentIds = request.Medicaments.Select(m => m.IdMedicament).ToList();
            var existingMedicamentIds = await _context.Medicament
                .Where(m => medicamentIds.Contains(m.IdMedicament))
                .Select(m => m.IdMedicament)
                .ToListAsync();

            if (existingMedicamentIds.Count != medicamentIds.Count)
                return new PrescriptionResultDto { IsSuccess = false, ErrorMessage = "Jeden lub więcej leków nie istnieje." };

            Patient? patient = null;
            if (request.Patient.IdPatient.HasValue)
                patient = await _context.Patient.FindAsync(request.Patient.IdPatient.Value);

            if (patient == null)
            {
                patient = new Patient
                {
                    FirstName = request.Patient.FirstName,
                    LastName = request.Patient.LastName,
                    BirthDate = request.Patient.BirthDate
                };

                _context.Patient.Add(patient);
                await _context.SaveChangesAsync();
            }

            var prescription = new Prescription
            {
                Date = request.Date,
                DueDate = request.DueDate,
                IdPatient = patient.IdPatient,
                IdDoctor = 1
            };

            _context.Prescription.Add(prescription);
            await _context.SaveChangesAsync();

            foreach (var med in request.Medicaments)
            {
                _context.PrescriptionMedicament.Add(new PrescriptionMedicament
                {
                    IdPrescription = prescription.IdPrescription,
                    IdMedicament = med.IdMedicament,
                    Dose = med.Dose,
                    Description = med.Description
                });
            }

            await _context.SaveChangesAsync();

            return new PrescriptionResultDto { IsSuccess = true, PrescriptionId = prescription.IdPrescription };
        }

        public async Task<PatientDetailsDto?> GetPrescriptionByIdAsync(int id)
        {
            var patient = await _context.Patient
                .Include(p => p.Prescriptions)
                    .ThenInclude(pr => pr.PrescriptionMedicaments)
                        .ThenInclude(pm => pm.Medicament)
                .Include(p => p.Prescriptions)
                    .ThenInclude(pr => pr.Doctor)
                .AsSplitQuery()  // Rozdziela zapytania dla wielu kolekcji
                .FirstOrDefaultAsync(p => p.IdPatient == id);

            if (patient == null)
                return null;

            return new PatientDetailsDto
            {
                IdPatient = patient.IdPatient,
                FirstName = patient.FirstName,
                LastName = patient.LastName,
                BirthDate = patient.BirthDate,
                Prescriptions = patient.Prescriptions
                    .OrderBy(p => p.DueDate)
                    .Select(p => new PrescriptionDetailsDto
                    {
                        IdPrescription = p.IdPrescription,
                        Date = p.Date,
                        DueDate = p.DueDate,
                        Doctor = new DoctorDto
                        {
                            IdDoctor = p.Doctor.IdDoctor,
                            FirstName = p.Doctor.FirstName,
                            LastName = p.Doctor.LastName,
                            Email = p.Doctor.Email
                        },
                        Medicaments = p.PrescriptionMedicaments
                            .Select(pm => new MedicamentDetailsDto
                            {
                                IdMedicament = pm.Medicament.IdMedicament,
                                Name = pm.Medicament.Name,
                                Dose = pm.Dose,
                                Description = pm.Description
                            }).ToList()
                    }).ToList()
            };
        }
    }
}
