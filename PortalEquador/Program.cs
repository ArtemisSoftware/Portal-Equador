using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PortalEquador.Data;
using PortalEquador.Data.Curriculum.Repository;
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
using PortalEquador.Data.PersonalInformation.Repository;
using PortalEquador.Data.Profession.Competence.Repository;
using PortalEquador.Data.Profession.Experience.Repository;
using PortalEquador.Domain.Curriculum.Repository;
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
using PortalEquador.Domain.PersonalInformation.Repository;
using PortalEquador.Domain.Profession.Competence.Repository;
using PortalEquador.Domain.Profession.Experience.Repository;
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

//MechanicalWorkshop
builder.Services.AddScoped<IMechanicalWorkshopVehicleRepository, MechanicalWorkshopVehicleRepositoryImpl>();
builder.Services.AddScoped<IMechanicalWorkshopSchedulerRepository, MechanicalWorkshopSchedulerRepositoryImpl>();
builder.Services.AddScoped<ICarWashSchedulerRepository, CarWashSchedulerRepositoryImpl>();
builder.Services.AddScoped<IAdminMechanicalWorkShopRepository, AdminMechanicalWorkShopRepositoryImpl>();
builder.Services.AddScoped<GetCarWashDayPlanUseCase>();
builder.Services.AddScoped<SearchCarWashDayPlanUseCase>();
builder.Services.AddScoped<GetDayPlanUseCase>();
builder.Services.AddScoped<SearchDayPlanUseCase>();


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
