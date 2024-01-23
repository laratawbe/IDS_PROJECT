using IDS.Models.DTOs;
using IDS.Models;

namespace IDS.Services.IServices
{
    public interface IUserService
    {
        Task<LoginResponseDTO> Login(LoginRequestDTO loginRequestDTO);
        Task<User> Register(RegistrationRequestDTO registrationRequestDTO);
    }
}
