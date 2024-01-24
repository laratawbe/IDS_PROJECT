using IDS.Models;

namespace IDS.Services.IServices
{
    public interface IEventService
    {
        Task<List<Event>> GetAllAsync(string? category = null, string? search = null, int pageSize = 0, int pageNumber = 1);
        Task<Event> GetAsync(int id);
        Task<Event> CreateAsync(Event createDTO);
        Task RemoveAsync(int id);

        Task UpdateAsync(int id, Event updateDTO);
    }
}
