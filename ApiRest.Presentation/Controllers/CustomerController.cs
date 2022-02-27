using ApiRest.Domain;
using ApiRest.Infra.Interfaces;
using ApiRest.Presentation.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiRest.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRepository _repository;

        public CustomerController(ICustomerRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_repository.GetAll());
        }

        [HttpPost]
        public async Task<IActionResult> Add(Customer customer)
        {

            try
            {
                await _repository.Add(customer);
                return StatusCode((int)ApiStatus.Created);
            }
            catch (Exception ex)
            {

                return StatusCode((int)ApiStatus.InternalServerError, ex.Message);
            }
        }


    }
}
