using IDS.Models.DTOs;
using IDS.Models;
﻿using System.Linq.Expressions;
using IDS.Models;
using IDS.Models.DTOs;

namespace IDS.Services.IServices
{
    public interface IUserService

    {
        Task<LoginResponseDTO> Login(LoginRequestDTO loginRequestDTO);
        Task<User> Register(RegistrationRequestDTO registrationRequestDTO);
        Task<List<User>> GetAllAsync(string? category = null, string? search = null, int pageSize = 0, int pageNumber = 1);
        Task<User> GetAsync(int id);
        Task<User> CreateAsync(User createDTO);
        Task RemoveAsync(int id);

        Task UpdateAsync(int id, User updateDTO);
        
    }
}

