using EmployeePairFinder.Models;
using EmployeePairFinder.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace EmployeePairFinder.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        private readonly IFileService _fileService;
        public EmployeeController(IEmployeeService employeeService,
                                  IFileService fileService)
        {
            _employeeService = employeeService;
            _fileService = fileService;
        }

        [HttpPost]
        [Route("FindLongestWorkingProjectEmployeePairs")]
        public IActionResult Post(IFormFile csvFile)
        {
            if (!_fileService.IsFileExtensionValid(csvFile))
            {
                return BadRequest("File must be csv.");
            }

            List<Employee> employees = _fileService.GetEmployeesFromFile(csvFile);

            //step 1: group the employees by project
            Dictionary<int, List<Employee>> groupedEmployeesByProject =
                employees.GroupBy(x => x.ProjectID).ToDictionary(x => x.Key, y => y.ToList());

            /*step 2: find the employees that have worked together by getting the common dates of their work service on one project
            (find whether the start date of one employee overlaps with the work of service duration of another employee for the same
            project)*/
            List<EmployeePair> employeePairs = _employeeService.GetProjectsEmployeePairs(groupedEmployeesByProject);

            /*step 3: after finding out the employees that have worked together from step 2, get the pair that has worked the most
             on a project together*/
            //should return emp id 1 and emp id 2 for project id 1 - for the longest duration a pair has worked on a project
            //should return emp id 5 and emp id 6 for project id 2 - for the longest duration a pair has worked on a project
            List<EmployeePair?> longestWorkingEmployeePairsByProject =
                employeePairs.GroupBy(x => x.ProjectID).Select(x => x.MaxBy(y => y.DurationInDays)).ToList();

            return Ok(longestWorkingEmployeePairsByProject);
        }
    }
}