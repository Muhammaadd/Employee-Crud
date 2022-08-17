using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MEGZ_Web_Api.Services.Department;
namespace MEGZ_Web_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentService departmentService;

        public DepartmentController(IDepartmentService departmentService)
        {
            this.departmentService = departmentService;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(departmentService.GetAll());
        }
    }
}
