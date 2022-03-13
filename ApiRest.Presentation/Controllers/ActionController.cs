using ApiRest.Domain;
using ApiRest.Infra.Interfaces;
using ApiRest.Presentation.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using ArduinoUI.Models;

namespace ApiRest.Presentation.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]

    public class ActionController : ControllerBase
    {
        private readonly IArduinoActionRepository _repository;

        public ActionController(IArduinoActionRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        [Route("GetActions")]
        public IActionResult Get()
        {
            return Ok(_repository.GetAll());
        }

        [HttpGet]
        [Route("CompleteAction")]
        public IActionResult CompleteAction(int actionId)
        {
            _repository.UpdateStatus(actionId, (int)StatusActions.Completed);

            return Ok();
        }

        [HttpGet]
        [Route("GetActiveActions")]
        public IActionResult GetActiveActions(int arduinoId)
        {

            ArduinoAction action = _repository.GetActiveAction(arduinoId);

            if (action != null)
            {
                ReturnActiveAction activeAction = new ReturnActiveAction
                {
                    TypeAction = action.TypeAction,
                    actionId = action.IdAction,
                };

                if (activeAction.actionId == default || activeAction.TypeAction == default)
                    return StatusCode((int)ApiStatus.InternalServerError, "");
                else
                {
                    _repository.UpdateStatus(activeAction.actionId, (int)StatusActions.Started);
                }

                return Ok(activeAction);
            }
            else
                return NotFound();
        }

        [HttpPost]
        [Route("AddAction")]
        public async Task<IActionResult> Add(ArduinoAction arduinoAction)
        {
            try
            {
                arduinoAction.InsertedDate = DateTime.Now;

                await _repository.Add(arduinoAction);
                return StatusCode((int)ApiStatus.Created);
            }
            catch (Exception ex)
            {

                return StatusCode((int)ApiStatus.InternalServerError, ex.Message);
            }
        }

        public enum TypeActions
        {
            ligarled = 1,
            action2 = 2,

        }
        public enum StatusActions
        {
            Created = 0,
            Started = 1,
            Completed = 2,

        }

    }
}
