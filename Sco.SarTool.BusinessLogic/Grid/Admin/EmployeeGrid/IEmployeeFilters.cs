namespace Sco.SarTool.BusinessLogic.Grid.Admin.EmployeeGrid;

public interface IEmployeeFilters
{
    EmployeeFilterColumns FilterColumn { get; set; }

    bool Loading { get; set; }

    string? FilterText { get; set; }

    IPageHelper PageHelper { get; set; }

    bool SortAscending { get; set; }

    EmployeeFilterColumns SortColumn { get; set; }
}
