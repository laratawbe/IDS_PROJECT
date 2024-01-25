<<<<<<< HEAD
﻿using IDS.Models.DTOs;
using IDS.Models;
=======
﻿using System.Linq.Expressions;
using IDS.Models;
using IDS.Models.DTOs;
>>>>>>> e3e4f561d2d2079319f0d1e8592bec8d7d01fe5b

namespace IDS.Services.IServices
{
    public interface IUserService

    {
<<<<<<< HEAD
        Task<LoginResponseDTO> Login(LoginRequestDTO loginRequestDTO);
        Task<User> Register(RegistrationRequestDTO registrationRequestDTO);
        Task<List<User>> GetAllAsync(string? category = null, string? search = null, int pageSize = 0, int pageNumber = 1);
        Task<User> GetAsync(int id);
        Task<User> CreateAsync(User createDTO);
        Task RemoveAsync(int id);

        Task UpdateAsync(int id, User updateDTO);
=======
        Task<List<User>> GetAllUsersAsync(string? category = null, string? search = null, int pageSize = 0, int pageNumber = 1,string? sortBy = null, bool ascending = true);
        Task<User> GetUserByIdAsync(int userId);
        Task<User> CreateUserAsync(User user);
        Task<bool> DeleteUserAsync(int id);
        Task SaveAsync();

        Task UpdateAsync(int id, User updatedUser);
>>>>>>> e3e4f561d2d2079319f0d1e8592bec8d7d01fe5b
    }
}

