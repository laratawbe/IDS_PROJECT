using IDS.Exceptions;
using IDS.Models;
using IDS.Services.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace IDS.Controllers
{
    [Route("api/eventMembers")]
    [ApiController]
    public class EventMemberController : ControllerBase
    {
        protected APIResponse _response;
        private readonly IEventMemberService _eventMemberService;

        public EventMemberController(IEventMemberService eventService)
        {
            _eventMemberService = eventService;
            _response = new();
        }


        [HttpGet]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<APIResponse>> GetEventMembers([FromQuery(Name = "filterCategory")] string? category, [FromQuery] string? search
                , int pageSize = 0, int pageNumber = 1)
        {
            try
            {
                var events = await _eventMemberService.GetAllAsync(category, search, pageSize, pageNumber);
                _response.Result = events;
                _response.StatusCode = HttpStatusCode.OK;
                return Ok(_response);

            }
            catch (BadRequestException ex)
            {
                _response.IsSuccess = false;
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
                return BadRequest(_response);

            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                if (_response.StatusCode == null)
                    _response.StatusCode = HttpStatusCode.InternalServerError;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        [HttpGet("{id:int}", Name = "GetEventMember")]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> GetEventMember(int id)
        {
            try
            {
                var listTask = await _eventMemberService.GetAsync(id);

                _response.Result = listTask;
                _response.StatusCode = HttpStatusCode.OK;
                return Ok(_response);
            }
            catch (BadRequestException ex)
            {
                _response.IsSuccess = false;
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.ErrorMessages = new List<string>() { ex.ToString() };

            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.StatusCode = HttpStatusCode.InternalServerError;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<ActionResult<APIResponse>> CreateEventMember([FromBody] EventMember createDTO)
        {
            try
            {

                EventMember listTask = await _eventMemberService.CreateAsync(createDTO);
                _response.Result = listTask;
                _response.StatusCode = HttpStatusCode.Created;
                return CreatedAtRoute("GetEventMember", new { id = listTask.EventId }, _response);
            }
            catch (BadRequestException ex)
            {
                _response.IsSuccess = false;
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.StatusCode = HttpStatusCode.InternalServerError;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpDelete("{id:int}", Name = "DeleteEventMember")]
        [Authorize(Roles = "admin")]

        public async Task<ActionResult<APIResponse>> DeleteEventMember(int id)
        {
            try
            {

                await _eventMemberService.RemoveAsync(id);
                _response.StatusCode = HttpStatusCode.NoContent;
                _response.IsSuccess = true;
                return Ok(_response);

            }
            catch (BadRequestException ex)
            {
                _response.IsSuccess = false;
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            catch (NotFoundException ex)
            {
                _response.IsSuccess = true;
                _response.StatusCode = HttpStatusCode.NotFound;
                _response.ErrorMessages = new List<string>() { ex.ToString() };

            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.StatusCode = HttpStatusCode.InternalServerError;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        //[Authorize(Roles = "admin")]
        [HttpPut("{id:int}", Name = "UpdateEventMember")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<APIResponse>> UpdateEventMember(int id, [FromBody] EventMember updateDTO)
        {
            try
            {
                await _eventMemberService.UpdateAsync(id, updateDTO);
                _response.StatusCode = HttpStatusCode.NoContent;
                _response.IsSuccess = true;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.StatusCode = HttpStatusCode.InternalServerError;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }

    }
}
