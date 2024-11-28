﻿using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;
using ApplicationNamePlaceholder.BusinessLogic.Data;
using ApplicationNamePlaceholder.BusinessLogic.Entities.Records;
using Microsoft.EntityFrameworkCore;

namespace ApplicationNamePlaceholder.BusinessLogic.Entities.Importers;

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

        if (context.TableNamePlaceholder is null)
        {
            Console.WriteLine("Database table not found: context.TableNamePlaceholder");
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

        // EntityListCodePlaceholder

        foreach (var record in records)
        {
            // ManyToOneCodePlaceholder

            if (true
                // NullCheckCodePlaceholder
            )
            {
                var LowercaseNamePlaceholder = new EmployeeManager
                {
                    ApplicationUserUpdatedBy = applicationUserUpdatedBy,

                    // NewEntityCodePlaceholder
                };

                var dbEmployeeManager = await context.TableNamePlaceholder.SingleOrDefaultAsync(
                    x => true
                    // CompositeKeyCodePlaceholder
                );

                if (dbEmployeeManager is null)
                {
                    await context.TableNamePlaceholder.AddAsync(LowercaseNamePlaceholder);
                }
                else
                {
                    dbEmployeeManager.ApplicationUserUpdatedBy = applicationUserUpdatedBy;

                    // ExistingEntityCodePlaceholder
                }
            }
        }

        await context.SaveChangesAsync();
    }
}