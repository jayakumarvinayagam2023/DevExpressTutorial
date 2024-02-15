namespace DxBlazorWebAssemblyApp
{
    public record Employee
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string? LastName { get; set; }
        public string? Department { get; init; }
        public string? Address { get; set; }
        public string? Phone { get; set; }
        public bool ReplaceFile { get; set; } = true;
    }

    public interface IEmployeeDataService
    {
        Task<IEnumerable<Employee>> GetEmployees();
    }

    public class EmployeeDataService : IEmployeeDataService
    {
        private readonly IList<Employee>? _employee = null;
        public EmployeeDataService()
        {
                _employee = new List<Employee>() {
                    new(){
                        Id = 101,
                        FirstName = "Joydip",
                        MiddleName = "AAA",
                        LastName = "Kanjilal",
                        Department = "Development",
                        Address = "Banjara Hills",
                        Phone = "1234567890"
                    },
                    new(){
                        Id = 102,
                        FirstName = "Jaya",
                        MiddleName = "Kumar",
                        LastName = "Vinayagam",
                        Department = "Development",
                        Address = "Banjara Hills",
                        Phone = "1234567890"
                    }
                };
        }
        public async Task<IEnumerable<Employee>> GetEmployees() => await Task.FromResult(_employee!);
    }
}
