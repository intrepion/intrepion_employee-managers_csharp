﻿using Sco.SarTool.BusinessLogic.Entities;
using Sco.SarTool.BusinessLogic.Entities.Importers;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace Sco.SarTool.BusinessLogic.Data;

public static class DatabaseUtility
{
    public static async Task EnsureDbCreatedAndSeedAsync(
        IServiceProvider serviceProvider
    )
    {
        using var scope = serviceProvider.CreateScope();
        var applicationDbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

        var isNewDatabase = await applicationDbContext.Database.EnsureCreatedAsync();

        var adminName = "Admin";
        var adminUserPass = adminName + "1@Sco.SarTool.com";
        var adminNormalizedUserName = adminUserPass.ToUpperInvariant();
        var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

        if (isNewDatabase)
        {
            var adminUser = (await applicationDbContext.Users.AddAsync(new ApplicationUser
            {
                Email = adminUserPass,
                EmailConfirmed = true,
                NormalizedEmail = adminUserPass.ToUpperInvariant(),
                NormalizedUserName = adminUserPass.ToUpperInvariant(),
                UserName = adminUserPass,
            })).Entity;

            await userManager.AddPasswordAsync(adminUser, adminUserPass);

            var adminRole = (await applicationDbContext.Roles.AddAsync(new ApplicationRole
            {
                Name = adminName,
                NormalizedName = adminName.ToUpperInvariant(),
            })).Entity;

            adminRole.ApplicationUserUpdatedBy = adminUser;
            adminUser.ApplicationUserUpdatedBy = adminUser;
            _ = await applicationDbContext.UserRoles.AddAsync(new ApplicationUserRole
            {
                RoleId = adminRole.Id,
                UserId = adminUser.Id,
                ApplicationUserUpdatedBy = adminUser,
            });

            // ReadDataCodePlaceholder

            // await FakeData.SeedAsync(applicationDbContext, adminUser);

            await applicationDbContext.SaveChangesAsync();
        }

        var baseDirectoryPath = AppDomain.CurrentDomain.BaseDirectory;

        var applicationRoleFileName = @"..\..\..\..\.data\ApplicationRole.csv";
        var applicationRoleCsvFilePath = Path.Combine(baseDirectoryPath, applicationRoleFileName);
        await ApplicationRoleImporter.ImportAsync(applicationDbContext, adminUserPass, applicationRoleCsvFilePath);

        var applicationUserRoleFileName = @"..\..\..\..\.data\ApplicationUserRole.csv";
        var applicationUserRoleCsvFilePath = Path.Combine(baseDirectoryPath, applicationUserRoleFileName);
        await ApplicationUserRoleImporter.ImportAsync(applicationDbContext, adminUserPass, applicationUserRoleCsvFilePath);

        var applicationUserFileName = @"..\..\..\..\.data\ApplicationUser.csv";
        var applicationUserCsvFilePath = Path.Combine(baseDirectoryPath, applicationUserFileName);
        await ApplicationUserImporter.ImportAsync(applicationDbContext, adminUserPass, applicationUserCsvFilePath);

        var employeeFileName = @"..\..\..\..\.data\Employee.csv";
        var employeeCsvFilePath = Path.Combine(baseDirectoryPath, employeeFileName);
        await EmployeeImporter.ImportAsync(applicationDbContext, adminUserPass, employeeCsvFilePath);

        var employeeManagerFileName = @"..\..\..\..\.data\EmployeeManager.csv";
        var employeeManagerCsvFilePath = Path.Combine(baseDirectoryPath, employeeManagerFileName);
        await EmployeeManagerImporter.ImportAsync(applicationDbContext, adminUserPass, employeeManagerCsvFilePath);

        // ImporterFirstCodePlaceholder

        await ApplicationRoleImporter.ImportAsync(applicationDbContext, adminUserPass, applicationRoleCsvFilePath);
        await ApplicationUserRoleImporter.ImportAsync(applicationDbContext, adminUserPass, applicationUserRoleCsvFilePath);
        await ApplicationUserImporter.ImportAsync(applicationDbContext, adminUserPass, applicationUserCsvFilePath);

        await EmployeeImporter.ImportAsync(applicationDbContext, adminUserPass, employeeCsvFilePath);
        await EmployeeManagerImporter.ImportAsync(applicationDbContext, adminUserPass, employeeManagerCsvFilePath);
        // ImporterSecondCodePlaceholder
    }
}
