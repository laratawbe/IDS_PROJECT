using Azure;
<<<<<<< HEAD
using IDS.Models.DTOs;
using IDS.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using IDS.Repository.IRepository;
using IDS.Exceptions;
using IDS.Services.IServices;
using System.Linq.Expressions;
using System.Linq;

namespace IDS.Services
{
    public class UserService :IUserService
    {

        private readonly IUserRepository _userRepo;
        private readonly IRepository<User> _userRepoCRUD;

        public UserService(IUserRepository userRepo, IRepository<User> userRepoCRUD)
        {
            _userRepo = userRepo;
            _userRepoCRUD = userRepoCRUD;
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
        public async Task<List<User>> GetAllAsync(string? category, string? search, int pageSize = 0, int pageNumber = 1)
        {
            IEnumerable<User> userList = await _userRepoCRUD.GetAllAsync(pageSize: pageSize, pageNumber: pageNumber);

            Func<User, bool> predicate = u =>
                (string.IsNullOrEmpty(search) || u.Name.ToLower().Contains(search));

            userList = userList.Where(predicate);

            return userList.ToList();
        }

        public async Task<User> GetAsync(int id)
        {
            if (id <= 0)
            {
                throw new BadRequestException("Message");
            }
            var entity = await _userRepoCRUD.GetAsync(u => u.UserId == id) ?? throw new NotFoundException("Message");
            return entity;
        }
        public async Task<User> CreateAsync(User entity)
        {
            if (entity == null)
            {
                throw new BadRequestException("Message");
            }

            if (await _userRepoCRUD.GetAsync(u => u.UserName.ToLower() == entity.UserName.ToLower()) != null)
            {
                throw new BadRequestException("Message");

            }

            await _userRepoCRUD.CreateAsync(entity);
            return entity;
        }

        public async Task RemoveAsync(int id)
        {
            if (id <= 0)
            {
                throw new BadRequestException("Message");
            }
            var entity = await _userRepoCRUD.GetAsync(u => u.UserId == id);
            if (entity == null)
            {
                throw new BadRequestException("Message");
            }
            await _userRepoCRUD.RemoveAsync(entity);

        }

        public async Task UpdateAsync(int id, User entity)
        {
            if (id <= 0)
            {
                throw new BadRequestException("Message");
            }

            if (entity == null || id != entity.UserId)
            {
                throw new BadRequestException("Message");
            }
            if (id != entity.UserId)
            {
                throw new BadRequestException("Message");
            }

            await _userRepoCRUD.UpdateAsync(entity);
        }

}
=======
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;
using System.Net;
using IDS.Models;
using IDS.Models.DTOs;
using IDS.Repository.IRepository;
using IDS.Services.IServices;

namespace IDS.Services
{
    public class UserService : IUserService
    {
        public Task<User> CreateUserAsync(User user)
        {
           
        }

        public Task<bool> DeleteUserAsync(int id)
        {
            
        }

        public Task<List<User>> GetAllUsersAsync(string? category = null, string? search = null, int pageSize = 0, int pageNumber = 1, string? sortBy = null, bool ascending = true)
        {
            
        }

        public Task<User> GetUserByIdAsync(int userId)
        {
            
        }

        public Task SaveAsync()
        {
           
        }

        public Task UpdateAsync(int id, User updatedUser)
        {

        }
    }
>>>>>>> e3e4f561d2d2079319f0d1e8592bec8d7d01fe5b
}
