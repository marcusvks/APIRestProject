using ApiRest.Domain;
using ApiRest.Infra.Interfaces;
using ApiRest.Presentation.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace ApiRest.Presentation.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]

    public class ArduinoController : ControllerBase
    {
        private readonly IArduinoRepository _repository;

        public ArduinoController(IArduinoRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        [Route("GetArduinos")]
        public IActionResult Get()
        {
            return Ok(_repository.GetAll());
        }

        [HttpPost]
        [Route("AddArduino")]
        public async Task<IActionResult> Add(Arduino arduino)
        {

            try
            {
                arduino.LastActivity = DateTime.Now;

                await _repository.Add(arduino);
                return StatusCode((int)ApiStatus.Created);
            }
            catch (Exception ex)
            {

                return StatusCode((int)ApiStatus.InternalServerError, ex.Message);
            }
        }
    }
}
