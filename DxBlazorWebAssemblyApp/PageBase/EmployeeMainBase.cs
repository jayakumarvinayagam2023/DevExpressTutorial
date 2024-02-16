using DevExpress.Blazor;
using Microsoft.AspNetCore.Components;

namespace DxBlazorWebAssemblyApp
{
    public class EmployeeMainBase : ComponentBase
    {
        [Inject]
        public IEnumerable<Employee>? Employees { get; set; }

        [Inject]
        public IEmployeeDataService? EmployeeDataService { get; set; }

        protected IReadOnlyList<object>? SelectedDataItems { get; set; }
        protected object? SelectedDataItem { get; set; }
        private string? SelectionChangesInfo { get; set; }
        public bool IsReplace { get; set; }

        protected IGrid Grid { get; set; }

        protected bool IsPopUpVisible { get; set; }
        protected string? BorrowerLevelDocumentsWarnContent { get; set;  }
        protected override void OnInitialized()
        {
            base.OnInitialized();
            Employees = EmployeeDataService?.GetEmployees().Result;
            SelectedDataItems = new List<object>();
            SelectedDataItem = Employees?.FirstOrDefault();
        }

        protected async Task GenerateScanCover()
        {
            var selectedGridRows = SelectedDataItems!.Select(x => (x as Employee)).ToList();
            if(selectedGridRows is not null && !selectedGridRows.Any())
            {
                BorrowerLevelDocumentsWarnContent = PopUpConstants.NoBorrowerLevelDocuments;
                IsPopUpVisible = true;
            }
        }

        protected void OnSelectedDataItemChanged(object newSelection)
        {
            //var selectedRow = (newSelection as Employee);
            //Grid.SelectDataItems(GetEmployeeById(selectedRow!));
            //SelectionChangesInfo = "You selected '" + (newSelection as Employee).FirstName +
            //"' and deselected '" + (SelectedDataItem as Employee).FirstName + "'";
            //SelectedDataItem = newSelection;
        }

        protected void Grid_CustomizeEditModel(GridCustomizeEditModelEventArgs e)
        {
            var dataItem = (Employee)e.DataItem;
            if (e.IsNew)
            {
                
            }
        }

        protected async Task Grid_EditModelSaving(GridEditModelSavingEventArgs e)
        {
            //if (e.IsNew)
            //    await NwindDataService.InsertEmployeeAsync((EditableEmployee)e.EditModel);
            //else
            //    await NwindDataService.UpdateEmployeeAsync((EditableEmployee)e.DataItem, (EditableEmployee)e.EditModel);
            //await UpdateDataAsync();
        }
        private IEnumerable<Employee> GetEmployeeById(Employee employee)
        {
            return Employees!.Where(p => p.Id == employee.Id);
        }
    }

    public static class PopUpConstants
    {
        public static readonly string NoBorrowerLevelDocuments = "No documents are selected!";
        public static readonly string NoFileReplaceBorrowerLevelDocuments = "You have selected a document record that already has a file attached, and you have not requested the file be replaced. Please either check the Replace File check box or uncheck the document record.";
    }
}
