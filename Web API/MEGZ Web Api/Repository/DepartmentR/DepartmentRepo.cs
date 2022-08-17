using MEGZ_Web_Api.Models;

namespace MEGZ_Web_Api.Repository.DepartmentR
{
    public class DepartmentRepo : IDepartmentReop
    {
        private readonly DBContext dBContext;

        public DepartmentRepo(DBContext dBContext)
        {
            this.dBContext = dBContext;
        }
        public List<Department> GetAll()
        {
            return dBContext.Department.ToList();
        }
    }
}
