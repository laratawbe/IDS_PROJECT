﻿using IDS.Exceptions;
using IDS.Models;
using IDS.Repository.IRepository;
using IDS.Services.IServices;

namespace IDS.Services
{
    public class EventGuideService : IEventGuideService
    {
        private readonly IRepository<EventGuide> _eventGuideRepo;

        public EventGuideService(IRepository<EventGuide> eventGuideRepo)
        {
            _eventGuideRepo = eventGuideRepo;
        }
        public async Task<List<EventGuide>> GetAllAsync(string? category, string? search, int pageSize = 0, int pageNumber = 1)
        {
            IEnumerable<EventGuide> eventGuideList = await _eventGuideRepo.GetAllAsync(pageSize: pageSize, pageNumber: pageNumber);
            return eventGuideList.ToList();
        }

        public async Task<EventGuide> GetAsync(int id)
        {
            if (id <= 0)
            {
                throw new BadRequestException("Message");
            }
            var entity = await _eventGuideRepo.GetAsync(u => u.EventGuideId == id) ?? throw new NotFoundException("Message");
            return entity;
        }
        public async Task<EventGuide> CreateAsync(EventGuide entity)
        {
            if (entity == null)
            {
                throw new BadRequestException("Message");
            }

            if (await _eventGuideRepo.GetAsync(u => u.EventGuideId== entity.EventGuideId) != null)
            {
                throw new BadRequestException("Message");

            }
            if (await _eventGuideRepo.GetAsync(em => em.EventId == entity.EventId && em.GuideId == entity.GuideId) != null)
            {
                throw new BadRequestException("EventGuide with the same EventID and UserID already exists");
            }

            await _eventGuideRepo.CreateAsync(entity);
            return entity;
        }

        public async Task RemoveAsync(int id)
        {
            if (id <= 0)
            {
                throw new BadRequestException("Message");
            }
            var entity = await _eventGuideRepo.GetAsync(u => u.EventGuideId == id);
            if (entity == null)
            {
                throw new BadRequestException("Message");
            }
            await _eventGuideRepo.RemoveAsync(entity);

        }
        public async Task UpdateAsync(int id, EventGuide entity)
        {
            if (id <= 0)
            {
                throw new BadRequestException("Message");
            }

            if (entity == null)
            {
                throw new BadRequestException("Message");
            }
            if (id != entity.EventGuideId)
            {
                throw new BadRequestException("Message");
            }
            if (await _eventGuideRepo.GetAsync(em => em.EventId == entity.EventId && em.GuideId == entity.GuideId) != null)
            {
                throw new BadRequestException("EventGuide with the same EventID and GuideId already exists");
            }
            await _eventGuideRepo.UpdateAsync(entity);
        }
    }
}
