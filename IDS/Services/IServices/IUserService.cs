using System.Linq.Expressions;
using IDS.Models;
using IDS.Models.DTOs;

namespace IDS.Services.IServices
{
    public interface IUserService

    {
        Task<List<User>> GetAllUsersAsync(string? category = null, string? search = null, int pageSize = 0, int pageNumber = 1,string? sortBy = null, bool ascending = true);
        Task<User> GetUserByIdAsync(int userId);
        Task<User> CreateUserAsync(User user);
        Task<bool> DeleteUserAsync(int id);
        Task SaveAsync();

        Task UpdateAsync(int id, User updatedUser);
    }
}

