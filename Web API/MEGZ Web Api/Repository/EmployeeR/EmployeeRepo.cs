using MEGZ_Web_Api.Models;
using MEGZ_Web_Api.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace MEGZ_Web_Api.Repository.EmployeeR
{
    public class EmployeeRepo : IEmployeeRepo
    {
        private readonly DBContext dBContext;

        public EmployeeRepo(DBContext dBContext)
        {
            this.dBContext = dBContext;
        }
        public Employee Create(AddEmployeeFormViewModel viewModel)
        {
            Employee employee = new Employee
            {
                Name = viewModel.Name,
                Email = viewModel.Email,
                SSN = viewModel.SSN,
                Address = viewModel.Address,
                Date = viewModel.Date,
                Salary = viewModel.Salary,
                Nationality = viewModel.Nationality,
                Phone = viewModel.Phone,
                Gender = viewModel.Gender,
                Bonus = viewModel.Bonus,
                Discount = viewModel.Discount,
                CheckIn = viewModel.CheckIn,
                CheckOut = viewModel.CheckOut,
                HireDate = viewModel.HireDate,
                Department_Id = viewModel.Department_Id,
                Profile = viewModel.Profile
            };
            dBContext.Employee.Add(employee);
            dBContext.SaveChanges();
            return employee;
        }

        public int DeleteById(int id)
        {
            Employee employee = GetById(id);
            if (employee == null)
                return -1;
            dBContext.Employee.Remove(employee);
            dBContext.SaveChanges();
            return 1;
        }

        public List<Employee> GetAll()
        {
            return dBContext.Employee.Include(n=>n.department).ToList();
        }

        public Employee GetById(int id)
        {
            return dBContext.Employee.FirstOrDefault(n => n.Id == id);
        }

        public EmployeeDetailsViewModel? GetEmployeesDetailsById(int id)
        {
            return dBContext.Employee.Where(n => n.Id == id).Select(n => new EmployeeDetailsViewModel
            {
                Id = n.Id,
                Name = n.Name,
                Address = n.Address,
                Bonus = n.Bonus,
                CheckIn = n.CheckIn,
                CheckOut=n.CheckOut,
                Date=n.Date,
                Discount=n.Discount,
                Email=n.Email,
                Gender=n.Gender,
                Profile=n.Profile,
                HireDate=n.HireDate,
                Salary=n.Salary,
                SSN=n.SSN,
                Nationality=n.Nationality,
                Phone=n.Phone,
                Department_Id = n.Department_Id
            }).FirstOrDefault();
        }

        public List<EmployeeViewModel> GetEmployeesViewModel()
        {
            return dBContext.Employee.Select(n => new EmployeeViewModel { Id = n.Id, Name = n.Name, Address = n.Address, Email = n.Email,Department=n.department.Name}).ToList();
        }

        public void Update(int id, AddEmployeeFormViewModel viewModel)
        {
            Employee OldEmployee = GetById(id);
            OldEmployee.Name = viewModel.Name;
            OldEmployee.Email = viewModel.Email;
            OldEmployee.SSN = viewModel.SSN;
            OldEmployee.Address = viewModel.Address;
            OldEmployee.Date = viewModel.Date;
            OldEmployee.Salary = viewModel.Salary;
            OldEmployee.Nationality = viewModel.Nationality;
            OldEmployee.Phone = viewModel.Phone;
            OldEmployee.Gender = viewModel.Gender;
            OldEmployee.Bonus = viewModel.Bonus;
            OldEmployee.Discount = viewModel.Discount;
            OldEmployee.CheckIn = viewModel.CheckIn;
            OldEmployee.CheckOut = viewModel.CheckOut;
            OldEmployee.HireDate = viewModel.HireDate;
            OldEmployee.Department_Id = viewModel.Department_Id;
            OldEmployee.Profile = viewModel.Profile;
            dBContext.SaveChanges();
        }
    }
}
