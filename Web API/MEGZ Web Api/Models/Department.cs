using System.Text.Json.Serialization;

namespace MEGZ_Web_Api.Models
{
    public class Department
    {
        public Department()
        {
            Employees = new List<Employee>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        [JsonIgnore]
        public virtual List<Employee>? Employees { get; set; }

    }
}
