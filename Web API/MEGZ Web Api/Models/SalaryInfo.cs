namespace MEGZ_Web_Api.Models
{
    public class SalaryInfo
    {
        public int Id { get; set; }
        public string MonthName { get; set; }
        public int? AttendanceDays { get; set; }
        public int? AbsenceDays { get; set; }
        public float? BounesHours { get; set; }
        public float? DiscountHours { get; set; }
        public float? Extra { get; set; }
        public float? Discount { get; set; }
        public double Total { get; set; }
    }
}
