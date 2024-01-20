using Azure;
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
}
