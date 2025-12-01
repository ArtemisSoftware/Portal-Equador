using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PortalEquador.Data;
using PortalEquador.Data.Accident.Repository;
using PortalEquador.Data.Administrator.Repository;
using PortalEquador.Data.Contract.Repository;
using PortalEquador.Data.Curriculum.Repository;
using PortalEquador.Data.DisciplinaryNotification.Repository;
using PortalEquador.Data.Document.Repository;
using PortalEquador.Data.DriversLicence.Repository;
using PortalEquador.Data.Education.School.Repository;
using PortalEquador.Data.Education.University.Repository;
using PortalEquador.Data.Generic;
using PortalEquador.Data.GroupTypes.repository;
using PortalEquador.Data.Languages.Repository;
using PortalEquador.Data.MechanicalWorkshop.Admin.Repository;
using PortalEquador.Data.MechanicalWorkshop.CarWash.Repository;
using PortalEquador.Data.MechanicalWorkshop.Scheduler.Repository;
using PortalEquador.Data.MechanicalWorkshop.Vehicle.Repository;
using PortalEquador.Data.MechanicalWorkshop.Workshop.Repository;
using PortalEquador.Data.MedicalExam.Repository;
using PortalEquador.Data.PersonalInformation.Repository;
using PortalEquador.Data.Profession.Competence.Repository;
using PortalEquador.Data.Profession.Experience.Repository;
using PortalEquador.Data.Report.Repository;
using PortalEquador.Data.Trainning.Repository;
using PortalEquador.Data.Uniforms.Repository;
using PortalEquador.Domain.Accident.Repository;
using PortalEquador.Domain.Accident.UseCases;
using PortalEquador.Domain.Administrator.Repository;
using PortalEquador.Domain.Contract.Repository;
using PortalEquador.Domain.Curriculum.Repository;
using PortalEquador.Domain.DisciplinaryNotification.Repository;
using PortalEquador.Domain.DisciplinaryNotification.UseCases;
using PortalEquador.Domain.Document;
using PortalEquador.Domain.Document.Repository;
using PortalEquador.Domain.DriversLicence.Repository;
using PortalEquador.Domain.DriversLicence.UseCases;
using PortalEquador.Domain.Education.School.Repository;
using PortalEquador.Domain.Education.University.Repository;
using PortalEquador.Domain.Generic;
using PortalEquador.Domain.GroupTypes.Repository;
using PortalEquador.Domain.Languages.Repository;
using PortalEquador.Domain.MechanicalWorkshop.Admin.Repository;
using PortalEquador.Domain.MechanicalWorkshop.CarWash.Repository;
using PortalEquador.Domain.MechanicalWorkshop.CarWash.UseCase;
using PortalEquador.Domain.MechanicalWorkshop.Scheduler.Repository;
using PortalEquador.Domain.MechanicalWorkshop.Scheduler.UseCase;
using PortalEquador.Domain.MechanicalWorkshop.Vehicle.Repository;
using PortalEquador.Domain.MechanicalWorkshop.Vehicle.UseCases;
using PortalEquador.Domain.MechanicalWorkshop.Workshop.Repository;
using PortalEquador.Domain.MedicalExam.Repository;
using PortalEquador.Domain.MedicalExam.UseCases;
using PortalEquador.Domain.PersonalInformation.Repository;
using PortalEquador.Domain.Profession.Competence.Repository;
using PortalEquador.Domain.Profession.Experience.Repository;
using PortalEquador.Domain.Report.Repository;
using PortalEquador.Domain.Report.UseCases;
using PortalEquador.Domain.Trainning.Repository;
using PortalEquador.Domain.Trainning.UseCases;
using PortalEquador.Domain.Uniforms.Repository;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();


builder.Services.AddHttpContextAccessor();

builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

//Group

builder.Services.AddScoped<GroupRepository, GroupRepositoryImpl>();
builder.Services.AddScoped<GroupItemRepository, GroupItemRepositoryImpl>();

//Curriculum
builder.Services.AddScoped<CurriculumRepository, CurriculumRepositoryImpl>();
builder.Services.AddScoped<IPersonalInformationRepository, PersonalInformationRepositoryImpl>();
builder.Services.AddScoped<IDocumentRepository, DocumentRepositoryImpl>();
builder.Services.AddScoped<ILanguageRepository, LanguageRepositoryImpl>();
builder.Services.AddScoped<IProfessionalCompetenceRepository, ProfessionalCompetenceRepositoryImpl>();
builder.Services.AddScoped<IProfessionalExperienceRepository, ProfessionalExperienceRepositoryImpl>();
builder.Services.AddScoped<IDriversLicenceRepository, DriversLicenceRepositoryImpl>();
builder.Services.AddScoped<IUniversityRepository, UniversityRepositoryImpl>();
builder.Services.AddScoped<ISchoolRepository, SchoolRepositoryImpl>();
builder.Services.AddScoped<DeleteDocumentUseCase>();

//Drivers Licence
builder.Services.AddScoped<IDriversLicenceRepository, DriversLicenceRepositoryImpl>();
builder.Services.AddScoped<SaveDriversLicenceUseCase>();
builder.Services.AddScoped<RenewDriversLicenceUseCase>();
builder.Services.AddScoped<SaveProvisionalUseCase>();
builder.Services.AddScoped<GetDriversLicenceDetailUseCase> ();
builder.Services.AddScoped<GetDriversLicenceRenewUseCase> ();
builder.Services.AddScoped<GetDriversLicenceProvisionalUseCase>();
builder.Services.AddScoped<GetDriversLicenceProvisionalRenewUseCase> ();
builder.Services.AddScoped<GetDriversLicenceUseCase> ();
builder.Services.AddScoped<DeleteDriversLicenceUseCase>();
builder.Services.AddScoped<GetDriversLicenceCreateModelUseCase> ();

//MechanicalWorkshop
builder.Services.AddScoped<IMechanicalWorkshopVehicleRepository, MechanicalWorkshopVehicleRepositoryImpl>();
builder.Services.AddScoped<IMechanicalWorkshopSchedulerRepository, MechanicalWorkshopSchedulerRepositoryImpl>();
builder.Services.AddScoped<ICarWashSchedulerRepository, CarWashSchedulerRepositoryImpl>();
builder.Services.AddScoped<IAdminMechanicalWorkShopRepository, AdminMechanicalWorkShopRepositoryImpl>();
builder.Services.AddScoped<GetCarWashDayPlanUseCase>();
builder.Services.AddScoped<SearchCarWashDayPlanUseCase>();
builder.Services.AddScoped<GetDayPlanUseCase>();
builder.Services.AddScoped<SearchDayPlanUseCase>();
builder.Services.AddScoped<GetVehiclesUseCase> ();
builder.Services.AddScoped<GetVehicleUseCase> ();
builder.Services.AddScoped<IWorkshopRepository, WorkshopRepositoryImpl>();

//Contract
builder.Services.AddScoped<IContractRepository, ContractRepositoryImpl>();
builder.Services.AddScoped<IMedicalExamRepository, MedicalExamRepositoryImpl>();
builder.Services.AddScoped<ITrainningRepository, TrainningRepositoryImpl>();
builder.Services.AddScoped<IDisciplinaryNotificationRepository, DisciplinaryNotificationRepositoryImpl>();
builder.Services.AddScoped<SaveMedicalExamUseCase>();
builder.Services.AddScoped<SaveTrainningUseCase>();
builder.Services.AddScoped<SaveDisciplinaryNotificationUseCase>();
builder.Services.AddScoped<DeleteMedicalExamUseCase>();
builder.Services.AddScoped<DeleteTrainningUseCase>();
builder.Services.AddScoped<DeleteDisciplinaryNotificationUseCase>();

// Report
builder.Services.AddScoped<IReportRepository, ReportRepositoryImpl>();
builder.Services.AddScoped<GetAlchoolTestReportUseCase>();
builder.Services.AddScoped<GetDriversLicenceReportUseCase>();
builder.Services.AddScoped<GetAgeReportUseCase>();
builder.Services.AddScoped<GetMedicalExamReportUseCase>();
builder.Services.AddScoped<GetProfessionalExperienceReportUseCase>();
builder.Services.AddScoped<GetTrainningReportUseCase> ();
builder.Services.AddScoped<GetAccidentReportUseCase> ();
builder.Services.AddScoped<GetUniformsReportFormUseCase>();
builder.Services.AddScoped<GetUniformsReportUseCase>();


builder.Services.AddScoped<IAccidentRepository, AccidentRepositoryImpl>();
builder.Services.AddScoped<IAccidentCauseRepository, AccidentCauseRepositoryImpl>();
builder.Services.AddScoped <SaveAccidentUseCase>();
builder.Services.AddScoped<DeleteAccidentUseCase>();

builder.Services.AddScoped<IUniformRepository, UniformRepositoryImpl>();
builder.Services.AddScoped<IWorkerUniformRepository, WorkerUniformRepositoryImpl>();
builder.Services.AddScoped<IAdministratorRepository, AdministratorRepositoryImpl>();




builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
