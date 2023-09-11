using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.Configuration.Attributes;
using CsvHelper.TypeConversion;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;

namespace EmployeePairFinder.Models
{
    public class Employee
    {
        [DataMember(Order = 1)]
        [Name(nameof(EmpID))]
        public int EmpID { get; set; }

        [DataMember(Order = 2)]
        [Name(nameof(ProjectID))]
        public int ProjectID { get; set; }

        [DataMember(Order = 3)]
        [Name(nameof(DateFrom))]
        public DateTime DateFrom { get; set; }

        [DataMember(Order = 4)]
        [Name(nameof(DateTo))]
        public DateTime? DateTo { get; set; }

        public Employee()
        {
            if (this.DateTo == null)
            {
                this.DateTo = DateTime.Now;
            }
        }
    }

    public sealed class EmployeeMap : ClassMap<Employee>
    {
        public EmployeeMap()
        {
            Map(m => m.EmpID).Name("EmpID");
            Map(m => m.ProjectID).Name("ProjectID");
            Map(m => m.DateFrom).Name("DateFrom");
            Map(m => m.DateTo).Name("DateTo").TypeConverterOption.NullValues(new string[] { "null", "NULL", "" }).TypeConverter<DateToConverter>();
        }
    }

    public class DateToConverter : DateTimeConverter
    {
        private readonly IReadOnlyCollection<string> dateToAcceptedNullValues = new ReadOnlyCollection<string>(new List<string>()
        {
            "",
            "null",
            "NULL"
        });

        public override object? ConvertFromString(string? text, IReaderRow row, MemberMapData memberMapData)
        {
            if (dateToAcceptedNullValues.Any(x => x == text))
            {
                return DateTime.Now.Date;
            }

            return base.ConvertFromString(text, row, memberMapData);
        }
    }
}
