using EmployeePairFinder.Models;

namespace EmployeePairFinder.Services.Abstractions
{
    public interface IFileService
    {
        List<Employee> GetEmployeesFromFile(IFormFile file);

        bool IsFileExtensionValid(IFormFile file);
    }
}
