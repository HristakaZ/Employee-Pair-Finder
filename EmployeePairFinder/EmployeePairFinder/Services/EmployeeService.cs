using EmployeePairFinder.Models;
using EmployeePairFinder.Services.Abstractions;

namespace EmployeePairFinder.Services
{
    public class EmployeeService : IEmployeeService
    {
        public List<EmployeePair> GetProjectsEmployeePairs(Dictionary<int, List<Employee>> groupedEmployeesByProject)
        {
            List<EmployeePair> employeePairs = new List<EmployeePair>();

            foreach (KeyValuePair<int, List<Employee>> keyValuePair in groupedEmployeesByProject)
            {
                Employee? employee = keyValuePair.Value.FirstOrDefault();

                if (employee != null)
                {
                    foreach (Employee employeeForProject in keyValuePair.Value)
                    {
                        if (employee.EmpID != employeeForProject.EmpID)
                        {
                            if (IsWorkExperienceOverlapping(employee, employeeForProject))
                            {
                                EmployeePair employeePair = new EmployeePair(employee, employeeForProject,
                                    CalculatePairProjectWorkServiceDurationInDays(employee, employeeForProject), keyValuePair.Key);
                                employeePairs.Add(employeePair);
                            }

                            employee = employeeForProject;
                        }
                    }
                }
            }

            return employeePairs;
        }

        public int CalculatePairProjectWorkServiceDurationInDays(Employee firstEmployee, Employee secondEmployee)
        {
            if (firstEmployee.DateFrom == secondEmployee.DateFrom && secondEmployee.DateTo > firstEmployee.DateTo) //case 1 from the image
            {
                return (firstEmployee.DateTo! - firstEmployee.DateFrom).Value.Days;
            }
            else if (firstEmployee.DateFrom == secondEmployee.DateFrom && firstEmployee.DateTo == secondEmployee.DateTo) //case 2 from the image
            {
                return (firstEmployee.DateTo! - firstEmployee.DateFrom).Value.Days;
            }
            else if (firstEmployee.DateFrom == secondEmployee.DateFrom && firstEmployee.DateTo > secondEmployee.DateTo) //case 3 from the image
            {
                return (secondEmployee.DateTo! - firstEmployee.DateFrom).Value.Days;
            }
            else if (firstEmployee.DateFrom < secondEmployee.DateFrom && firstEmployee.DateTo == secondEmployee.DateTo) //case 4 from the image
            {
                return (firstEmployee.DateTo! - secondEmployee.DateFrom).Value.Days;
            }
            else if (secondEmployee.DateFrom < firstEmployee.DateFrom && firstEmployee.DateTo == secondEmployee.DateTo) //case 5 from the image
            {
                return (firstEmployee.DateTo! - firstEmployee.DateFrom).Value.Days;
            }
            else if (secondEmployee.DateFrom < firstEmployee.DateFrom && secondEmployee.DateTo > firstEmployee.DateTo) //case 6 from the image
            {
                return (firstEmployee.DateTo! - firstEmployee.DateFrom).Value.Days;
            }
            else if (firstEmployee.DateFrom < secondEmployee.DateFrom && firstEmployee.DateTo > secondEmployee.DateTo) //case 7 from the image
            {
                return (secondEmployee.DateTo! - secondEmployee.DateFrom).Value.Days;
            }
            else //case 8 from the image - no matches
            {
                return 0;
            }
        }

        private bool IsWorkExperienceOverlapping(Employee firstEmployee, Employee secondEmployee)
        {
            return firstEmployee.DateFrom < secondEmployee.DateTo && secondEmployee.DateFrom < firstEmployee.DateTo;
        }
    }
}
