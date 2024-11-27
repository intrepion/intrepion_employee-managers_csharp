using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Sco.SarTool.BusinessLogic.Entities;

public class ApplicationUserClaim : IdentityUserClaim<Guid>
{
    public ApplicationUser? ApplicationUserUpdatedBy { get; set; }

    // ActualPropertyPlaceholder
}
