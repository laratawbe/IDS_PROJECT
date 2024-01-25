using IDS.Models;

namespace IDS.Services.IServices
{
    public interface IEventGuideService
    {
        Task<List<EventGuide>> GetAllAsync(string? category = null, string? search = null, int pageSize = 0, int pageNumber = 1);
        Task<EventGuide> GetAsync(int id);
        Task<EventGuide> CreateAsync(EventGuide createDTO);
        Task RemoveAsync(int id);

        Task UpdateAsync(int id, EventGuide updateDTO);
    }
}
