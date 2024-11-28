using System.ComponentModel.DataAnnotations;

namespace ApplicationNamePlaceholder.BusinessLogic.Entities;

public class Employee
{
    public ApplicationUser? ApplicationUserUpdatedBy { get; set; }
    public Guid Id { get; set; }
    public DateTime CreateDateTime { get; set; }
    public DateTime UpdateDateTime { get; set; }

    public ApplicationUser? ApplicationUser { get; set; }
    public ICollection<EmployeeManager> EmployeeManagers { get; set; } = [];
    [Required]
    public string FirstName { get; set; } = string.Empty;
    [Required]
    public string NormalizedFirstName { get; set; } = string.Empty;
    // ActualPropertyPlaceholder
}
