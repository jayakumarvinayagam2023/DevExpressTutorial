using Microsoft.AspNetCore.Components;
using System.Collections.Generic;

namespace DxBlazorWebAssemblyApp
{
    public class EmployeeMainBase : ComponentBase
    {
        [Inject]
        public IEnumerable<Employee>? Employees { get; set; }

        [Inject]
        public IEmployeeDataService? EmployeeDataService { get; set; }

        protected IReadOnlyList<object>? SelectedDataItems { get; set; }
        protected override void OnInitialized()
        {
            base.OnInitialized();
            Employees = EmployeeDataService?.GetEmployees().Result;
            SelectedDataItems = new List<object>();
        }

        protected Task GenerateScanCover()
        {
            var selected = SelectedDataItems.Select(x => (x as Employee)).ToList();
            return Task.CompletedTask;
        }
    }
}
