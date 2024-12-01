using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Intrepion.EmployeeManagers.BusinessLogic.Entities;

public class ApplicationRole : IdentityRole<Guid>
{
    public ICollection<ApplicationUserRole> ApplicationUserRoles { get; set; } = [];
    public ApplicationUser? ApplicationUserUpdatedBy { get; set; }
    public DateTime UpdateDateTime { get; set; }

    // ActualPropertyPlaceholder
}
