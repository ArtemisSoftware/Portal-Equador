using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PortalEquador.Data.Generic;
using PortalEquador.Data.MechanicalWorkshop;
using PortalEquador.Data.MechanicalWorkshop.Admin.Entity;
using PortalEquador.Domain.Administrator.Repository;
using PortalEquador.Domain.Administrator.ViewModels;
using PortalEquador.Util;

namespace PortalEquador.Data.Administrator.Repository
{
    public class AdministratorRepositoryImpl(
        ApplicationDbContext context,
        IMapper mapper,
        IHttpContextAccessor httpContextAccessor,
        IWebHostEnvironment hostEnvironment,
        UserManager<ApplicationUser> userManager,
        RoleManager<IdentityRole> roleManager
        ) : GenericRepository<AdminMechanicalWorkShopContractEntity>(context, httpContextAccessor), IAdministratorRepository
    {
        public async Task<List<AdministratorViewModel>> GetAll()
        {
            var hasFullAccess = AdministratorUtil.HasFullAccess(GetCurrentUserRole());

            var usersWithRolesQuery = (
                from user in context.Users
                join userRole in context.UserRoles on user.Id equals userRole.UserId
                join role in context.Roles on userRole.RoleId equals role.Id
                orderby role.Name, user.FirstName 
                select new AdministratorViewModel
                {
                    Id = user.Id,
                    UserName  = user.FirstName + " " + user.LastName,
                    Email  = user.NormalizedEmail.ToLower(),
                    Role = role.Name,
                    Active = !user.LockoutEnabled,
                    Password = user.PasswordHash
                }
            );

            if (!hasFullAccess)
            {
                usersWithRolesQuery = usersWithRolesQuery
                    .Where(u => u.Role != "Administrator" );
            }

            var usersWithRoles = await usersWithRolesQuery.ToListAsync();

            return usersWithRoles;
        }

        public async Task<AdministratorCreateViewModel> GetCreateModel()
        {
            var roles = await GetAllRolesAsync();

            return new AdministratorCreateViewModel
            {
                Roles = roles,
            };
        }

        private async Task<SelectList> GetAllRolesAsync()
        {

            var role = GetCurrentUserRole();
            var hasFullAccess = AdministratorUtil.HasFullAccess(role);

            var rolesQuery = context.Roles.AsQueryable();

            if(role == Roles.DataManager)
            {
                rolesQuery = rolesQuery.Where(r =>
                r.Name != "Administrator" &&
                r.Name != "Employee" &&
                r.Name != "Guest"
                );
            } else if (hasFullAccess == false)
            {
                rolesQuery = rolesQuery.Where(r => 
                r.Name != "Administrator" && 
                r.Name != "DataManager" &&
                r.Name != "Employee" && 
                r.Name != "Guest"
                );

            } else
            {
                rolesQuery = rolesQuery.Where(r => 
                r.Name != "Employee" && 
                r.Name != "Guest"
                );
            }

            var roles = await rolesQuery
                .Select(r => new
                {
                    Id = r.Id,
                    Description = r.Name
                })
                .ToListAsync();

            return new SelectList(roles, "Id", "Description");
        }

        public async Task<bool> EmailExistsAsync(string email)
        {
            return await context.Users.AnyAsync(u => u.Email.ToLower() == email.ToLower());
        }


        public async Task<IdentityResult> Save(AdministratorCreateViewModel model)
        {
            var hasher = new PasswordHasher<ApplicationUser>();
            var passwordHash = hasher.HashPassword(null, model.Password);

            var user = new ApplicationUser
            {
                Email = model.Email,
                NormalizedEmail = model.Email.ToUpper(),
                NormalizedUserName = model.Email.ToUpper(),
                UserName = model.Email,
                EmailConfirmed = true,
                FirstName = model.FirstName,
                LastName = model.LastName,
                PasswordHash = passwordHash
            };

            // Create user
            var result = await userManager.CreateAsync(user);
            if (!result.Succeeded)
                return result;

            // Add role if provided
            if (!string.IsNullOrEmpty(model.RoleId))
            {
                var role = await roleManager.FindByIdAsync(model.RoleId);
                if (role != null)
                {
                    await userManager.AddToRoleAsync(user, role.Name);
                }
            }

            return result;
        }

        public async Task<IdentityResult> ResetPasswordAsync(string userId, string newPassword)
        {
            var user = await userManager.FindByIdAsync(userId);
            if (user == null)
                throw new Exception("User not found.");

            var token = await userManager.GeneratePasswordResetTokenAsync(user);
            var result = await userManager.ResetPasswordAsync(user, token, newPassword);



            return result;
        }

        public async Task<AdministratorEditViewModel> GetAdmin(string userId)
        {
            var admin = await (
                from user in context.Users
                join userRole in context.UserRoles on user.Id equals userRole.UserId
                join role in context.Roles on userRole.RoleId equals role.Id
                where user.Id == userId
                select new AdministratorEditViewModel
                {
                    Id = user.Id,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,
                    Role = role.Name
                }
            ).FirstOrDefaultAsync();

            return admin;
        }

        public async Task<AdministratorResetPasswordViewModel> GetResetPasswordAdmin(string userId)
        {



            var admin = await (
                from user in context.Users
                join userRole in context.UserRoles on user.Id equals userRole.UserId
                join role in context.Roles on userRole.RoleId equals role.Id
                where user.Id == userId
                select new AdministratorResetPasswordViewModel
                {
                    Id = user.Id,
                    UserName = user.FirstName + " " + user.LastName,
                    Email = user.Email,
                }
            ).FirstOrDefaultAsync();

            var password = PasswordGenerator.GeneratePassword(admin.UserName);
            admin.Password = password;

            return admin;
        }


        public async Task<IdentityResult> Update(AdministratorEditViewModel model)
        {
            var user = await userManager.FindByIdAsync(model.Id);
            if (user == null)
                throw new Exception($"User with ID '{model.Id}' not found.");

            var token = await userManager.GeneratePasswordResetTokenAsync(user);
            var passwordResult = await userManager.ResetPasswordAsync(user, token, model.Password);
            
            if (!passwordResult.Succeeded)
                return passwordResult;

            if (!string.IsNullOrEmpty(model.Role))
            {
                // Remove all existing roles
                var currentRoles = await userManager.GetRolesAsync(user);
                if (currentRoles.Any())
                    await userManager.RemoveFromRolesAsync(user, currentRoles);

                // Ensure new role exists
                var roleExists = await roleManager.RoleExistsAsync(model.Role);
                if (!roleExists)
                    await roleManager.CreateAsync(new IdentityRole(model.Role));

                // Assign new role
                await userManager.AddToRoleAsync(user, model.Role);
            }

            return IdentityResult.Success;
        }

        public async Task<IdentityResult> SetUserActiveStatus(string userId, bool isActive)
        {
            var user = await userManager.FindByIdAsync(userId);
            if (user == null)
                throw new Exception($"User with ID '{userId}' not found.");

            user.LockoutEnabled = true;

            if (isActive)
            {
                // ✅ Reactivate user
                user.LockoutEnd = null;
            }
            else
            {
                // 🚫 Deactivate user indefinitely
                user.LockoutEnd = DateTimeOffset.MaxValue;
            }

            return await userManager.UpdateAsync(user);
        }
    }
}
