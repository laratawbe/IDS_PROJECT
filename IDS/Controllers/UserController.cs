using IDS.Exceptions;
using IDS.Models;
using IDS.Models.DTOs;
using IDS.Repository.IRepository;
using IDS.Services.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace IDS.Controllers
{
    public class UserController : Controller
    {

        private readonly IUserService _userService;
        protected APIResponse _response;
        public UserController(IUserService userService)
        {
            _userService = userService;
            _response = new();
        }

        [HttpPost("login")]
        [ProducesResponseType(typeof(APIResponse), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(LoginResponseDTO), (int)HttpStatusCode.OK)]
        [AllowAnonymous]

        public async Task<IActionResult> Login([FromBody] LoginRequestDTO model)
        {
            try
            {
                var loginResponse = await _userService.Login(model);
                _response.StatusCode = HttpStatusCode.OK;
                _response.Result= loginResponse;
            }
            catch (BadRequestException ex)
            {
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.IsSuccess = false;
                _response.ErrorMessages.Add(ex.Message);
                return BadRequest(_response);
            }
            catch (Exception ex)
            {
                _response.StatusCode = HttpStatusCode.InternalServerError;
                _response.IsSuccess = false;
                _response.ErrorMessages.Add(ex.Message);
            }
            return Ok(_response);
        }

        [HttpPost("register")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(APIResponse), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(User), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Register([FromBody] RegistrationRequestDTO model)
        {
            try
            {
            var user = await _userService.Register(model);

            }
            catch (BadRequestException ex)
            {
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.IsSuccess = false;
                _response.ErrorMessages.Add(ex.Message);
                return BadRequest(_response);
            }
            catch (Exception ex)
            {
                _response.StatusCode = HttpStatusCode.InternalServerError;
                _response.IsSuccess = false;
                _response.ErrorMessages.Add(ex.Message);  
            }

            _response.StatusCode = HttpStatusCode.OK;
            _response.IsSuccess = true;
            return Ok(_response);
        }
    }
}
