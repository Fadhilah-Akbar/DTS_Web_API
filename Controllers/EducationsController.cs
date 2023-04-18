using DTS_Web_Api.Models;
using DTS_Web_Api.Repository.Contracts;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace DTS_Web_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EducationsController : GeneralController<Education, int>

    {
        public EducationsController(IEducationRepository repository) : base(repository)
        {
        }
    }
}
