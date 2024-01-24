using IDS.Models;

namespace IDS.Services.IServices
{
    public interface IEventMemberService
    {
        Task<List<EventMember>> GetAllAsync(string? category = null, string? search = null, int pageSize = 0, int pageNumber = 1);
        Task<EventMember> GetAsync(int id);
        Task<EventMember> CreateAsync(EventMember createDTO);
        Task RemoveAsync(int id);

        Task UpdateAsync(int id, EventMember updateDTO);
    }
}
