using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Sco.SarTool.BusinessLogic.Entities;

public class ApplicationRoleClaim : IdentityRoleClaim<Guid>
{
    public ApplicationUser? ApplicationUserUpdatedBy { get; set; }

    // ActualPropertyPlaceholder
}
