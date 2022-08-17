using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace MEGZ_Web_Api.Models
{
    public class Attendance
    {
        public int Id { get; set; }
        public float? CheckIn { get; set; }
        public float? CheckOut { get; set; }
        public DateTime Date { get; set; }
        public float? BounesHours { get; set; }
        public float? DiscountHours { get; set; }
        public bool? IsAttendance { get; set; }
        public bool? IsAbsent { get; set; }
        [ForeignKey("employee")]
        public int Employee_Id { get; set; }
        public virtual Employee? employee { get; set; }
    }
}
