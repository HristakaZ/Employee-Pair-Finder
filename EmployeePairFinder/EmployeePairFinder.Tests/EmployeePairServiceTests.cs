using EmployeePairFinder.Models;
using EmployeePairFinder.Services;
using EmployeePairFinder.Services.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace EmployeePairFinder.Tests
{
    public class EmployeePairServiceTests
    {
        private IEmployeeService _employeeService;

        [SetUp]
        public void Setup()
        {
            _employeeService = new EmployeeService();
        }

        //test case 1 from the image
        [Test]
        public void CalculatePairProjectWorkServiceDurationInDays_WithBothJoiningAtTheSameTimeAndFirstEmployeeEndingEarlier_ShouldPass()
        {
            //Arrange
            Employee firstEmployee = new Employee()
            {
                EmpID = 1,
                ProjectID = 1,
                DateFrom = new DateTime(year: 2023, month: 1, day: 9),
                DateTo = new DateTime(year: 2023, month: 8, day: 9)
            };
            Employee secondEmployee = new Employee()
            {
                EmpID = 2,
                ProjectID = 1,
                DateFrom = new DateTime(year: 2023, month: 1, day: 9),
                DateTo = new DateTime(year: 2023, month: 9, day: 9)
            };

            //Act
            int durationInDays = _employeeService.CalculatePairProjectWorkServiceDurationInDays(firstEmployee, secondEmployee);

            //Assert
            Assert.AreEqual(212, durationInDays);
        }

        //test case 2 from the image
        [Test]
        public void CalculatePairProjectWorkServiceDurationInDays_WithBothEmployeesJoiningAndEndingAtTheSameTime_ShouldPass()
        {
            //Arrange
            Employee firstEmployee = new Employee()
            {
                EmpID = 1,
                ProjectID = 1,
                DateFrom = new DateTime(year: 2023, month: 1, day: 9),
                DateTo = new DateTime(year: 2023, month: 9, day: 9)
            };
            Employee secondEmployee = new Employee()
            {
                EmpID = 2,
                ProjectID = 1,
                DateFrom = new DateTime(year: 2023, month: 1, day: 9),
                DateTo = new DateTime(year: 2023, month: 9, day: 9)
            };

            //Act
            int durationInDays = _employeeService.CalculatePairProjectWorkServiceDurationInDays(firstEmployee, secondEmployee);

            //Assert
            Assert.AreEqual(243, durationInDays);
        }

        //test case 3 from the image
        [Test]
        public void CalculatePairProjectWorkServiceDurationInDays_WithBothJoiningAtTheSameTimeAndSecondEmployeeEndingEarlier_ShouldPass()
        {
            //Arrange
            Employee firstEmployee = new Employee()
            {
                EmpID = 1,
                ProjectID = 1,
                DateFrom = new DateTime(year: 2023, month: 1, day: 9),
                DateTo = new DateTime(year: 2023, month: 9, day: 9)
            };
            Employee secondEmployee = new Employee()
            {
                EmpID = 2,
                ProjectID = 1,
                DateFrom = new DateTime(year: 2023, month: 1, day: 9),
                DateTo = new DateTime(year: 2023, month: 8, day: 9)
            };

            //Act
            int durationInDays = _employeeService.CalculatePairProjectWorkServiceDurationInDays(firstEmployee, secondEmployee);

            //Assert
            Assert.AreEqual(212, durationInDays);
        }

        //test case 4 from the image
        [Test]
        public void CalculatePairProjectWorkServiceDurationInDays_WithFirstEmployeeJoiningEarlierAndBothEndingAtTheSameTime_ShouldPass()
        {
            //Arrange
            Employee firstEmployee = new Employee()
            {
                EmpID = 1,
                ProjectID = 1,
                DateFrom = new DateTime(year: 2023, month: 1, day: 9),
                DateTo = new DateTime(year: 2023, month: 9, day: 9)
            };
            Employee secondEmployee = new Employee()
            {
                EmpID = 2,
                ProjectID = 1,
                DateFrom = new DateTime(year: 2023, month: 2, day: 9),
                DateTo = new DateTime(year: 2023, month: 9, day: 9)
            };

            //Act
            int durationInDays = _employeeService.CalculatePairProjectWorkServiceDurationInDays(firstEmployee, secondEmployee);

            //Assert
            Assert.AreEqual(212, durationInDays);
        }

        //test case 5 from the image
        [Test]
        public void CalculatePairProjectWorkServiceDurationInDays_WithSecondEmployeeJoiningEarlierAndBothEndingAtTheSameTime_ShouldPass()
        {
            //Arrange
            Employee firstEmployee = new Employee()
            {
                EmpID = 1,
                ProjectID = 1,
                DateFrom = new DateTime(year: 2023, month: 2, day: 9),
                DateTo = new DateTime(year: 2023, month: 9, day: 9)
            };
            Employee secondEmployee = new Employee()
            {
                EmpID = 2,
                ProjectID = 1,
                DateFrom = new DateTime(year: 2023, month: 1, day: 9),
                DateTo = new DateTime(year: 2023, month: 9, day: 9)
            };

            //Act
            int durationInDays = _employeeService.CalculatePairProjectWorkServiceDurationInDays(firstEmployee, secondEmployee);

            //Assert
            Assert.AreEqual(212, durationInDays);
        }

        //test case 6 from the image
        [Test]
        public void CalculatePairProjectWorkServiceDurationInDays_WithFirstEmployeeJoiningLaterAndEndingEarlier_ShouldPass()
        {
            //Arrange
            Employee firstEmployee = new Employee()
            {
                EmpID = 1,
                ProjectID = 1,
                DateFrom = new DateTime(year: 2023, month: 2, day: 9),
                DateTo = new DateTime(year: 2023, month: 6, day: 9)
            };
            Employee secondEmployee = new Employee()
            {
                EmpID = 2,
                ProjectID = 1,
                DateFrom = new DateTime(year: 2023, month: 1, day: 9),
                DateTo = new DateTime(year: 2023, month: 9, day: 9)
            };

            //Act
            int durationInDays = _employeeService.CalculatePairProjectWorkServiceDurationInDays(firstEmployee, secondEmployee);

            //Assert
            Assert.AreEqual(120, durationInDays);
        }

        //test case 7 from the image
        [Test]
        public void CalculatePairProjectWorkServiceDurationInDays_WithSecondEmployeeJoiningLaterAndEndingEarlier_ShouldPass()
        {
            //Arrange
            Employee firstEmployee = new Employee()
            {
                EmpID = 1,
                ProjectID = 1,
                DateFrom = new DateTime(year: 2023, month: 1, day: 9),
                DateTo = new DateTime(year: 2023, month: 9, day: 9)
            };
            Employee secondEmployee = new Employee()
            {
                EmpID = 2,
                ProjectID = 1,
                DateFrom = new DateTime(year: 2023, month: 2, day: 9),
                DateTo = new DateTime(year: 2023, month: 6, day: 9)
            };

            //Act
            int durationInDays = _employeeService.CalculatePairProjectWorkServiceDurationInDays(firstEmployee, secondEmployee);

            //Assert
            Assert.AreEqual(120, durationInDays);
        }

        //test case 8 from the image
        [Test]
        public void CalculatePairProjectWorkServiceDurationInDays_WithNoMatchBetweenTheTwoEmployees_ShouldPass()
        {
            //Arrange
            Employee firstEmployee = new Employee()
            {
                EmpID = 1,
                ProjectID = 1,
                DateFrom = new DateTime(year: 2023, month: 1, day: 9),
                DateTo = new DateTime(year: 2023, month: 6, day: 9)
            };
            Employee secondEmployee = new Employee()
            {
                EmpID = 2,
                ProjectID = 1,
                DateFrom = new DateTime(year: 2023, month: 7, day: 9),
                DateTo = new DateTime(year: 2023, month: 9, day: 9)
            };

            //Act
            int durationInDays = _employeeService.CalculatePairProjectWorkServiceDurationInDays(firstEmployee, secondEmployee);

            //Assert
            Assert.AreEqual(0, durationInDays);
        }
    }
}