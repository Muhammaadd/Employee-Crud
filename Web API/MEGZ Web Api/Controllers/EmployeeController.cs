using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MEGZ_Web_Api.ViewModels;
using MEGZ_Web_Api.Models;
using MEGZ_Web_Api.Services.Employee;
using System.Net;
using System.Net.Http;

namespace MEGZ_Web_Api.Controllers
{
    [Route("api/[controller]/")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }
        [HttpPost]
        [Route("addEmployee")]
        public IActionResult AddEmployee(AddEmployeeFormViewModel employeeViewModel)
        {
            try
            {
                Employee employee = employeeService.Create(employeeViewModel);
            }
            catch
            {
                ModelState.AddModelError("others", "Faild to add employee please check your data");
                return BadRequest(ModelState);
            }
            return Ok();
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(employeeService.GetEmployeesViewModel());
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            EmployeeDetailsViewModel employee = employeeService.GetEmployeesDetailsById(id);
            if(employee==null)
                return BadRequest();
            return Ok(employee);
        }
        [HttpDelete]
        [Route("Delete/{id}")]
        public IActionResult DeleteById(int id)
        {
            int status = employeeService.DeleteById(id);
            if(status==-1)
                return BadRequest("Invalid employee ID");
            return Ok("Deleted");
        }
        [HttpPut]
        [Route("Update/{id}")]
        public IActionResult Update(int id,AddEmployeeFormViewModel viewModel)
        {
            try
            {
                employeeService.Update(id, viewModel);
            }
            catch
            {
                ModelState.AddModelError("other", "failed to update this employee");
                return BadRequest(ModelState);
            }
            return Ok();
        }
    }
} 
