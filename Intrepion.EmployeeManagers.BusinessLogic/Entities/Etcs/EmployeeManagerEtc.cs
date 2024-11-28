using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApplicationNamePlaceholder.BusinessLogic.Entities.Configuration;

public class EmployeeManagerEtc : IEntityTypeConfiguration<EmployeeManager>
{
    public void Configure(EntityTypeBuilder<EmployeeManager> builder)
    {
        builder.HasOne(x => x.ApplicationUserUpdatedBy)
            .WithMany(x => x.UpdatedEmployeeManagers)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.Employee)
            .WithMany(x => x.EmployeeManagers)
            .OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(x => x.Manager)
            .WithMany(x => x.ManagerEmployees)
            .OnDelete(DeleteBehavior.Restrict);
        // EntityConfigurationCodePlaceholder
    }
}
