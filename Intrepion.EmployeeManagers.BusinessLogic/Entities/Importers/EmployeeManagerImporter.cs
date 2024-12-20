﻿using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;
using Intrepion.EmployeeManagers.BusinessLogic.Data;
using Intrepion.EmployeeManagers.BusinessLogic.Entities.Records;
using Microsoft.EntityFrameworkCore;

namespace Intrepion.EmployeeManagers.BusinessLogic.Entities.Importers;

public static class EmployeeManagerImporter
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

        if (context.EmployeeManagers is null)
        {
            Console.WriteLine("Database table not found: context.EmployeeManagers");
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

        var records = csv.GetRecords<EmployeeManagerRecord>();

        var employeeList = await context.Employees.ToListAsync();
        var managerList = await context.Employees.ToListAsync();
        // EntityListCodePlaceholder

        foreach (var record in records)
        {
            var employee = employeeList.FirstOrDefault(x =>
                true
                && x.NormalizedFirstName.Equals(record.Employee_NormalizedFirstName)
                && x.NormalizedLastName.Equals(record.Employee_NormalizedLastName)
            );

            var manager = managerList.FirstOrDefault(x =>
                true
                && x.NormalizedFirstName.Equals(record.Manager_NormalizedFirstName)
                && x.NormalizedLastName.Equals(record.Manager_NormalizedLastName)
            );

            // ManyToOneCodePlaceholder

            if (true
                && employee is not null
                && employee is not null
                && manager is not null
                && manager is not null
            // NullCheckCodePlaceholder
            )
            {
                var employeeManager = new EmployeeManager
                {
                    ApplicationUserUpdatedBy = applicationUserUpdatedBy,
                    UpdateDateTime = DateTime.UtcNow,

                    Employee = employee,
                    Manager = manager,
                    // NewEntityCodePlaceholder
                };

                var dbEmployeeManager = await context.EmployeeManagers.SingleOrDefaultAsync(
                    x => true
                    && x.Employee.Equals(employee)
                    && x.Employee.Equals(employee)
                    && x.Manager.Equals(manager)
                    && x.Manager.Equals(manager)
                    // CompositeKeyCodePlaceholder
                );

                if (dbEmployeeManager is null)
                {
                    await context.EmployeeManagers.AddAsync(employeeManager);
                }
                else
                {
                    dbEmployeeManager.ApplicationUserUpdatedBy = applicationUserUpdatedBy;
                    dbEmployeeManager.UpdateDateTime = DateTime.UtcNow;

                    dbEmployeeManager.Employee = employee;
                    dbEmployeeManager.Manager = manager;
                    // ExistingEntityCodePlaceholder
                }
            }
        }

        await context.SaveChangesAsync();
    }
}
