using System.Collections.Generic;

namespace CompanyApi.Models // Use an appropriate namespace
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string? Name { get; set; }
        public List<Vehicle> Vehicles { get; set; } = new List<Vehicle>();
    }

    public class Vehicle
    {
        public int VehicleId { get; set; }
        public string? LicensePlate { get; set; }
        public int EmployeeId { get; set; }
        public Employee? Employee { get; set; }
    }
}
