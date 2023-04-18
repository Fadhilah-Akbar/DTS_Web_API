using DTS_Web_Api.Models;
using DTS_Web_Api.Repository.Contracts;
using DTS_Web_Api.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace DTS_Web_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : GeneralController<Account, string>

    {
        private readonly IAccountRepository _accountRepository;
        public AccountsController(IAccountRepository repository) : base(repository)
        {
            _accountRepository = repository;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(string email, string password)
        {
            var login = new LoginVM { Email = email, Password = password };
            var result = await _accountRepository.LoginAsync(login);
            if (result)
            {
                return Ok(new
                {
                    code = StatusCodes.Status200OK,
                    status = HttpStatusCode.OK.ToString(),
                    data = new
                    {
                        Message = "Data Successfully Insert"
                    }
                });
            }

            return NotFound(new
            {
                code = StatusCodes.Status404NotFound,
                status = HttpStatusCode.NotFound.ToString(),
                data = new
                {
                    message = "Data Not Found!"
                }
            });
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterVM registerVM)
        {
            try
            {
                await _accountRepository.RegisterAsync(registerVM);
                return Ok(new
                {
                    code = StatusCodes.Status200OK,
                    status = HttpStatusCode.OK.ToString(),
                    data = new
                    {
                        Message = "Data insert",
                    }
                }) ;
            }
            catch
            {
                return NotFound(new
                {
                    code = StatusCodes.Status400BadRequest,
                    status = HttpStatusCode.BadRequest.ToString(),
                    data = new
                    {
                        message = "Server Cannot Process Request"
                    }
                });
            }
        }
    }
}
