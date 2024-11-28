using System.Diagnostics;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Intrepion.EmployeeManagers.BusinessLogic.Entities;

namespace Intrepion.EmployeeManagers.BusinessLogic.Grid.Admin.EmployeeGrid;

public class EmployeeGridQueryAdapter
{
    private readonly IEmployeeFilters controls;

    private readonly Dictionary<EmployeeFilterColumns, Expression<Func<Employee, string>>> expressions =
        new()
        {
            { EmployeeFilterColumns.Id, x => !x.Id.Equals(Guid.Empty) ? x.Id.ToString() : string.Empty },

            // SortExpressionCodePlaceholder
        };

    private readonly Dictionary<EmployeeFilterColumns, Func<IQueryable<Employee>, IQueryable<Employee>>> filterQueries = [];

    public EmployeeGridQueryAdapter(IEmployeeFilters controls)
    {
        this.controls = controls;

        filterQueries =
            new()
            {
                { EmployeeFilterColumns.Id, x => x.Where(y => y != null && !y.Id.Equals(Guid.Empty) && this.controls.FilterText != null && y.Id.ToString().Contains(this.controls.FilterText) ) },

                // QueryExpressionCodePlaceholder
            };
    }

    public async Task<ICollection<Employee>> FetchAsync(IQueryable<Employee> query)
    {
        query = FilterAndQuery(query);
        await CountAsync(query);
        var collection = await FetchPageQuery(query).ToListAsync();
        controls.PageHelper.PageItems = collection.Count;
        return collection;
    }

    public async Task CountAsync(IQueryable<Employee> query) =>
        controls.PageHelper.TotalItemCount = await query.CountAsync();

    public IQueryable<Employee> FetchPageQuery(IQueryable<Employee> query) =>
        query
            .Skip(controls.PageHelper.Skip)
            .Take(controls.PageHelper.PageSize)
            .AsNoTracking();

    private IQueryable<Employee> FilterAndQuery(IQueryable<Employee> root)
    {
        var sb = new System.Text.StringBuilder();

        if (!string.IsNullOrWhiteSpace(controls.FilterText))
        {
            var filter = filterQueries[controls.FilterColumn];
            sb.Append($"Filter: '{controls.FilterColumn}' ");
            root = filter(root);
        }

        var expression = expressions[controls.SortColumn];
        sb.Append($"Sort: '{controls.SortColumn}' ");

        var sortDir = controls.SortAscending ? "ASC" : "DESC";
        sb.Append(sortDir);

        Debug.WriteLine(sb.ToString());

        return controls.SortAscending ? root.OrderBy(expression) : root.OrderByDescending(expression);
    }
}
