using Azure;
using IDS.Models.DTOs;
using IDS.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using IDS.Repository.IRepository;
using IDS.Exceptions;
using IDS.Services.IServices;

namespace IDS.Services
{
    public class UserService : IUserService
    {

        private readonly IUserRepository _userRepo;
        public UserService(IUserRepository userRepo)
        {
            _userRepo = userRepo;
        }
        public async Task<LoginResponseDTO> Login([FromBody] LoginRequestDTO model)
        {
            if (model.UserName == null || model.Password == null)
            {
                throw new BadRequestException("Please fill in username and password");
            }
            var loginResponse = await _userRepo.Login(model);
            if (loginResponse.User == null || string.IsNullOrEmpty(loginResponse.Token))
            {
                throw new BadRequestException("Username or password is incorrect");
            }
            return loginResponse;
        }
        public async Task<User> Register([FromBody] RegistrationRequestDTO model)
         {
            if (model.UserName == null || model.Password == null)
            {
                throw new BadRequestException("Please fill in username and password");
            }
            bool ifUserNameUnique = _userRepo.IsUniqueUser(model.UserName);
            if (!ifUserNameUnique)
            {
                throw new BadRequestException("Username already exists!");

            }
            var user = await _userRepo.Register(model);
            if (user == null)
            {
                throw new InternalServerException("We encountered an error while registering your user, try again later");
            }
            return user;
        }
    }
}
