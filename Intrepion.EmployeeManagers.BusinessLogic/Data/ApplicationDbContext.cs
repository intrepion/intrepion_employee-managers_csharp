using Intrepion.EmployeeManagers.BusinessLogic.Entities;
using Intrepion.EmployeeManagers.BusinessLogic.Entities.Configuration;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Intrepion.EmployeeManagers.BusinessLogic.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser, ApplicationRole, Guid, ApplicationUserClaim, ApplicationUserRole, ApplicationUserLogin, ApplicationRoleClaim, ApplicationUserToken>(options)
{
    public DbSet<Employee> Employees { get; set; }
    public DbSet<EmployeeManager> EmployeeManagers { get; set; }
    // DbSetCodePlaceholder

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        new ApplicationRoleClaimEtc().Configure(builder.Entity<ApplicationRoleClaim>());
        new ApplicationRoleEtc().Configure(builder.Entity<ApplicationRole>());
        new ApplicationUserClaimEtc().Configure(builder.Entity<ApplicationUserClaim>());
        new ApplicationUserEtc().Configure(builder.Entity<ApplicationUser>());
        new ApplicationUserLoginEtc().Configure(builder.Entity<ApplicationUserLogin>());
        new ApplicationUserRoleEtc().Configure(builder.Entity<ApplicationUserRole>());
        new ApplicationUserTokenEtc().Configure(builder.Entity<ApplicationUserToken>());

        new EmployeeEtc().Configure(builder.Entity<Employee>());
        new EmployeeManagerEtc().Configure(builder.Entity<EmployeeManager>());
        // EntityTypeCfgCodePlaceholder
    }
}
