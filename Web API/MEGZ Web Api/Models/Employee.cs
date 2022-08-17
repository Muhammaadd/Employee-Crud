using MEGZ_Web_Api.Attributes;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace MEGZ_Web_Api.Models
{
    public class Employee
    {
        public Employee()
        {
            EmployeeExceptions = new List<EmployeeException>();
            Attendances = new List<Attendance>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string SSN { get; set; }
        public string Address { get; set; }
        public DateTime Date { get; set; }
        public double Salary { get; set; }
        public string Nationality { get; set; }
        public string Phone { get; set; }
        public string Gender { get; set; }
        public float Bonus { get; set; }
        public float Discount { get; set; }
        public string CheckIn { get; set; }
        public string CheckOut { get; set; }
        public DateTime HireDate { get; set; }
        public string? Profile { get; set; }
        [ForeignKey("department")]
        public int Department_Id { get; set; }
        public virtual Department? department { get; set; }
        public virtual List<EmployeeException>? EmployeeExceptions { get; set; }
        public virtual List<Attendance>? Attendances { get; set; }

    }
}
