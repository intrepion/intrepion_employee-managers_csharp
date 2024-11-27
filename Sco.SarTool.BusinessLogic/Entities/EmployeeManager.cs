using System.ComponentModel.DataAnnotations;

namespace Sco.SarTool.BusinessLogic.Entities;

public class EmployeeManager
{
    public ApplicationUser? ApplicationUserUpdatedBy { get; set; }
    public Guid Id { get; set; }

    public Employee? Employee { get; set; }
    public Employee? Manager { get; set; }
    // ActualPropertyPlaceholder
}
