using MEGZ_Web_Api.Repository.DepartmentR;
namespace MEGZ_Web_Api.Services.Department
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentReop departmentReop;

        public DepartmentService(IDepartmentReop departmentReop)
        {
            this.departmentReop = departmentReop;
        }
        public List<Models.Department> GetAll()
        {
            return departmentReop.GetAll();
        }
    }
}
