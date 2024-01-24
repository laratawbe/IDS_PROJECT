using IDS.Exceptions;
using IDS.Models;
using IDS.Repository.IRepository;
using IDS.Services.IServices;
using System.Linq;

namespace IDS.Services
{
    public class EventMemberService : IEventMemberService
    {
        private readonly IRepository<EventMember> _eventMemberRepo;

        public EventMemberService(IRepository<EventMember> eventRepo)
        {
            _eventMemberRepo = eventRepo;
        }
        public async Task<List<EventMember>> GetAllAsync(string? category, string? search, int pageSize = 0, int pageNumber = 1)
        {
            IEnumerable<EventMember> eventList = await _eventMemberRepo.GetAllAsync(pageSize: pageSize, pageNumber: pageNumber);

            return eventList.ToList();
        }

        public async Task<EventMember> GetAsync(int id)
        {
            if (id <= 0)
            {
                throw new BadRequestException("Message");
            }
            var entity = await _eventMemberRepo.GetAsync(u => u.EventId == id) ?? throw new NotFoundException("Message");
            return entity;
        }
        public async Task<EventMember> CreateAsync(EventMember entity)
        {
            if (entity == null)
            {
                throw new BadRequestException("Message");
            }

            if (await _eventMemberRepo.GetAsync(u => u.EventMemberId == entity.EventMemberId) != null)
            {
                throw new BadRequestException("Message");

            }
            if (await _eventMemberRepo.GetAsync(em => em.EventId == entity.EventId && em.MemberId == entity.MemberId) != null)
            {
                throw new BadRequestException("EventMember with the same EventID and UserID already exists");
            }

            await _eventMemberRepo.CreateAsync(entity);
            return entity;
        }

        public async Task RemoveAsync(int id)
        {
            if (id <= 0)
            {
                throw new BadRequestException("Message");
            }
            var entity = await _eventMemberRepo.GetAsync(u => u.EventId == id);
            if (entity == null)
            {
                throw new BadRequestException("Message");
            }
            await _eventMemberRepo.RemoveAsync(entity);

        }
        public async Task UpdateAsync(int id, EventMember entity)
        {
            if (id <= 0)
            {
                throw new BadRequestException("Message");
            }

            if (entity == null || id != entity.EventMemberId)
            {
                throw new BadRequestException("Message");
            }
            if (await _eventMemberRepo.GetAsync(em => em.EventId == entity.EventId && em.MemberId == entity.MemberId) != null)
            {
                throw new BadRequestException("EventMember with the same EventID and UserID already exists");
            }

            await _eventMemberRepo.UpdateAsync(entity);
        }
    }
}
