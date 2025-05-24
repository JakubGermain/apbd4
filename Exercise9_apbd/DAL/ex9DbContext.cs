using Microsoft.EntityFrameworkCore;
using Exercise9_apbd.Models;

namespace Exercise9_apbd.DAL
{
    public class ex9DbContext : DbContext
    {
        public DbSet<Patient> Patient { get; set; }
        public DbSet<Doctor> Doctor { get; set; }
        public DbSet<Medicament> Medicament { get; set; }
        public DbSet<Prescription> Prescription { get; set; }
        public DbSet<PrescriptionMedicament> PrescriptionMedicament { get; set; }

        public ex9DbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<PrescriptionMedicament>()
                .HasKey(pm => new { pm.IdPrescription, pm.IdMedicament });

            modelBuilder.Entity<PrescriptionMedicament>()
                .HasOne(pm => pm.Prescription)
                .WithMany(p => p.PrescriptionMedicaments)
                .HasForeignKey(pm => pm.IdPrescription);

            modelBuilder.Entity<PrescriptionMedicament>()
                .HasOne(pm => pm.Medicament)
                .WithMany(m => m.PrescriptionMedicaments)
                .HasForeignKey(pm => pm.IdMedicament);

           
            modelBuilder.Entity<Prescription>()
                .HasOne(p => p.Doctor)
                .WithMany(d => d.Prescriptions)
                .HasForeignKey(p => p.IdDoctor);

            modelBuilder.Entity<Prescription>()
                .HasOne(p => p.Patient)
                .WithMany(pat => pat.Prescriptions)
                .HasForeignKey(p => p.IdPatient);

            
            modelBuilder.Entity<Doctor>().HasData(
                new Doctor
                {
                    IdDoctor = 1,
                    FirstName = "Janush",
                    LastName = "Turing",
                    Email = "jkowalski@pejotwustk.com"
                }
            );

            
            modelBuilder.Entity<Medicament>().HasData(
                new Medicament
                {
                    IdMedicament = 1,
                    Name = "KApap",
                    Description = "Ból głowy"
                },
                new Medicament
                {
                    IdMedicament = 2,
                    Name = "kodeina",
                    Description = "Bolaczka"
                }
            );
            
            modelBuilder.Entity<Patient>().HasData(
                new Patient { IdPatient = 1, FirstName = "Anna", LastName = "Krawiec", BirthDate = new DateTime(1930, 9, 15) }
            );
            
            modelBuilder.Entity<Prescription>().HasData(
                new Prescription
                {
                    IdPrescription = 1,
                    Date = new DateTime(2025, 5, 25),
                    DueDate = new DateTime(2025, 6, 5),
                    IdDoctor = 1,
                    IdPatient = 1
                }
            );

            
            modelBuilder.Entity<PrescriptionMedicament>().HasData(
                new PrescriptionMedicament
                {
                    IdPrescription = 1,
                    IdMedicament = 1,
                    Dose = 2,
                    Description = "2 pastylki na dzien"
                }
            );
        
        }
    }
}
