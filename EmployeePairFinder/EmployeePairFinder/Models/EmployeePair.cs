namespace EmployeePairFinder.Models
{
    public class EmployeePair
    {
        public Employee FirstEmployee { get; }

        public Employee SecondEmployee { get; }

        public int DurationInDays { get; }

        public int ProjectID { get; }

        public EmployeePair(Employee firstEmployee,
                            Employee secondEmployee,
                            int durationInDays,
                            int projectID)
        {
            this.FirstEmployee = firstEmployee;
            this.SecondEmployee = secondEmployee;
            this.DurationInDays = durationInDays;
            this.ProjectID = projectID;
        }
    }
}
