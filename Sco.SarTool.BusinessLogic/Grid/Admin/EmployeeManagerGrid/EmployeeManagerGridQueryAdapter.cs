using System.Diagnostics;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Sco.SarTool.BusinessLogic.Entities;

namespace Sco.SarTool.BusinessLogic.Grid.Admin.EmployeeManagerGrid;

public class EmployeeManagerGridQueryAdapter
{
    private readonly IEmployeeManagerFilters controls;

    private readonly Dictionary<EmployeeManagerFilterColumns, Expression<Func<EmployeeManager, string>>> expressions =
        new()
        {
            { EmployeeManagerFilterColumns.Id, x => !x.Id.Equals(Guid.Empty) ? x.Id.ToString() : string.Empty },

            // SortExpressionCodePlaceholder
        };

    private readonly Dictionary<EmployeeManagerFilterColumns, Func<IQueryable<EmployeeManager>, IQueryable<EmployeeManager>>> filterQueries = [];

    public EmployeeManagerGridQueryAdapter(IEmployeeManagerFilters controls)
    {
        this.controls = controls;

        filterQueries =
            new()
            {
                { EmployeeManagerFilterColumns.Id, x => x.Where(y => y != null && !y.Id.Equals(Guid.Empty) && this.controls.FilterText != null && y.Id.ToString().Contains(this.controls.FilterText) ) },

                // QueryExpressionCodePlaceholder
            };
    }

    public async Task<ICollection<EmployeeManager>> FetchAsync(IQueryable<EmployeeManager> query)
    {
        query = FilterAndQuery(query);
        await CountAsync(query);
        var collection = await FetchPageQuery(query).ToListAsync();
        controls.PageHelper.PageItems = collection.Count;
        return collection;
    }

    public async Task CountAsync(IQueryable<EmployeeManager> query) =>
        controls.PageHelper.TotalItemCount = await query.CountAsync();

    public IQueryable<EmployeeManager> FetchPageQuery(IQueryable<EmployeeManager> query) =>
        query
            .Skip(controls.PageHelper.Skip)
            .Take(controls.PageHelper.PageSize)
            .AsNoTracking();

    private IQueryable<EmployeeManager> FilterAndQuery(IQueryable<EmployeeManager> root)
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
