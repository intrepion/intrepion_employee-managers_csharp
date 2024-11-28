namespace Intrepion.EmployeeManagers.BusinessLogic.Grid.Admin.EmployeeGrid;

public class EmployeeGridControls(IPageHelper pageHelper) : IEmployeeFilters
{
    public IPageHelper PageHelper { get; set; } = pageHelper;

    public bool Loading { get; set; }

    public EmployeeFilterColumns SortColumn { get; set; } = EmployeeFilterColumns.Id;

    public bool SortAscending { get; set; } = true;

    public EmployeeFilterColumns FilterColumn { get; set; } = EmployeeFilterColumns.Id;

    public string? FilterText { get; set; }
}
