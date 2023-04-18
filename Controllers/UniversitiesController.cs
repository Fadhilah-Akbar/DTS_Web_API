using DTS_Web_Api.Models;
using DTS_Web_Api.Repository.Contracts;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace DTS_Web_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UniversitiesController : GeneralController<University, int>

    {
        public UniversitiesController(IUniversityRepository repository) : base(repository)
        {
        }
    }
}
