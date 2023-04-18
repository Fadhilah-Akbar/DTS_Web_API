using DTS_Web_Api.Models;
using DTS_Web_Api.Repository.Contracts;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace DTS_Web_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : GeneralController<Employee, string>

    {
        public EmployeesController(IEmployeeRepository repository) : base(repository)
        {
        }
    }
}
