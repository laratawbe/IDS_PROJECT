using IDS.Models;
using IDS.Repository.IRepository;

namespace IDS.Repository
{
    public class EventRepository : Repository<Event>, IEventRepository
    {
        private readonly ActClubContext _db;
        public EventRepository(ActClubContext db) : base(db)
        {
            _db = db;
        }
    }
}
