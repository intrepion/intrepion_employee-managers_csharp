namespace Intrepion.EmployeeManagers.BusinessLogic.Grid.Admin.EmployeeManagerGrid;

public interface IEmployeeManagerFilters
{
    EmployeeManagerFilterColumns FilterColumn { get; set; }

    bool Loading { get; set; }

    string? FilterText { get; set; }

    IPageHelper PageHelper { get; set; }

    bool SortAscending { get; set; }

    EmployeeManagerFilterColumns SortColumn { get; set; }
}
