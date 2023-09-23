using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PortalEquador.Configurations;
using PortalEquador.Contracts;
using PortalEquador.Data;
using PortalEquador.Repositories;
using PortalEquador.Data.CurriculumVitae.Repository;
using PortalEquador.Domain.CurriculumVitae.UseCases;
using PortalEquador.Data.PersonalInformation.Repository;
using PortalEquador.Data.GroupTypes.Repositories;
using PortalEquador.Domain.GroupTypes.Repository;
using PortalEquador.Domain.GroupTypes.UseCases;
using PortalEquador.Domain.PersonalInformation.Repository;
using PortalEquador.Domain.CurriculumVitae.Repository;
using PortalEquador.Domain.PersonalInformation.UseCases;
using PortalEquador.Domain.Documents.UseCases;
using PortalEquador.Data.Document.Repository;
using PortalEquador.Domain.Repositories;
using PortalEquador.Data.DriversLicence.Repository;
using PortalEquador.Domain.DriversLicence.UseCases;
using PortalEquador.Domain.UseCases.DriversLicence;
using PortalEquador.Domain.Documents.Repository;
using PortalEquador.Domain.ProfessionalExperience.Repository;
using PortalEquador.Data.ProfessionalExperience.Repository;
using PortalEquador.Domain.ProfessionalCompetence.Repository;
using PortalEquador.Data.ProfessionalCompetence.Repository;
using PortalEquador.Domain.ProfessionalCompetence.UseCases;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<User>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>();



builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

//Group

builder.Services.AddScoped<GroupRepository, GroupRepositoryImpl>();
builder.Services.AddScoped<GetAllGroupsUseCase>();
builder.Services.AddScoped<GroupExistsUseCase>();
builder.Services.AddScoped<SaveGroupUseCase>();
builder.Services.AddScoped <GetGroupUseCase>();

//GroupItem

builder.Services.AddScoped<GroupItemRepository, GroupItemRepositoryImpl>();
builder.Services.AddScoped<GetAllGroupItemsUseCase>();
builder.Services.AddScoped<GroupItemExistsUseCase>();
builder.Services.AddScoped<SaveGroupItemUseCase>();
builder.Services.AddScoped<GetGroupItemUseCase> ();
builder.Services.AddScoped<UpdateGroupItemStateUseCase > ();

//Curriculum
builder.Services.AddScoped<CurriculumRepository, CurriculumRepositoryImpl>();
builder.Services.AddScoped <GetAllCurriculumsUseCase>();
builder.Services.AddScoped<GetCurriculumDashboardUseCase>();

//Personal Information
builder.Services.AddScoped<PersonalInformationRepository, PersonalInformationRepositoryImpl>();
builder.Services.AddScoped<GetPersonalInformationCreationModelUseCase>();
builder.Services.AddScoped<ValidateIdentityCardNumberUseCase> ();
builder.Services.AddScoped<SavePersonalInformationUseCase>();
builder.Services.AddScoped<GetPersonalInformationModelUseCase> ();
builder.Services.AddScoped<GetPersonalInformationDetailModelUseCase> ();

//Document
builder.Services.AddScoped<DocumentRepository, DocumentRepositoryImpl>();
builder.Services.AddScoped<SaveDocumentUseCase>();
builder.Services.AddScoped<GetDocumentCreationModelUseCase>();
builder.Services.AddScoped<GetAllDocumentsUseCase>();
builder.Services.AddScoped<DeleteDocumentUseCase> ();
builder.Services.AddScoped<DocumentExistsUseCase> ();

//Drivers Licence
builder.Services.AddScoped<DriversLicenceRepository, DriversLicenceRepositoryImpl>();
builder.Services.AddScoped<GetDriversLicenceCreationModelUseCase>();
builder.Services.AddScoped<SaveDriversLicenceUseCase> ();
builder.Services.AddScoped<GetDriversLicenceUseCase>();
builder.Services.AddScoped<GetDriversLicenceDetailModelUseCase> ();
builder.Services.AddScoped <GetAllDriversLicencesUseCase>();
builder.Services.AddScoped<RenewDriversLicenceUseCase> ();
builder.Services.AddScoped<RenewProvisionalUseCase> ();

//ProfessionalExperience
builder.Services.AddScoped<ProfessionalExperienceRepository, ProfessionalExperienceRepositoryImpl>();

//ProfessionalCompetence
builder.Services.AddScoped<ProfessionalCompetenceRepository, ProfessionalCompetenceRepositoryImpl>();
builder.Services.AddScoped<GetProfessionalCompetenceCreationUseCase>();

//-----*****

/*

builder.Services.AddScoped<DriversLicenceRepository, DriversLicenceRepositoryImpl>();


//Use cases
builder.Services.AddScoped<GetPersonalInformationUseCase>();
builder.Services.AddScoped < GetDriversLicenceCreationInfoUseCase>();

builder.Services.AddScoped<GetDocumentsByTypeUseCase>();

builder.Services.AddScoped<SaveDriversLicenceUseCase>();
builder.Services.AddScoped<SaveDocumentUseCase>();
builder.Services.AddScoped<GetAllDriversLicencesUseCase>();
builder.Services.AddScoped<GetDriversLicenceUseCase>();
builder.Services.AddScoped<GetDriversLicenceUseCase__>();
builder.Services.AddScoped<SaveDriversLicenceUseCase__>();
builder.Services.AddScoped<RenewDriversLicenceUseCase>();
*/
//---

//Group






//Repositories

//Use cases
//builder.Services.AddScoped<GetCurriculumDashboardUseCase>();

builder.Services.AddAutoMapper(typeof(MapperConfig));




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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
