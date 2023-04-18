using DTS_Web_Api.Models;
using DTS_Web_Api.Repository.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace DTS_Web_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : GeneralController<Role, int>

    {
        public RolesController(IRoleRepository repository) : base(repository)
        {
        }
    }
}
