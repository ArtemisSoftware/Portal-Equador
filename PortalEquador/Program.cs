using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PortalEquador.Configurations;
using PortalEquador.Contracts;
using PortalEquador.Data;
using PortalEquador.Domain.Repositories;
using PortalEquador.Repositories;
using PortalEquador.Data.DriversLicence.Repository;
using PortalEquador.Domain.UseCases.DriversLicence;
using PortalEquador.Domain.UseCases.Documents;
using PortalEquador.Domain.UseCases.PersonalInformation;
using PortalEquador.Domain.UseCases.CurriculumVitae;
using CurriculumRepository = PortalEquador.Repositories.CurriculumRepository;
using CurriculumRepository_ = PortalEquador.Domain.Repositories.CurriculumRepository;
using PortalEquador.Data.CurriculumVitae.Repository;

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
builder.Services.AddScoped<IGroupRepository, GroupRepository>();
builder.Services.AddScoped<IGroupItemRepository, GroupItemRepository>();

//-----
builder.Services.AddScoped<IPersonalInformationRepository, PersonalInformationRepository>();
builder.Services.AddScoped<ICurriculumRepository, CurriculumRepository>();
builder.Services.AddScoped<IDocumentRepository, DocumentRepository>();
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
//---

//Repositories
builder.Services.AddScoped<CurriculumRepository_, CurriculumRepositoryImpl>();

//Use cases
builder.Services.AddScoped<GetCurriculumDashboardUseCase>();

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
