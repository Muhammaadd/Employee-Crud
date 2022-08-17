using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace MEGZ_Web_Api.Models
{
    public class EmployeeException
    {
        public int Id { get; set; }
        public float? CheckIn { get; set; }
        public float? CheckOut { get; set; }
        public bool? Absence { get; set; }
        public DateTime Date { get; set; }
        [ForeignKey("employee")]
        public int Employee_Id { get; set; }
        [ForeignKey("HR")]
        public string HR_Id { get; set; }
        public virtual Employee? employee { get; set; }
        public virtual ApplicationUser? HR { get; set; }


    }
}
