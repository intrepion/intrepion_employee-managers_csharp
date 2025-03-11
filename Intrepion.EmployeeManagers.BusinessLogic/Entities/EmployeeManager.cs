using System.ComponentModel.DataAnnotations;

namespace Intrepion.EmployeeManagers.BusinessLogic.Entities;

public class EmployeeManager
{
    public ApplicationUser? ApplicationUserUpdatedBy { get; set; }
    public Guid Id { get; set; }
    public DateTime UpdateDateTime { get; set; }

    public Employee? Employee { get; set; }
    public Employee? Manager { get; set; }
    // ActualPropertyPlaceholder
}
