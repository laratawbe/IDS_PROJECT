using IDS.Exceptions;
using IDS.Models;
using IDS.Repository.IRepository;
using IDS.Services.IServices;

namespace IDS.Services
{
    public class EventService : IEventService
    {
        private readonly IRepository<Event> _eventRepo;

        public EventService(IRepository<Event> eventRepo)
        {
            _eventRepo = eventRepo;
        }
        public async Task<List<Event>> GetAllAsync(string? category, string? search, int pageSize = 0, int pageNumber = 1)
        {
            IEnumerable<Event> eventList = await _eventRepo.GetAllAsync(pageSize: pageSize, pageNumber: pageNumber);

            Func<Event, bool> predicate = u =>
                (string.IsNullOrEmpty(search) || u.Name.ToLower().Contains(search));

            eventList = eventList.Where(predicate);

            return eventList.ToList(); 
        }

        public async Task<Event> GetAsync(int id)
        {
            if (id <= 0)
            {
                throw new BadRequestException("Message");
            }
            var entity = await _eventRepo.GetAsync(u => u.EventId == id) ?? throw new NotFoundException("Message");
            return entity;
        }
        public async Task<Event> CreateAsync(Event entity)
        {
            if (entity == null)
            {
                throw new BadRequestException("Message");
            }

            if (await _eventRepo.GetAsync(u => u.Name.ToLower() == entity.Name.ToLower()) != null)
            {
                throw new BadRequestException("Message");

            }

            await _eventRepo.CreateAsync(entity);
            return entity;
        }

        public async Task RemoveAsync(int id)
        {
            if (id <= 0)
            {
                throw new BadRequestException("Message");
            }
            var entity = await _eventRepo.GetAsync(u => u.EventId == id);
            if (entity == null)
            {
                throw new BadRequestException("Message");
            }
            await _eventRepo.RemoveAsync(entity);

        }
        public async Task UpdateAsync(int id, Event entity)
        {
            if (id <= 0)
            {
                throw new BadRequestException("Message");
            }

            if (entity == null || id != entity.EventId)
            {
                throw new BadRequestException("Message");
            }
            if (id != entity.EventId)
            {
                throw new BadRequestException("Message");
            }

            await _eventRepo.UpdateAsync(entity);
        }
    }
}
