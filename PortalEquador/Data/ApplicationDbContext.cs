using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PortalEquador.Data.Curriculum.Entities;
using PortalEquador.Data.Generic;
using PortalEquador.Data.GroupTypes.entities;
using PortalEquador.Data.PersonalInformation.Entity;
using PortalEquador.Data.Document.Entity;
using PortalEquador.Data.MechanicalWorkshop.Vehicle.Entity;
using PortalEquador.Data.MechanicalWorkshop.Scheduler.Entity;
using PortalEquador.Data.Languages.entity;
using PortalEquador.Data.Profession.Competence.Entity;
using PortalEquador.Data.Profession.Experience.Entity;
using PortalEquador.Data.Education.School.Entity;
using PortalEquador.Data.Education.University.Entity;
using PortalEquador.Data.DriversLicence.Entity;
using PortalEquador.Data.MechanicalWorkshop.CarWash.Entity;
using PortalEquador.Data.MechanicalWorkshop.Admin.Entity;
using PortalEquador.Util;
using PortalEquador.Data.Configurations.Entities;
using PortalEquador.Data.Contract.Entities;
using PortalEquador.Data.MedicalExam.Entity;
using PortalEquador.Data.Trainning.Entity;
using PortalEquador.Data.DisciplinaryNotification.Entity;
using PortalEquador.Data.Accident.Entities;
using PortalEquador.Data.Uniforms.Entities;

namespace PortalEquador.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            /*
            var hasher = new PasswordHasher<ApplicationUser>(); 
            string password = "Admin123"; 
            string hash = hasher.HashPassword(null, password); 
            Console.WriteLine("Hashed password:");
            Console.WriteLine(hash);
            */
        }

        public DbSet<GroupEntity> GroupEntity { get; set; }
        public DbSet<GroupItemEntity> GroupItemEntity { get; set; }
        public DbSet<CurriculumEntity> CurriculumEntity { get; set; }
        public DbSet<PersonalInformationEntity> PersonalInformationEntity { get; set; }
        public DbSet<DocumentEntity> DocumentEntity { get; set; } 
        public DbSet<MechanicalWorkshopVehicleEntity> MechanicalWorkshopVehicleEntity { get; set; }
        public DbSet<MechanicalWorkshopSchedulerEntity> MechanicalWorkshopSchedulerEntity { get; set; } = default!;
        public DbSet<LanguageEntity> LanguageEntity { get; set; } = default!;
        public DbSet<ProfessionalCompetenceEntity> ProfessionalCompetenceEntity { get; set; } = default!;
        public DbSet<ProfessionalExperienceEntity> ProfessionalExperienceEntity { get; set; } = default!;
        public DbSet<SchoolEntity> SchoolEntity { get; set; } = default!;
        public DbSet<UniversityEntity> UniversityEntity { get; set; } = default!;
        public DbSet<DriversLicenceEntity> DriversLicenceEntity { get; set; } = default!;
        public DbSet<CarWashSchedulerEntity> CarWashSchedulerEntity { get; set; }
        public DbSet<AdminMechanicalWorkShopContractEntity> AdminMechanicalWorkShopContractEntity { get; set; } = default!;
        public DbSet<MedicalExamEntity> MedicalExamEntity { get; set; } = default!;
        public DbSet<TrainningEntity> TrainningEntity { get; set; } = default!;
        public DbSet<DisciplinaryNotificationEntity> DisciplinaryNotificationEntity { get; set; } = default!;
        public DbSet<ContractEntity> ContractEntity { get; set; }
        public DbSet<AccidentEntity> AccidentEntity { get; set; }
        public DbSet<AccidentCauseEntity> AccidentCauseEntity { get; set; }
        public DbSet<UniformEntity> UniformEntity { get; set; }
        public DbSet<WorkerUniformEntity> WorkerUniformEntity { get; set; }
    }
}
