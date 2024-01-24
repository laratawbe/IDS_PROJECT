using IDS.Models;
using IDS.Repository.IRepository;

namespace IDS.Repository
{
    public class EventMemberRepository : Repository<EventMember>, IEventMemberRepository
    {
        public EventMemberRepository(ActClubContext db) : base(db)
        {
        }
    }
}
