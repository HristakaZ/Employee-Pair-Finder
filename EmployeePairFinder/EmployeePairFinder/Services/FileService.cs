using CsvHelper;
using CsvHelper.Configuration;
using EmployeePairFinder.Models;
using EmployeePairFinder.Services.Abstractions;
using System.Globalization;
using System.Text;

namespace EmployeePairFinder.Services
{
    public class FileService : IFileService
    {
        public List<Employee> GetEmployeesFromFile(IFormFile file)
        {
            List<Employee> employees = new List<Employee>();
            CsvConfiguration csvConfiguration = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                Delimiter = ","
            };

            using (StreamReader streamReader = new StreamReader(file.OpenReadStream(), Encoding.UTF8))
            {
                using (CsvReader csvReader = new CsvReader(streamReader, csvConfiguration))
                {
                    csvReader.Context.RegisterClassMap<EmployeeMap>();
                    employees = csvReader.GetRecords<Employee>().ToList();
                }
            }

            return employees;
        }

        public bool IsFileExtensionValid(IFormFile file)
        {
            string fileExtension = Path.GetExtension(file.FileName);
            if (fileExtension != ".csv")
            {
                return false;
            }

            return true;
        }
    }
}
