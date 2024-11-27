using System.ComponentModel.DataAnnotations;

namespace ApplicationNamePlaceholder.BusinessLogic.Entities;

public class Employee
{
    public ApplicationUser? ApplicationUserUpdatedBy { get; set; }
    public Guid Id { get; set; }

    public ApplicationUser? ApplicationUser { get; set; }
    [Required]
    public string Email { get; set; } = string.Empty;
    [Required]
    public string NormalizedEmail { get; set; } = string.Empty;
    public ICollection<EmployeeManager> EmployeeManagers { get; set; } = [];
    [Required]
    public string FirstName { get; set; } = string.Empty;
    [Required]
    public string NormalizedFirstName { get; set; } = string.Empty;
    public bool IsTest { get; set; }
    public bool IsVerified { get; set; }
    [Required]
    public string LastName { get; set; } = string.Empty;
    [Required]
    // ActualPropertyPlaceholder
}
