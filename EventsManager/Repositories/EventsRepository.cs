using System.Linq;
using EventsManager.Data;
using EventsManager.Models.Entities;
using EventsManager.Repositories.Base;

namespace EventsManager.Repositories
{

    public class EventsRepository : Repository<Event>, IEventsRepository
    {
        public EventsRepository(EventsDb db, IQueryable<Event> dataset) : base(db, dataset)
        {
        }
    }
}