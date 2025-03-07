using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Intrepion.EmployeeManagers.BusinessLogic.Entities;

public class ApplicationRoleClaim : IdentityRoleClaim<Guid>
{
    public ApplicationUser? ApplicationUserUpdatedBy { get; set; }
    public DateTime UpdateDateTime { get; set; }

    // ActualPropertyPlaceholder
}
