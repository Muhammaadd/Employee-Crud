namespace MEGZ_Web_Api.ViewModels
{
    public class EmployeeDetailsViewModel
    {
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
        public int Department_Id { get; set; }
    }
}
