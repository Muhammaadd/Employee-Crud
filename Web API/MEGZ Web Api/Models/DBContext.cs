using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
namespace MEGZ_Web_Api.Models
{
    public class DBContext : IdentityDbContext<ApplicationUser>
    {
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<Department> Department { get; set; }
        public virtual DbSet<Attendance> Attendance { get; set; }
        public virtual DbSet<SalaryInfo> SalaryInfo { get; set; }
        public virtual DbSet<EmployeeException> EmployeeException { get; set; }

        public DBContext()
        {

        }
        public DBContext(DbContextOptions options):base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=AngularMiniSystem;Integrated Security=True");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
