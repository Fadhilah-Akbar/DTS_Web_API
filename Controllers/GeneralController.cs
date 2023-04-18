using DTS_Web_Api.Contexts;
using DTS_Web_Api.Models;
using DTS_Web_Api.Repository;
using DTS_Web_Api.Repository.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Core.Types;
using System.Net;

namespace DTS_Web_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class GeneralController<TEntity, TKey> : ControllerBase
        where TEntity : class
    {
        private readonly IGeneralRepository<TEntity, TKey> _repository;

        public GeneralController(IGeneralRepository<TEntity, TKey> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var results = await _repository.GetAllAsync();
            if (results == null)
            {
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

            return Ok(new
            {
                code = StatusCodes.Status200OK,
                status = HttpStatusCode.OK.ToString(),
                data = results
            });
        }

        [HttpGet("id")]
        public async Task<IActionResult> Get(TKey key)
        {
            var results = await _repository.GetByIdAsync(key);
            if (results == null)
            {
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

            return Ok(new
            {
                code = StatusCodes.Status200OK,
                status = HttpStatusCode.OK.ToString(),
                data = results
            });
        }

        [HttpPost]
        public async Task<IActionResult> Post(TEntity entity)
        {
            try
            {
                await _repository.InsertAsync(entity);
                return Ok(new
                {
                    code = StatusCodes.Status200OK,
                    status = HttpStatusCode.OK.ToString(),
                    data = new
                    {
                        Message = "Data insert",
                    }
                });
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

        [HttpPut]
        public async Task<IActionResult> Put(TEntity entity)
        {
            try
            {
                await _repository.UpdateAsync(entity);
                return Ok(new
                {
                    code = StatusCodes.Status200OK,
                    status = HttpStatusCode.OK.ToString(),
                    data = new
                    {
                        Message = "Data update",
                    }
                });
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

        [HttpDelete]
        public async Task<IActionResult> Delete(TKey key)
        {
            try
            {
                await _repository.DeleteAsync(key);
                return Ok(new
                {
                    code = StatusCodes.Status200OK,
                    status = HttpStatusCode.OK.ToString(),
                    data = new
                    {
                        Message = "Data delete",
                    }
                });
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
