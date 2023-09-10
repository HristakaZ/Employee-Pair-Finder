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
        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            List<Employee> employeeProjectDTOs = new List<Employee>()
            {
                new Employee()
                {
                    EmpID = 1,
                    ProjectID = 1,
                    DateFrom = new DateTime(year: 2023, month: 1, day: 9),
                    DateTo = new DateTime(year: 2023, month: 9, day: 9)
                },
                new Employee()
                {
                    EmpID = 2,
                    ProjectID = 1,
                    DateFrom = new DateTime(year: 2022, month: 12, day: 9),
                    DateTo = new DateTime(year: 2023, month: 9, day: 9)
                },
                new Employee()
                {
                    EmpID = 3,
                    ProjectID = 1,
                    DateFrom = new DateTime(year: 2023, month: 6, day: 9),
                    DateTo = new DateTime(year: 2023, month: 9, day: 9)
                },
                new Employee()
                {
                    EmpID = 4,
                    ProjectID = 1,
                    DateFrom = new DateTime(year: 2023, month: 12, day: 31),
                    DateTo = null
                },
                new Employee()
                {
                    EmpID = 5,
                    ProjectID = 2,
                    DateFrom = new DateTime(year: 2022, month: 9, day: 9),
                    DateTo = new DateTime(year: 2023, month: 9, day: 9)
                },
                new Employee()
                {
                    EmpID = 6,
                    ProjectID = 2,
                    DateFrom = new DateTime(year: 2022, month: 10, day: 9),
                    DateTo = new DateTime(year: 2023, month: 9, day: 9)
                },
                new Employee()
                {
                    EmpID = 7,
                    ProjectID = 2,
                    DateFrom = new DateTime(year: 2022, month: 11, day: 9),
                    DateTo = new DateTime(year: 2023, month: 9, day: 9)
                },
                new Employee()
                {
                    EmpID = 8,
                    ProjectID = 2,
                    DateFrom = new DateTime(year: 2023, month: 12, day: 31),
                    DateTo = null
                }
            };

            //step 1: group the employees by project
            Dictionary<int, List<Employee>> groupedEmployeesByProject =
                employeeProjectDTOs.GroupBy(x => x.ProjectID).ToDictionary(x => x.Key, y => y.ToList());

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