using IDS.Exceptions;
using IDS.Models;
using IDS.Repository.IRepository;
using IDS.Services.IServices;
using System.Linq;

namespace IDS.Services
{
    public class EventMemberService : IEventMemberService
    {
        public Task<EventMember> CreateAsync(EventMember createDTO)
        {
            throw new NotImplementedException();
        }

        public Task<List<EventMember>> GetAllAsync(string? category = null, string? search = null, int pageSize = 0, int pageNumber = 1)
        {
            throw new NotImplementedException();
        }

        public Task<EventMember> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task RemoveAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(int id, EventMember updateDTO)
        {
            throw new NotImplementedException();
        }
    }
}
