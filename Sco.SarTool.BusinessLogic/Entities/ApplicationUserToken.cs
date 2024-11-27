using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Sco.SarTool.BusinessLogic.Entities;

public class ApplicationUserToken : IdentityUserToken<Guid>
{
    public ApplicationUser? ApplicationUserUpdatedBy { get; set; }

    // ActualPropertyPlaceholder
}
