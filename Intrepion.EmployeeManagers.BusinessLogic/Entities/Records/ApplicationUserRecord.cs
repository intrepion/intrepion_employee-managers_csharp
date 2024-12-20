﻿namespace Intrepion.EmployeeManagers.BusinessLogic.Entities.Records;

public class ApplicationUserRecord
{
    public string Email { get; set; } = string.Empty;
    public bool EmailConfirmed { get; set; }
    public string Password { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public string UserName { get; set; } = string.Empty;

    public string Employee_NormalizedFirstName { get; set; } = string.Empty;
    public string Employee_NormalizedLastName { get; set; } = string.Empty;
    // RecordPropertyCodePlaceholder
}
