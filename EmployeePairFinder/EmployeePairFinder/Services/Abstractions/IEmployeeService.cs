using EmployeePairFinder.Models;

namespace EmployeePairFinder.Services.Abstractions
{
    public interface IEmployeeService
    {
        List<EmployeePair> GetProjectsEmployeePairs(Dictionary<int, List<Employee>> groupedEmployeesByProject);

        int CalculatePairProjectWorkServiceDurationInDays(Employee firstEmployee, Employee secondEmployee);
    }
}
