namespace Intrepion.EmployeeManagers.BusinessLogic.Grid.Admin.EmployeeManagerGrid;

public class EmployeeManagerGridControls(IPageHelper pageHelper) : IEmployeeManagerFilters
{
    public IPageHelper PageHelper { get; set; } = pageHelper;

    public bool Loading { get; set; }

    public EmployeeManagerFilterColumns SortColumn { get; set; } = EmployeeManagerFilterColumns.Id;

    public bool SortAscending { get; set; } = true;

    public EmployeeManagerFilterColumns FilterColumn { get; set; } = EmployeeManagerFilterColumns.Id;

    public string? FilterText { get; set; }
}
