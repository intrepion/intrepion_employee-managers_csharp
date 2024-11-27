using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;
using ApplicationNamePlaceholder.BusinessLogic.Data;
using ApplicationNamePlaceholder.BusinessLogic.Entities.Records;
using Microsoft.EntityFrameworkCore;

namespace ApplicationNamePlaceholder.BusinessLogic.Entities.Importers;

public static class EmployeeImporter
{
    public static async Task ImportAsync(
       ApplicationDbContext context,
       string userName, string csvPath
    )
    {
        if (!File.Exists(csvPath))
        {
            Console.WriteLine("File not found: " + csvPath);
            return;
        }

        if (context.Employees is null)
        {
            Console.WriteLine("Database table not found: context.Employees");
            return;
        }

        var normalizedUserName = userName.ToUpperInvariant();
        var applicationUserUpdatedBy = await context.Users.SingleOrDefaultAsync(x => x.NormalizedUserName != null && x.NormalizedUserName.Equals(normalizedUserName));

        if (applicationUserUpdatedBy is null)
        {
            Console.WriteLine("UserName not found: " + userName);
            return;
        }

        using var reader = new StreamReader(csvPath);
        using var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)
        {
            PrepareHeaderForMatch = x => x.Header.ToUpper(CultureInfo.InvariantCulture),
            Delimiter = "|",
        });

        var records = csv.GetRecords<EmployeeRecord>();

        // EntityListCodePlaceholder

        foreach (var record in records)
        {
            // ManyToOneCodePlaceholder

            if (true
                // NullCheckCodePlaceholder
            )
            {
                var employee = new Employee
                {
                    ApplicationUserUpdatedBy = applicationUserUpdatedBy,

                    Email = record.Email,
                    // NewEntityCodePlaceholder
                };

                var dbEmployee = await context.Employees.SingleOrDefaultAsync(
                    x => true
                    && x.NormalizedFirstName.Equals(employee.NormalizedFirstName)
                    && x.NormalizedLastName.Equals(employee.NormalizedLastName)
                    // CompositeKeyCodePlaceholder
                );

                if (dbEmployee is null)
                {
                    await context.Employees.AddAsync(employee);
                }
                else
                {
                    dbEmployee.ApplicationUserUpdatedBy = applicationUserUpdatedBy;

                    dbEmployee.Email = record.Email;
                    // ExistingEntityCodePlaceholder
                }
            }
        }

        await context.SaveChangesAsync();
    }
}
