using MEGZ_Web_Api.ViewModels;
using MEGZ_Web_Api.Models;
using MEGZ_Web_Api.Repository.EmployeeR;

namespace MEGZ_Web_Api.Services.Employee
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepo employeeRepo;

        public EmployeeService(IEmployeeRepo employeeRepo)
        {
            this.employeeRepo = employeeRepo;
        }
        public Models.Employee Create(AddEmployeeFormViewModel viewModel)
        {
            return employeeRepo.Create(viewModel);
        }

        public int DeleteById(int id)
        {
           return employeeRepo.DeleteById(id);
        }

        public List<Models.Employee> GetAll()
        {
            return employeeRepo.GetAll();
        }

        public Models.Employee GetById(int id)
        {
            return employeeRepo.GetById(id);
        }

        public EmployeeDetailsViewModel GetEmployeesDetailsById(int id)
        {
            return employeeRepo.GetEmployeesDetailsById(id);
        }

        public List<EmployeeViewModel> GetEmployeesViewModel()
        {
            return employeeRepo.GetEmployeesViewModel();
        }

        public void Update(int id, AddEmployeeFormViewModel employee)
        {
            employeeRepo.Update(id, employee);
        }
    }
}
