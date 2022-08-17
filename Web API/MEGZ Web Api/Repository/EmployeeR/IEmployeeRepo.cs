using MEGZ_Web_Api.Models;
using MEGZ_Web_Api.ViewModels;
namespace MEGZ_Web_Api.Repository.EmployeeR
{
    public interface IEmployeeRepo
    {
        Employee Create(AddEmployeeFormViewModel viewModel);
        List<Employee> GetAll();
        Employee GetById(int id);
        List<EmployeeViewModel> GetEmployeesViewModel();
        EmployeeDetailsViewModel GetEmployeesDetailsById(int id);
        int DeleteById(int id);
        void Update(int id, AddEmployeeFormViewModel employee);
    }
}
